using ApniMaa.BLL.Common;
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ApniMaa.DAL;
using PagedList;

namespace ApniMaa.BLL.Models
{
    public class MotherModel
    {

       public UserTbl user { get; set; }
       public MotherTbl mother { get; set; }
       public List<MotherDish> dish { get; set; }

    }


}
