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
    
    public partial class OTP
    {
        public int OTPId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string OTPCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
