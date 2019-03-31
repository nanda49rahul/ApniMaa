using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApniMaa.BLL.Models
{
    public class ApplicationModel
    {
        public int Id { get; set; }
        public int FirmID { get; set; }
        public string FirmName { get; set; }
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string Recipients { get; set; }        
        public string Message { get; set; }
        public string ContactSMS { get; set; }
        public List<SelectListItem> FirmList { get; set; }
    }
}
