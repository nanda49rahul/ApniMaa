using ApniMaa.BLL.Common;
// 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ApniMaa.DAL;
//using PagedList;

namespace ApniMaa.BLL.Models
{
    public class MotherDishScheduleModel
    {
        public int Id { get; set; }
        public int MotherDishId { get; set; }
        public System.DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; }
        public bool Availabilty { get; set; }

        public MotherDish motherdish { get; set; }
      
        public MotherDishScheduleModel() { }
        public MotherDishScheduleModel(MotherDishDailySchedule obj)
        {
            this.Id = obj.Id;
            this.Availabilty = obj.Availabilty;
            this.Date = obj.Date;
            this.MotherDishId = obj.MotherDishId;
            this.Quantity = obj.Quantity;
            this.Type = obj.Type;
            this.motherdish = obj.MotherDish;      
        }
    }


}
