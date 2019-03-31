
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class QuickLinksModel
//    {
//        public int ID { get; set; }
//        public string LinkText { get; set; }
//        public string LinkUrl { get; set; }
//        public int AddedBy { get; set; }
//        public string AddedByUser { get; set; }
//        public DateTime AddedOn { get; set; }
//        public string Description { get; set; }
//        public bool IsFirmLink { get; set; }
//        public QuickLinksModel() { }
//        public QuickLinksModel(QuickLink obj)
//        {
//            this.AddedBy = obj.AddedBy;
//            this.AddedByUser = obj.User.FirstName + " " + obj.User.LastName;
//            this.AddedOn = obj.AddedOn;
//            this.ID = obj.ID;
//            this.LinkText = obj.LinkText;
//            this.LinkUrl = obj.LinkUrl;
//            this.IsFirmLink = obj.IsFirmLink;
//            this.Description = obj.Description;
//        }
//    }
//}
