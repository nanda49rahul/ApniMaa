using ApniMaa.BLL.Common;
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ApniMaa.DAL;
using PagedList;

namespace ApniMaa.BLL.Models
{
    public class MotherScheduleModel
    {
        public int Id { get; set; }
        public int MotherId { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int Type { get; set; }
        public bool Availabilty { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public MotherScheduleModel() { }
        public MotherScheduleModel(MotherDailySchedule obj)
        {
            this.Id = obj.Id;
            this.MotherId = obj.MotherId;
            this.CreatedDate = obj.Date;
            this.Type = obj.Type;
            this.Availabilty = obj.Availabilty;
            this.FirstName = obj.MotherTbl.UserTbl.FirstName;
            this.LastName = obj.MotherTbl.UserTbl.LastName;
            this.Email = obj.MotherTbl.UserTbl.Email;
            this.Phone = obj.MotherTbl.UserTbl.Phone;
            this.UserId = obj.MotherTbl.UserId;
                
        }
    }


}
