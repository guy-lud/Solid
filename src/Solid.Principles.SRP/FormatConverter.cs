using System;
using System.Diagnostics;
using System.IO;

namespace Solid.Principles.SRP
{
	public class FormatConverter
	{
		private readonly DocumentStorage _documentStorage;
		private readonly InputParser _inputParser;
		private readonly DocumentSerializer _documentSerializer;

		public FormatConverter()
		{
			_documentStorage = new DocumentStorage();
			_inputParser = new InputParser();
			_documentSerializer = new DocumentSerializer();
		}

		public void ConvertFormat(string sourceFileName, string targetFileName)
		{
			var input = _documentStorage.GetData(sourceFileName);
			
			var doc = _inputParser.ParseInput(input);

			var serializedDoc = _documentSerializer.Serialize(doc);
			
			_documentStorage.PersistDocument(serializedDoc, targetFileName);
		}
	}
}