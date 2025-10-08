using System.Xml.Serialization;

namespace Enitities.Models
{
    [XmlRoot("InstrumentStatus")]
    public class InstrumentStatus
    {
        public string PackageID { get; set; }

        [XmlElement]
        public List<DivaceStatus> DivaceStatus { get; set; }

        public InstrumentStatus() { }

    }
}
