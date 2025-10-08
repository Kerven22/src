using Enitities.Models;
using FileParserService.Abstraction;
using System.Text.Json;
using System.Xml.Serialization;

namespace FileParserService.Service
{
    public class SerializerService : ISerializerService
    {
        public async Task<string> Serialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(InstrumentStatus));
            InstrumentStatus instrumentStatus;
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                instrumentStatus = (InstrumentStatus)serializer.Deserialize(fileStream);
            }

            var json = JsonSerializer.Serialize(instrumentStatus, new JsonSerializerOptions { WriteIndented = true });

            return json;
        }
    }
}
