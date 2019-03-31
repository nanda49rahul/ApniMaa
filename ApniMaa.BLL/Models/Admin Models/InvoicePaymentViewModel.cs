//using ApniMaa.BLL.Common;;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class InvoicePaymentViewModel
//    {
//        public long Id { get; set; }

//        public string InvoiceIds { get; set; }
//        public long[] SelectedInvoiceId { get; set; }

//        public int PaymentMode { get; set; }
//        public DateTime InvoiceDate { get; set; }
//        public int FirmID { get; set; }

//        public decimal PremiumAmount { get; set; }
//        public string PremiumChequeNo { get; set; }
//        public DateTime? PremiumChequeDate { get; set; }
//        public string PremiumBankName { get; set; }
//        public HttpPostedFileBase PremiumScannedCopy { get; set; }


//        public decimal SDAmount { get; set; }
//        public string SDChequeNo { get; set; }
//        public DateTime? SDChequeDate { get; set; }
//        public string SDBankName { get; set; }
//        public HttpPostedFileBase SDScannedCopy { get; set; }


//        public decimal CorridorAmount { get; set; }
//        public string CorridorChequeNo { get; set; }
//        public DateTime? CorridorChequeDate { get; set; }
//        public string CorridorBankName { get; set; }
//        public HttpPostedFileBase CorridorScannedCopy { get; set; }



//        public bool Status { get; set; }
//        public DateTime PaymentDate { get; set; }

//        public string InvoiceNos { get; set; }
//        public string PaymentModeName { get; set; }
//        public string FirmName { get; set; }

//        public List<CustomInvoicePaymentFiles> _Files { get; set; }

//        public string ApprovalMessage { get; set; }
//        public string InternalNotes { get; set; }


//        public InvoicePaymentViewModel() { }

//        public InvoicePaymentViewModel(FirmInvoicePayment obj)
//        {
//            this.Id = obj.Id;
//            this.InvoiceIds = obj.InvoiceIds;
//            this.PaymentMode = obj.PaymentMode;

//            this.FirmID = obj.FirmID;

//            this.PremiumAmount = obj.PremiumAmount;
//            this.PremiumChequeNo = obj.PremiumChequeNo;
//            this.PremiumChequeDate = obj.PremiumChequeDate;
//            this.PremiumBankName = obj.PremiumBankName;

//            this.SDAmount = obj.SDAmount;
//            this.SDChequeNo = obj.SDChequeNo;
//            this.SDChequeDate = obj.SDChequeDate;
//            this.SDBankName = obj.SDBankName;

//            this.CorridorAmount = obj.CorridorAmount;
//            this.CorridorChequeNo = obj.CorridorChequeNo;
//            this.CorridorChequeDate = obj.CorridorChequeDate;
//            this.CorridorBankName = obj.CorridorBankName;

//            this.Status = obj.Status;
//            this.PaymentModeName = UtilitiesHelp.EnumToDecription(typeof(PaymentModes), obj.PaymentMode);
//            this.PaymentDate = obj.PaymentDate;


//        }
//    }
//    public class CustomInvoicePaymentFiles
//    {
//        public long Id { get; set; }
//        public long FirmInvoicePaymentId { get; set; }

//        public string PremiumScannedCopy { get; set; }
//        public string PremiumFileUrl { get; set; }
//        public string SDScannedCopy { get; set; }
//        public string SDFileUrl { get; set; }
//        public string CorridorScannedCopy { get; set; }
//        public string CorridorFileUrl { get; set; }
        

//        public CustomInvoicePaymentFiles() { }

//        public CustomInvoicePaymentFiles(InvoicePaymentFile obj)
//        {
//            this.Id = obj.Id;
//            this.FirmInvoicePaymentId = obj.FirmInvoicePaymentId;

//            this.PremiumScannedCopy = obj.PremiumScannedCopy;
//            if (!string.IsNullOrEmpty(obj.PremiumScannedCopy))
//            {
//                this.PremiumFileUrl = "/Documents/InvoicePayment/" + obj.FirmInvoicePayment.FirmID + "/" + obj.PremiumScannedCopy;
//            }

//            this.SDScannedCopy = obj.SDScannedCopy;
//            if (!string.IsNullOrEmpty(obj.SDScannedCopy))
//            {
//                this.SDFileUrl = "/Documents/InvoicePayment/" + obj.FirmInvoicePayment.FirmID + "/" + obj.SDScannedCopy;
//            }

//            this.CorridorScannedCopy = obj.CorridorScannedCopy;
//            if (!string.IsNullOrEmpty(obj.CorridorScannedCopy))
//            {
//                this.CorridorFileUrl = "/Documents/InvoicePayment/" + obj.FirmInvoicePayment.FirmID + "/" + obj.CorridorScannedCopy;
//            }
//        }
//    }
//}
