using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApniMaa.DAL;
using ApniMaa.BLL.Models.Admin_Models;

namespace ApniMaa.BLL.Interfaces
{
    public interface IHomeManager
    {
        
        ActionOutput<List<CategoryListingModel>> GetCategoryList();
        ActionOutput<List<MotherDish>> GetAmazingDishesList(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyType);
        ActionOutput<List<MotherModel>> GetMothersList(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyType);
        ActionOutput<List<MotherDish>> GetSignatureDishes(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyType);

    }
}
