using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApniMaa.BLL.Managers
{
    public class ApiPagingResult<T>
    {
        public List<T> List { get; set; }
        public int TotalCount { get; set; }
        public object Object { get; set; }
    }
}
