using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApniMaa.BLL.Models.Admin_Models;

namespace ApniMaa.BLL.Interfaces
{
    public interface ICategoryManager
    {
        PagingResult<CategoryListingModel> GetCategoriesPagedList(PagingModel model);
        ActionOutput AddCategory(AddCategoryModel model);
        ActionOutput ModifyCategory(EditCategoryModel model);
        ActionOutput DeleteCategory(int Id);
        ActionOutput<EditCategoryModel> GetCategoryDetails(int Id);
        List<SelectListItem> GetCategoriesList();
    }
}
