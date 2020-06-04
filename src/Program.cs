using System;
using System.Diagnostics.CodeAnalysis;

namespace Camphora.Datasets {
	[ExcludeFromCodeCoverage]
	public class Program {
		public static void Main() {
			var dataExporter = new PeriodicTableFileExporter(
				new DataPathLookup()
			);

			dataExporter.Export();
		}
	}
}
