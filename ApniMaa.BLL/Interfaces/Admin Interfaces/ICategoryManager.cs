using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApniMaa.DAL;

namespace ApniMaa.BLL.Interfaces
{
    public interface ICategoryManager
    {
        ActionOutput AddCategory(Category model);
        ActionOutput ModifyCategory(Category model);
        ActionOutput DeleteCategory(Category model);
        ActionOutput<Category> GetCategoryDetails(int Id);
        PagingResult<Category> GetCategoriesPagedList(PagingModel model);
        List<SelectListItem> GetCategoriesList();
    }
}
