
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class KnowledgeBaseModel
//    {
//        public int ID { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public int AddedBy { get; set; }
//        public int Category{get;set;}
//        public string CategoryName{get;set;}        
//        public DateTime AddedOn { get; set; }
//        public bool IsActive { get; set; }
//        public bool IsFirmNews { get; set; }
//        public string AddedByUser { get; set; }
//        public HttpPostedFileBase[] KnowledgeFiles { get; set; }
//        public List<KnowledgeBaseFileModel> Files { get; set; }

//        public KnowledgeBaseModel() { }
//        public KnowledgeBaseModel(KnowledgeBase model)
//        {
//            this.AddedBy = model.AddedBy;
//            this.AddedByUser = model.User.FirstName + " " + model.User.LastName;
//            this.AddedOn = model.AddedOn;
//            this.Description = model.Description;
//            var newsFiles = model.KnowledgeBaseFiles;
//            if (newsFiles != null && newsFiles.Count() > 0)
//            {
//                this.Files = newsFiles.Select(x => new KnowledgeBaseFileModel(x)).ToList();
//            }
//            this.ID = model.ID;
//            this.IsActive = model.IsActive;
//            this.IsFirmNews = model.IsFirmNews;
//            this.Title = model.Title;
//            this.Category = model.Category;
//            this.CategoryName = model.KnowledgeCategory.Name;
//        }
//    }

//    public class KnowledgeBaseFileModel
//    {
//        public int ID { get; set; }
//        public int KnowledgeID { get; set; }
//        public string FilePath { get; set; }
//        public string OriginalName { get; set; }

//        public KnowledgeBaseFileModel() { }

//        public KnowledgeBaseFileModel(KnowledgeBaseFile obj)
//        {
//            this.ID = obj.ID;
//            this.KnowledgeID = obj.KnowledgeID;
//            this.OriginalName = obj.OriginalName;
//            this.FilePath = "/Documents/KnowledgeBase/0/" + obj.FilePath;
//        }
//    }
//}
