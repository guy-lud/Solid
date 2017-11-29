using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Solid.Principles.Raw
{
	class Program
	{
		static void Main(string[] args)
		{
			var sourceFileName = Path.Combine(Environment.CurrentDirectory, @"..\..\input.xml");
			var targetFileName = Path.Combine(Environment.CurrentDirectory, @"..\..\output.json");

			string input;
			using (var stream = File.OpenRead(sourceFileName))
			using (var reader = new StreamReader(stream))
			{
				input = reader.ReadToEnd();
			}

			var xdoc = XDocument.Parse(input);
			var doc = new Document
			{
				Title = xdoc.Root.Element("title").Value,
				Text = xdoc.Root.Element("text").Value
			};

			var serializedDoc = JsonConvert.SerializeObject(doc);

			using (var stream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
			using (var sw = new StreamWriter(stream))
			{
				sw.Write(serializedDoc);
				sw.Close();
			}
		}
	}
}
