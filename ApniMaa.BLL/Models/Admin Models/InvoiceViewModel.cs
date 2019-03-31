
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.BLL.Common;;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class InvoiceViewModel
//    {
//        public long Id { get; set; }
//        public string InvoiceNo { get; set; }
//        public DateTime InvoiceDate { get; set; }
//        public int FleetID { get; set; }
//        public int[] CertID { get; set; }
//        public string FleetName { get; set; }
//        public string PolicyNo { get; set; }
       
//        public string ApniMaaRefrence { get; set; }
//        public decimal Additions { get; set; }
//        public decimal Renewals { get; set; }
//        public decimal Cancellations { get; set; }

//        public decimal Premium { get; set; }
//        public decimal SD { get; set; }
//        public decimal Corridor { get; set; }

//        public decimal RPremium { get; set; }
//        public decimal RSD { get; set; }
//        public decimal RCorridor { get; set; }

//        public decimal CPremium { get; set; }
//        public decimal CSD { get; set; }
//        public decimal CCorridor { get; set; }
//        public decimal SubTotal { get; set; }
//        public decimal TotalAmount { get; set; }

//        public decimal RST { get; set; }
//        public decimal TaxAmount { get; set; }

//        public int InvoiceStatus { get; set; }
//        public bool IsPaymentDone { get; set; }

//        public System.DateTime CreatedOn { get; set; }
//        public System.DateTime LastModified { get; set; }

//        public int VehicleType { get; set; }
//        public int Month { get; set; }
//        public int Year { get; set; }

//        public string FirmContact { get; set; }
//        public string VehicleTypeName { get; set; }
//        public string PolicyPrefix { get; set; }
//        public string FleetAddress { get; set; }
//        public string FleetCity { get; set; }

//        public string FleetProvince { get; set; }
//        public string FleetZipCode { get; set; }

//        public string SInvoiceDate { get; set; }
//        public string Logo1 { get; set; }
//        public string Logo2 { get; set; }

//        public string FleetContact;
//        public string MonthName;
//        public string Invoice { get; set; }
//        public string InvoiceName { get; set; }
        
//        public InvoiceViewModel() { }

//        public InvoiceViewModel(FleetInvoice obj)
//        {
//            this.Id = obj.Id;
//            this.InvoiceNo = obj.InvoiceNo;
//            this.InvoiceDate = obj.InvoiceDate;
//            this.FleetID = obj.FleetID;
//            this.FleetName = obj.Fleet.FleetName;
//            this.PolicyNo = obj.PolicyNo;
//            this.Additions = obj.Additions;
//            this.Renewals = obj.Renewals;
//            this.Cancellations = obj.Cancellations;
//            this.TotalAmount = obj.TotalAmount;
//            this.InvoiceStatus = obj.InvoiceStatus;
//            this.IsPaymentDone = obj.IsPaymentDone;
//            this.CreatedOn = obj.CreatedOn;
//            this.LastModified = obj.LastModified;
//            this.VehicleType = obj.VehicleType;
//            this.Month = obj.Month;
//            this.Year = obj.Year;
//            this.VehicleTypeName = UtilitiesHelp.EnumToDecription(typeof(VehicleType), obj.VehicleType);

//            this.Premium = obj.Premium;
//            this.SD = obj.SD;
//            this.Corridor = obj.Corridor;

//            this.RPremium = obj.RPremium;
//            this.RSD = obj.RSD;
//            this.RCorridor = obj.RCorridor;

//            this.CPremium = obj.CPremium;
//            this.CSD = obj.CSD;
//            this.CCorridor = obj.CCorridor;
//            if (obj.Invoice != null)
//            {
//                this.Invoice = "../..//Uploads/Invoices/" + obj.Invoice;
//                this.InvoiceName = obj.InvoiceName;
//            }
            
//        }
//    }

//    public class IBCSettingModel
//    {
//        public List<Coverage> Data { get; set; }
//    }
//}
