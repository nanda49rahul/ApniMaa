using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApniMaa.BLL.Models
{
    /// <summary>
    /// register Model this will be  used to login in the application
    /// </summary>
    public class registerModel
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

    }

}