using System.Xml.Serialization;

namespace DataProcessorService.Models
{
    public class InstrumentStatus
    {
        public string PackageID { get; set; }

        public List<DivaceStatus> DivaceStatus { get; set; }

        public InstrumentStatus() { }
    }
}
