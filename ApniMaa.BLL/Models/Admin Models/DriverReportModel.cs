//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models.Admin_Models
//{
//    public class DriverReportListingModel
//    {
//        public string LastName { get; set; }
//        public string FirstName { get; set; }
//        public string D_LNo { get; set; }
//        public string PlateNo { get; set; }
//        public DateTime? EffDate { get; set; }
//        public string VehicleType { get; set; }
//        public decimal MVRPercentage { get; set; }
//        public decimal MVAPercentage { get; set; }

//        public DriverReportListingModel() { }

//        public DriverReportListingModel(DriverVehicleMapping model)
//        {
//            if (model.Driver != null)
//            {
//                if (model.Driver.User != null)
//                {
//                    this.LastName = model.Driver.User.FirstName;
//                    this.FirstName = model.Driver.User.FirstName;

//                    if (model.Driver.User.UserInformation != null)
//                        this.D_LNo = model.Driver.User.UserInformation.LicenceNumber;
//                }

//                this.MVRPercentage = model.Driver.MVR;
//                this.MVAPercentage = model.Driver.MVA;
//            }

//            if (model.VehicleDetail != null)
//            {
//                this.PlateNo = model.VehicleDetail.PlateNumber;
//                this.EffDate = model.VehicleDetail.EffectiveDate;
//                this.VehicleType = ((VehicleType)model.VehicleDetail.VehicleType).ToString();
//            }
//        }
//    }
//}
