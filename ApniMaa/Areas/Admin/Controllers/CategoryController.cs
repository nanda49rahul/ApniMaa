#region Default Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
#endregion

#region Custom Namespaces
using ApniMaa.Attributes;
using ApniMaa.BLL.Models;
using ApniMaa.BLL.Interfaces;
using ApniMaa.BLL.Common;
using ApniMaa.BLL.Models.Admin_Models;
#endregion

namespace ApniMaa.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        #region Variable Declaration
        private readonly ICategoryManager _CategoryManager;
        private readonly IEmailTemplateManager _templateManager;
        #endregion

        public CategoryController(ICategoryManager CategoryManager, IErrorLogManager errorLogManager, IEmailTemplateManager templateManager)
            : base(errorLogManager)
        {
            _CategoryManager = CategoryManager;
            _templateManager = templateManager;
        }

        #region Category Management

        public ActionResult ManageCategory()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Category;
            var users = _CategoryManager.GetCategoriesPagedList(PagingModel.DefaultModel("CreatedOn"));
            return View(users);
        }

        [AjaxOnly, HttpPost]
        public JsonResult GetCategoriesPagedList(PagingModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Category;
            var modal = _CategoryManager.GetCategoriesPagedList(model);
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("Partials/_CategoryListing", modal));
            resultString.Add(modal.TotalCount.ToString());
            return JsonResult(resultString);
        }

        public ActionResult AddCategory()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Category;
            return View(new AddCategoryModel());
        }

        [AjaxOnly, HttpPost]
        public JsonResult AddCategory(AddCategoryModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Category;
            return JsonResult(_CategoryManager.AddCategory(model));
        }

        public ActionResult EditCategory(int Id)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Category;
            return View(_CategoryManager.GetCategoryDetails(Id).Object);
        }

        [AjaxOnly, HttpPost]
        public JsonResult UpdateCategory(EditCategoryModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Category;
            return JsonResult(_CategoryManager.ModifyCategory(model));
        }

        [AjaxOnly, HttpPost]
        public JsonResult DeleteCategory(int Id)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Category;
            return JsonResult(_CategoryManager.DeleteCategory(Id));
        }
        #endregion
    }
}