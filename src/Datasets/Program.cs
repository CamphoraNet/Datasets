using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.IO;

namespace Camphora.Datasets {
	[ExcludeFromCodeCoverage]
	public class Program {
		public static void Main() {
			var exportTable = new ExportPeriodicTable();
			exportTable.Export();
			Console.WriteLine( "Export finished" );
		}
	}
}
