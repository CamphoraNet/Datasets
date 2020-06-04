using System.Net;

namespace Camphora.Datasets {
	public class WikipediaRestPatch {
		private const string RestUrl = "https://en.wikipedia.org/api/rest_v1/page/summary/";

		public void Apply() {
			using ( WebClient wc = new WebClient() ) {
				var json = wc.DownloadString( GetRestUrl( "Carbon" ) );
			}
		}

		private string GetRestUrl( string title ) {
			return $"{RestUrl}{title}";
		}
	}
}
