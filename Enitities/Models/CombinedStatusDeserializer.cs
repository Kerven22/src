using System.Xml.Linq;
using System.Xml.Serialization;

namespace Enitities.Models
{
    public static class CombinedStatusDeserializer
    {
        public static CombinedStatuses Deserialize(string rawXml)
        {
            if (string.IsNullOrWhiteSpace(rawXml))
                return null;

            try
            {
                var doc = XDocument.Parse(rawXml);
                string rootName = doc.Root.Name.LocalName;

                Type type = rootName switch
                {
                    "CombinedSamplerStatus" => typeof(CombinedSamplerStatus),
                    "CombinedPumpStatus" => typeof(CombinedPumpStatus),
                    "CombinedOvenStatus" => typeof(CombinedOvenStatus),
                    _ => typeof(CombinedStatuses)
                };

                var serializer = new XmlSerializer(type);
                using var reader = new StringReader(rawXml);
                return (CombinedStatuses)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка десериализации: {ex.Message}");
                return null;
            }
        }
    }
}
