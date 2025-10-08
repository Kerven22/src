using Enitities.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataProcessorService.Storage.Models
{
    public class Modules
    {
        [Key]
        public string ModuleCategoryID { get; set; }
        public ModuleState ModuleState { get; set; }
    }
}
