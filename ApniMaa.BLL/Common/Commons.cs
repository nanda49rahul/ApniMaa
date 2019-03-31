using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApniMaa.BLL.Models
{
    public class ActionOutputBase
    {
        public ActionStatus Status { get; set; }
        public String Message { get; set; }
        public List<String> Results { get; set; }
    }

    public class ActionOutput<T> : ActionOutputBase
    {
        public T Object { get; set; }
        public List<T> List { get; set; }
    }

    public class ActionOutput : ActionOutputBase
    {
        public Int32 ID { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalPaymentReceived { get; set; }
    }

    public class PagingResult<T>
    {
        public List<T> List { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public int Total { get; set; }
        public int CurrentMonth { get; set; }
        public decimal TotalPaymentReceived { get; set; }
        public ActionStatus Status { get; set; }
        public String Message { get; set; }
    }

    public class PagingModel : CustomPagingModel
    {
        public int PageNo { get; set; }
        public int RecordsPerPage { get; set; }
        public PagingModel()
        {
            if (PageNo <= 1)
            {
                PageNo = 1;
            }
            if (RecordsPerPage <= 0)
            {
                RecordsPerPage = AppDefaults.PageSize;
            }
        }

        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string Search { get; set; }
       
    }

    public class CustomPagingModel 
    {
        public int? FirmID { get; set; }
        public int? DateMonth { get; set; }
        public int? DateYear { get; set; }
        public bool IsProspect { get; set; }
        public int? VehicleTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DLNumber { get; set; }
        public string PlateNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string CertiicateNumber { get; set; }
    }

    public class CasePagingModel : PagingModel
    {
        public int CaseStatus { get; set; }
        public int CaseFileStatus { get; set; }
        public bool IsCaseRemoval { get; set; }
        public bool IsCaseInvoice { get; set; }
        public string CertNumber { get; set; }
        public string PlateNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverLicence { get; set; }
    }
    public class UserDetails
    {
        public Int32 UserID { get; set; }
        public String FirstName { get; set; }
        public String UserName { get; set; }
        public String LastName { get; set; }
        public String UserEmail { get; set; }
        public bool IsAuthenticated { get; set; }
        public UserDetails()
        { }


    }


    public class PermissonAndDetailModel
    {
        public UserModel UserDetails { get; set; }
        public IList<ModulesModel> ModulesModelList { get; set; }
    }

    public class ExceptionModal
    {
        public Exception Exception { get; set; }
        public UserDetails User { get; set; }
        public string FormData { get; set; }
        public string QueryData { get; set; }
        public string RouteData { get; set; }
        public string BrowserName { get; set; }
    }

    public class ExceptionReturnModal
    {
        public string ErrorID { get; set; }
        public string ErrorText { get; set; }
        public bool DatabaseLogStatus { get; set; }
    }
    public class ApiActionOutputBase
    {
        public int Status { get; set; }
        public String Message { get; set; }
    }

    public class ApiActionOutput : ApiActionOutputBase
    {
        public object result { get; set; }
    }
    public class ResponseBase
    {
        public string Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

    }

    public class Response<T> : ResponseBase
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T result { get; set; }

    }
}