//using ApniMaa.BLL.Common;;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class TransactionDetailsModel
//    {

//        public int Id { get; set; }
//        public int FleetId { get; set; }
//        public int CertId { get; set; }
//        public string OldCertNo { get; set; }
//        public string CertNo { get; set; }
//        public decimal SD { get; set; }
//        public decimal Premium { get; set; }
//        public decimal Corridor { get; set; }
//        public decimal Total { get; set; }
//        public System.DateTime TransactionDate { get; set; }
//        public string FleetName { get; set; }
//        public int TransactionTypeId { get; set; }
//        public TransactionType TransactionTypeName { get; set; }

//        public TransactionDetailsModel()
//        {


//        }
//        public bool IsActive { get; set; }
//        public TransactionDetailsModel(Transaction obj)
//        {


//            this.Id = obj.Id;
//            this.FleetId = obj.FleetId;
//            this.CertId = obj.CertId;
//            this.OldCertNo = obj.OldCertNo;
//            this.CertNo = obj.CertNo;
//            this.Total = obj.Total;
//            this.TransactionDate = obj.TransactionDate;
//            this.Premium = obj.Premium;
//            this.Corridor = obj.Corridor;
//            this.SD = obj.SD;
//            this.FleetName = obj.VehicleDetail.Fleet.FleetName;
//            this.TransactionTypeId = obj.TransactionType;
//            this.TransactionTypeName = ((TransactionType)obj.TransactionType);
//        }
//    }

    
//}
