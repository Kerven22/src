using Enitities.Models.Enums;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Enitities.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(CombinedPumpStatus), "pump")]
    [JsonDerivedType(typeof(CombinedSamplerStatus), "sampler")]
    [JsonDerivedType(typeof(CombinedOvenStatus), "oven")]

    [XmlInclude(typeof(CombinedPumpStatus))]
    [XmlInclude(typeof(CombinedOvenStatus))]
    [XmlInclude(typeof(CombinedSamplerStatus))]
    public class CombinedStatuses
    {
        public ModuleState ModuleState { get; set; }
        public bool IsBusy { get; set; }
        public bool IsReady { get; set; }
        public bool IsError { get; set; }
        public bool KeyLock { get; set; }

        public CombinedStatuses() { }
    }
}
