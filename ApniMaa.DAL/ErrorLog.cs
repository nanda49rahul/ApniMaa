//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApniMaa.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ErrorLog
    {
        public int ErrorLogID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string LoggedInDetails { get; set; }
        public string QueryData { get; set; }
        public string FormData { get; set; }
        public string RouteData { get; set; }
        public Nullable<System.DateTime> LoggedAt { get; set; }
    }
}
