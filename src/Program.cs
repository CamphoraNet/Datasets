using System.Diagnostics.CodeAnalysis;

namespace Camphora.Datasets {
	[ExcludeFromCodeCoverage]
	public class Program {
		public static void Main() {
			var dataPathLookup = new DataPathLookup();
			var restSummaryPatch = new WikipediaRestPatch( dataPathLookup );
			restSummaryPatch.Apply();

			var dataExporter = new PeriodicTableFileExporter( dataPathLookup );
			dataExporter.Export();
		}
	}
}
