using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Models.Admin_Models
{
    public class VINResponseModel
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<VINResultModel> Results { get; set; }
    }

    public class VINResultModel
    {
        public string Value { get; set; }
        public string ValueId { get; set; }
        public string Variable { get; set; }
        public int VariableId { get; set; }

        public VINResultModel() { }

        public VINResultModel(DBTableVINResult model)
        {
            this.Value = model.Value;
            this.ValueId = model.ValueId;
            this.Variable = model.Variable;
            this.VariableId = model.VariableId;
        }
    }

    public class DBTableVINInformation
    {
        public int Id { get; set; }
        public string VIN { get; set; }
    }

    public class DBTableVINResult
    {
        public int Id { get; set; }
        public int FKDBTableVINInformationId { get; set; }
        public string Value { get; set; }
        public string ValueId { get; set; }
        public string Variable { get; set; }
        public int VariableId { get; set; }
    }
}
