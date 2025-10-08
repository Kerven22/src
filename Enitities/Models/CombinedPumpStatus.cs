using System.Xml.Serialization;

namespace Enitities.Models
{
    [XmlRoot("CombinedPumpStatus")]
    public class CombinedPumpStatus : CombinedStatuses
    {
        public CombinedPumpStatus()
        {

        }
        public string Mode { get; set; }
        public int Flow { get; set; }
        public int PercentB { get; set; }
        public int PercentC { get; set; }
        public int PercentD { get; set; }
        public double MinimumPressureLimit { get; set; }
        public double MaximumPressureLimit { get; set; }
        public int Pressure { get; set; }
        public bool PumpOn { get; set; }
        public int Channel { get; set; }
    }
}
