using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Models
{
    public class PagingCustomModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOS { get; set; }
        public bool ActiveStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public int SearchType { get; set; }
    }
}
