//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models.Admin_Models
//{
//    public class SectionReportListingModel
//    {
//        public string Section { get; set; }
//        public int NumberofCertificates { get; set; }

//        public SectionReportListingModel() { }

//        public SectionReportListingModel(SectionCode model)
//        {
//            this.Section = model.Name;
//            if (model.VehicleDetails != null)
//                this.NumberofCertificates = model.VehicleDetails.Count();
//        }
//    }

//    public class SearchCertiicateNoModel
//    {
//        public string CertificateNumber { get; set; }
//    }
//}
