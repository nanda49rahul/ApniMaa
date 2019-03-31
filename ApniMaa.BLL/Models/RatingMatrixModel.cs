
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class RatingMatrixModel
//    {
//        public int ID { get; set; }
//        public int CaseId { get; set; }
//        public int CategoryID { get; set; }
//        public string CategoryName { get; set; }
//        public Nullable<bool> DegreeLow { get; set; }
//        public Nullable<bool> DegreeMedium { get; set; }
//        public Nullable<bool> DegreeHigh { get; set; }
//        public string Notes { get; set; }

//        public RatingMatrixModel() { }

//        public RatingMatrixModel(RatingMatrix obj) {
//            this.CaseId = obj.CaseId;
//            this.CategoryID = obj.CategoryID;
//            this.CategoryName = obj.CategoryName;
//            this.DegreeHigh = obj.DegreeHigh;
//            this.DegreeLow = obj.DegreeLow;
//            this.DegreeMedium = obj.DegreeMedium;
//            this.Notes = obj.Notes;

//        }
//    }

//    public class RatingModelMatrixList
//    {
//        public List<RatingMatrixModel> RatingModel { get; set; }
//    }
//}
