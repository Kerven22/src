using Enitities.Models;

namespace DataProcessorService.Models
{
    public class DivaceStatus
    {

        public string ModuleCategoryID { get; set; }
        public int IndexWithinRole { get; set; }

        public CombinedStatuses RapidControlStatus { get; set; }

        public DivaceStatus() { }
    }
}
