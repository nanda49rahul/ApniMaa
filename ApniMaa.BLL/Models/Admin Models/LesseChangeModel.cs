//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models.Admin_Models
//{
//    public class LesseChangeListingModel
//    {
//        public string CertificateNumber { get; set; }
//        public string CertificateType { get; set; }
//        public string FleetName { get; set; }
//        public DateTime DateChange { get; set; }
//        public string PreviousLesseeName { get; set; }
//        public string PrevLesseeAddress { get; set; }
//        public string PrevLesseeDrivingLicenceNo { get; set; }
//        public string NewLesseeName { get; set; }
//        public string NewLesseeAddress { get; set; }
//        public string NewLesseeDrivingLisenceNo { get; set; }


//        public LesseChangeListingModel() { }

//        public LesseChangeListingModel(CertificateUpdateDetail model)
//        {
//            if (model.VehicleDetail != null)
//            {
//                this.CertificateNumber = model.VehicleDetail.ApniMaaRefrenceID;
//                this.CertificateType = ((VehicleType)model.VehicleDetail.VehicleType).ToString();
//                this.FleetName = model.VehicleDetail.Fleet.FleetName;
//            }


//            this.DateChange = model.DateCreated;

//            if (model.User != null)
//            {
//                var user = model.User;

//                if (model.User.UserId == model.FKPrevUserId)
//                {
//                    user = model.User;
//                }
//                else
//                {
//                    if (model.User1 != null)
//                    {
//                        if (model.User1.UserId == model.FKPrevUserId)
//                        {
//                            user = model.User1;
//                        }
//                    }
//                }


//                this.PreviousLesseeName = string.Format("{0} {1}", user.FirstName, user.LastName);

//                if (user.UserContactDetails != null)
//                {
//                    var userDetails = user.UserContactDetails.FirstOrDefault();
//                    if (userDetails != null)
//                        this.PrevLesseeAddress = string.Format("{0}", userDetails.StreetAddress);
//                }
//                if (user.UserInformation != null)
//                    this.PrevLesseeDrivingLicenceNo = user.UserInformation.LicenceNumber;
//            }

//            if (model.User != null)
//            {
//                var user = model.User;

//                if (model.User.UserId == model.FKCurrentUserId)
//                {
//                    user = model.User;
//                }
//                else
//                {
//                    if (model.User1 != null)
//                    {
//                        if (model.User1.UserId == model.FKCurrentUserId)
//                        {
//                            user = model.User1;
//                        }
//                    }
//                }


//                this.NewLesseeName = string.Format("{0} {1}", user.FirstName, user.LastName);

//                if (user.UserContactDetails != null)
//                {
//                    var userDetails = user.UserContactDetails.FirstOrDefault();
//                    if (userDetails != null)
//                        this.NewLesseeAddress = string.Format("{0}", userDetails.StreetAddress);
//                }

//                if (user.UserInformation != null)
//                    this.NewLesseeDrivingLisenceNo = user.UserInformation.LicenceNumber;
//            }
//        }
//    }
//}
