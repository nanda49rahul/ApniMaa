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
    public class DishController : AdminBaseController
    {
        #region Variable Declaration
        private readonly IDishManager _DishManager;
        private readonly IEmailTemplateManager _templateManager;
        #endregion

        public DishController(IDishManager DishManager, IErrorLogManager errorLogManager, IEmailTemplateManager templateManager)
            : base(errorLogManager)
        {
            _DishManager = DishManager;
            _templateManager = templateManager;
        }

        #region Dish Management

        public ActionResult ManageDish()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Dish;
            var users = _DishManager.GetDishPagedList(PagingModel.DefaultModel("CreatedDate"));
            return View(users);
        }

        [AjaxOnly, HttpPost]
        public JsonResult GetDishPagedList(PagingModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Dish;
            var modal = _DishManager.GetDishPagedList(model);
            List<string> resultString = new List<string>();
            resultString.Add(RenderRazorViewToString("Partials/_DishListing", modal));
            resultString.Add(modal.TotalCount.ToString());
            return JsonResult(resultString);
        }

        public ActionResult AddDish()
        {
            ViewBag.SelectedTab = SelectedAdminTab.Dish;
            return View(new AddDishModel());
        }

        [AjaxOnly, HttpPost]
        public JsonResult AddDish(AddDishModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Dish;
            return JsonResult(_DishManager.AddDish(model));
        }

        public ActionResult EditDish(int Id)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Dish;
            return View(_DishManager.GetDishDetails(Id).Object);
        }

        [AjaxOnly, HttpPost]
        public JsonResult UpdateDish(EditDishModel model)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Dish;
            return JsonResult(_DishManager.ModifyDish(model));
        }

        [AjaxOnly, HttpPost]
        public JsonResult DeleteDish(int Id)
        {
            ViewBag.SelectedTab = SelectedAdminTab.Dish;
            return JsonResult(_DishManager.DeleteDish(Id));
        }
        #endregion
    }
}