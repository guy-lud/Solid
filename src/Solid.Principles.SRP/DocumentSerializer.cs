using Newtonsoft.Json;

namespace Solid.Principles.SRP
{
	public class DocumentSerializer
	{
		public string Serialize(Document document)
		{
			return JsonConvert.SerializeObject(document);
		}
	}
}