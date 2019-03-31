
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class AuditModel
//    {
//        public string UserName { get; set; }
//        public string ProfileImage { get; set; }
//        public string MessageNote { get; set; }
//        public string Status { get; set; }
//        public DateTime DateUpdated { get; set; }

//        public AuditModel() { }
//        public AuditModel(AuditTrial obj)
//        {
//            this.UserName = obj.User.FirstName + " " + obj.User.LastName;
//            this.ProfileImage = "";
//            this.MessageNote = obj.Note;
//            this.DateUpdated = obj.UpdatedDate;
//            this.Status = obj.Status;
//        }
//    }
//}
