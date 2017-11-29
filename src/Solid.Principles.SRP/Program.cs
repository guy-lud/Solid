using System;
using System.IO;

namespace Solid.Principles.SRP
{
    class Program
    {
		static void Main(string[] args)
		{
			var sourceFileName = Path.Combine(Environment.CurrentDirectory, @"..\..\input.xml");
			var targetFileName = Path.Combine(Environment.CurrentDirectory, @"..\..\output.json");

			var formatConverter = new FormatConverter();

			try
			{
				formatConverter.ConvertFormat(sourceFileName, targetFileName);
			}
			catch (Exception e)
			{
				Console.WriteLine("Conversion failed...");
				Console.ReadKey();
			}
		}
	}
}
