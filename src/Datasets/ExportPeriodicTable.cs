using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Camphora.Datasets {
	[ExcludeFromCodeCoverage]
	public class ExportPeriodicTable {
		public void Export() {
			using ( StreamReader reader = File.OpenText( PathToPeriodicTable() ) ) {
				JArray o = (JArray)JToken.ReadFrom( new JsonTextReader( reader ) );
				{
					string serializedJson = JsonConvert.SerializeObject( o, Formatting.None );

					File.WriteAllText(
						GetBasePath() + @"json/periodic-table.min.json",
						serializedJson
					);

					Console.WriteLine( "Updated minified JSON file of the periodic table..." );
				}

				foreach ( JObject element in o ) {
					string serializedJson =
						JsonConvert.SerializeObject( element, Formatting.Indented ) + "\n";
					string elementPath = PathToElement( element );

					if ( File.ReadAllText( elementPath ) == serializedJson ) {
						continue;
					}
					else {
						File.WriteAllText(
							elementPath,
							serializedJson
						);

						Console.WriteLine( $"Updated JSON file for {element["name"]}..." );
					}
				}
			}
		}

		private string GetBasePath() {
			return "../../../../../";
		}

		private string PathToPeriodicTable() {
			string combinedPath = Path.Combine( GetBasePath(), @"json/periodic-table.json" );
			return Path.GetFullPath( combinedPath );
		}

		private string PathToElement( JObject element ) {
			string number = element["number"].ToString().PadLeft( 3, '0' );
			string elementName = element["name"].ToString().ToLowerInvariant();
			string combinedPath = Path.Combine(
				GetBasePath(),
				$"json/elements/{number}-{elementName}.json"
			);

			return Path.GetFullPath( combinedPath );
		}
	}
}
