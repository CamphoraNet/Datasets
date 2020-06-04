using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Camphora.Datasets {
	public class WikipediaRestPatch {
		public WikipediaRestPatch( DataPathLookup dataPathLookup ) {
			DataPathLookup = dataPathLookup;
		}

		private DataPathLookup DataPathLookup { get; }
		private const string RestUrl = "https://en.wikipedia.org/api/rest_v1/page/summary/";

		public void Apply() {
			using StreamReader reader = File.OpenText( DataPathLookup.ToPeriodicTable() );
			using WebClient wc = GetWebClient();

			JArray periodicTable = (JArray)JToken.ReadFrom( new JsonTextReader( reader ) );
			foreach ( JObject element in periodicTable ) {
				string elementWikiTitleName = GetElementWikiTitle( element );

				string jsonRestString = wc.DownloadString( GetRestUrl( elementWikiTitleName ) );
				JObject serializedJson = JObject.Parse( jsonRestString );
				element["summary"] = serializedJson["extract"];
			}
		}

		private string GetElementWikiTitle( JObject element ) {
			string elementWikiTitleName = element["name"].ToString();
			if ( element["name"].ToString() == "Mercury" ) {
				elementWikiTitleName = "Mercury_(element)";
			}

			return elementWikiTitleName;
		}

		private string GetRestUrl( string title ) {
			return $"{RestUrl}{title}";
		}

		private WebClient GetWebClient() {
			WebClient wc = new WebClient();
			wc.Headers.Add(
				HttpRequestHeader.UserAgent,
				"https://github.com/CamphoraNet/Datasets" +
				" " +
				"Repository for structured data related to chemistry" );
			return wc;
		}
	}
}
