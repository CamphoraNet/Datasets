using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Camphora.Datasets {
	[ExcludeFromCodeCoverage]
	public class PeriodicTableFileExporter {
		public PeriodicTableFileExporter( DataPathLookup dataPathLookup ) {
			DataPathLookup = dataPathLookup;
		}

		private DataPathLookup DataPathLookup { get; }

		public void Export() {
			using StreamReader reader = File.OpenText( DataPathLookup.ToPeriodicTable() );
			JArray periodicTable = (JArray)JToken.ReadFrom( new JsonTextReader( reader ) );
			UpdateMinifiedTable( periodicTable );
			UpdateEachElement( periodicTable );
			Console.WriteLine( "[Finished] Synchronizing files" );
		}

		private void UpdateEachElement( JArray periodicTable ) {
			foreach ( JObject element in periodicTable ) {
				string serializedJson =
					JsonConvert.SerializeObject( element, Formatting.Indented ) + "\n";
				string elementPath = DataPathLookup.ToElement( element );

				if ( File.ReadAllText( elementPath ) == serializedJson ) {
					continue;
				}
				else {
					File.WriteAllText( elementPath, serializedJson );
					Console.WriteLine( $"Synchronized JSON file for {element["name"]}..." );
				}
			}
		}

		private void UpdateMinifiedTable( JArray periodicTable ) {
			string serializedJson = JsonConvert.SerializeObject( periodicTable, Formatting.None );

			File.WriteAllText( DataPathLookup.ToMinifiedTable(), serializedJson );
			Console.WriteLine( "Synchronized minified JSON file of the periodic table..." );
		}
	}
}
