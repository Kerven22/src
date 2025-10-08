using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Enitities.Models
{
    public class DivaceStatus
    {
        public string ModuleCategoryID { get; set; }
        public int IndexWithinRole { get; set; }

        [XmlElement("RapidControlStatus")]
        [JsonIgnore]
        public string RapidControlStatusRaw { get; set; }

        [XmlIgnore]
        public CombinedStatuses RapidControlStatus => CombinedStatusDeserializer.Deserialize(RapidControlStatusRaw);

        public DivaceStatus() { }

    }
}
