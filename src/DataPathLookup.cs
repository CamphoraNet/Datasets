using System.IO;
using Newtonsoft.Json.Linq;

namespace Camphora.Datasets {
	public class DataPathLookup {
		public string ToPeriodicTable() {
			return Path.GetFullPath( @"json/periodic-table.json" );
		}

		public string ToMinifiedTable() {
			return Path.GetFullPath( @"json/periodic-table.min.json" );
		}

		public string ToElement( JObject element ) {
			string number = element["number"].ToString().PadLeft( 3, '0' );
			string elementName = element["name"].ToString().ToLowerInvariant();

			return Path.GetFullPath( $"json/elements/{number}-{elementName}.json" );
		}
	}
}
