
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class LiscNewsModel
//    {
//        public int ID { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public int AddedBy { get; set; }
//        public DateTime AddedOn { get; set; }
//        public bool IsActive { get; set; }
//        public bool IsFirmNews { get; set; }
//        public string AddedByUser { get; set; }
//        public HttpPostedFileBase[] NewsFiles { get; set; }
//        public List<LiscNewsFileModel> Files { get; set; }

//        public LiscNewsModel() { }
//        public LiscNewsModel(LiscNew model)
//        {
//            this.AddedBy = model.AddedBy;
//            this.AddedByUser = model.User.FirstName + " " + model.User.LastName;
//            this.AddedOn = model.AddedOn;
//            this.Description = model.Description;
//            var newsFiles = model.NewsFiles;
//            if (newsFiles != null && newsFiles.Count() > 0)
//            {
//                this.Files = newsFiles.Select(x =>  new LiscNewsFileModel(x)).ToList();
//            }
//            this.ID = model.ID;
//            this.IsActive = model.IsActive;
//            this.IsFirmNews = model.IsFirmNews;
//            this.Title = model.Title;
//        }
//    }

//    public class LiscNewsFileModel
//    {
//        public int ID { get; set; }
//        public int NewsID { get; set; }
//        public string FilePath { get; set; }
//        public string OriginalName { get; set; }

//        public LiscNewsFileModel() { }

//        public LiscNewsFileModel(NewsFile obj)
//        {
//            this.ID = obj.ID;
//            this.NewsID = obj.NewsID;
//            this.OriginalName = obj.OriginalName;
//            this.FilePath = "/Documents/LiscNews/0/" + obj.FilePath;
//        }
//    }
//}
