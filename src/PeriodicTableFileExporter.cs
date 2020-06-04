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
			JArray o = (JArray)JToken.ReadFrom( new JsonTextReader( reader ) );
			UpdateMinifiedTable( o );
			UpdateEachElement( o );
			Console.WriteLine( "Export finished" );
		}

		private void UpdateEachElement( JArray o ) {
			foreach ( JObject element in o ) {
				string serializedJson =
					JsonConvert.SerializeObject( element, Formatting.Indented ) + "\n";
				string elementPath = DataPathLookup.ToElement( element );

				if ( File.ReadAllText( elementPath ) == serializedJson ) {
					continue;
				}
				else {
					File.WriteAllText( elementPath, serializedJson );
					Console.WriteLine( $"Updated JSON file for {element["name"]}..." );
				}
			}
		}

		private void UpdateMinifiedTable( JArray o ) {
			string serializedJson = JsonConvert.SerializeObject( o, Formatting.None );

			File.WriteAllText( DataPathLookup.ToMinifiedTable(), serializedJson );
			Console.WriteLine( "Updated minified JSON file of the periodic table..." );
		}
	}
}
