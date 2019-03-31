using ApniMaa.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Common
{
    public static class WebResource
    {
        public static string Content(string key){

            return GlobalizationCulture.GetResxValByKey(key);
        }
    }
}
