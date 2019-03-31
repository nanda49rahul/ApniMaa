//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models.Admin_Models
//{
//    public class RenewalReportListingModel
//    {

//        public string PlateNumber { get; set; }
//        public string CertNo { get; set; }
//        public string SectionCode { get; set; }
//        public string Owner { get; set; }
//        public DateTime? DateRenewed { get; set; }
//        public int TotalRecords { get; set; }
//        public decimal Percentage { get; set; }
//        public int ReportType { get; set; }

//        public RenewalReportListingModel() { }

//        public RenewalReportListingModel(Transaction model)
//        {
//            if (model.VehicleDetail != null) 
//            {
//                this.PlateNumber = model.VehicleDetail.PlateNumber;
//                this.CertNo = model.VehicleDetail.ApniMaaRefrenceID;
//                this.SectionCode = model.VehicleDetail.SectionCode.Name;

//                var lessorId = model.VehicleDetail.LessorId;
//                var user = model.VehicleDetail.User;

//                if (model.VehicleDetail.User != null)
//                {
//                    if (model.VehicleDetail.User.UserId == lessorId)
//                        user = model.VehicleDetail.User;
//                }
//                if (model.VehicleDetail.User1 != null)
//                {
//                    if (model.VehicleDetail.User1.UserId == lessorId)
//                        user = model.VehicleDetail.User1;
//                }
//                if (model.VehicleDetail.User2 != null)
//                {
//                    if (model.VehicleDetail.User2.UserId == lessorId)
//                        user = model.VehicleDetail.User2;
//                }
//                if (model.VehicleDetail.User3 != null)
//                {
//                    if (model.VehicleDetail.User3.UserId == lessorId)
//                        user = model.VehicleDetail.User3;
//                }

//                if (user != null)
//                {
//                    this.Owner = string.Format("{0} {1}", user.FirstName, user.LastName);
//                }

//                this.DateRenewed = model.TransactionDate;


//                var currentDate = DateTime.UtcNow;

//                if ((model.VehicleDetail.Expiry.Value.Date >= currentDate.Date) && (model.VehicleDetail.Expiry.Value.Date < currentDate.AddDays(61).Date))
//                {
//                    this.ReportType = (int)RenewalReportTypes.UpcomingMonths;
//                }

//                if ((model.VehicleDetail.Expiry.Value.Date > currentDate.AddDays(60).Date))
//                {
//                    this.ReportType = (int)RenewalReportTypes.SameYear;
//                }

//                if (model.VehicleDetail.Expiry.Value.Date < currentDate.Date)
//                {
//                    this.ReportType = (int)RenewalReportTypes.Expiry;
//                }
//            }

            
//        }
//    }
//}
