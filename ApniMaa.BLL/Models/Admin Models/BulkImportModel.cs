
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class BulkImportModel
//    {

//        public int Id { get; set; }
//        public string FileName { get; set; }
//        public string OriginalName { get; set; }
//        public bool Status { get; set; }
//        public DateTime CreatedDate { get; set; }
     
//        public int Before_Certificates { get; set; }
//        public int After_Certificates { get; set; }
//        public int BulkType { get; set; }

//        public HttpPostedFileBase Excel_File { get; set; }
//        public HttpPostedFileBase Excel_File1 { get; set; }
//        public string FilePath { get; set; }
//        public int UserID { get; set; }
//        public int FleetId { get; set; }
//        public BulkImportModel()
//        {

//        }
//        public BulkImportModel(BulkImport model)
//        {
//            this.Id = model.Id;
//            this.FileName = model.FileName;
//            this.OriginalName = model.OriginalName;
//            this.Status = model.Status;
//            this.CreatedDate = model.CreatedDate;
//            this.Before_Certificates = model.Before_Certificates;
//            this.After_Certificates = model.After_Certificates;
//            this.BulkType = model.BulkType;
//            this.FleetId = model.FleetId;
//        }

        
//    }
//}
