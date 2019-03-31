
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class FirmNotesModel
//    {
//        public int ID { get; set; }
//        [AllowHtml]
//        public string Note { get; set; }
//        public DateTime AddedOn { get; set; }
//        public int AddedBy { get; set; }
//        public string AddedByUser { get; set; }
//        public string FirmName { get; set; }
//        public int FirmID { get; set; }
//        public string UserImage { get; set; }

//        public FirmNotesModel() { }

//        public FirmNotesModel(FirmNote obj)
//        {
//            this.ID = obj.ID;
//            this.AddedBy = obj.AddedBy;
//            this.Note = obj.Note;
//            this.AddedByUser = obj.User.FirstName + " " + obj.User.LastName;
//            this.AddedOn = obj.AddedOn;
//            this.FirmID = obj.FirmID;
//            this.FirmName = obj.Fleet.FleetName;
//            this.UserImage = "/Documents/ProfileImages/0/" + obj.User.Image; ;
//        }
//    }
//}
