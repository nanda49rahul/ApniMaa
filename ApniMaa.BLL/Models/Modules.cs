using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Models
{
    public class ModulesModel
    {
        public int ModuleId { get; set; }
        //public string ModuleName { get; set; }
        public string ControllerName { get; set; }
        //public string Description { get; set; }
        public bool? IsAdmin { get; set; }
        public ModulesModel() { }
        public ModulesModel(Module model)
        {
            this.ModuleId = model.ModuleId;
            //  this.ModuleName = model.ModuleName;
            this.ControllerName = model.ControllerName;
            //this.Description = model.Description;
            this.IsAdmin = model.IsAdmin;
        }
    }
}
