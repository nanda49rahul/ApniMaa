using ApniMaa.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApniMaa.BLL.Models;
using System.Linq.Dynamic;
using ApniMaa.DAL;
// 
using System.Dynamic;
using System.IO;
using ApniMaa.BLL.Common;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Excel;
using System.Data;
using System.Web;
//using PagedList;
using ApniMaa.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using ApniMaa.BLL.Models.Admin_Models;

namespace ApniMaa.BLL.Managers
{
    public class CategoryManager : BaseManager, ICategoryManager
    {

        private readonly IEmailProvider _emailProvider;
        public CategoryManager(IEmailProvider emailProvider)
        {
            _emailProvider = emailProvider;
        }

        PagingResult<CategoryListingModel> ICategoryManager.GetCategoriesPagedList(PagingModel model)
        {
            var result = new PagingResult<CategoryListingModel>();

            model.SortBy = model.SortBy == null ? "CreatedOn" : model.SortBy;
            model.SortOrder = model.SortOrder == null ? "Desc" : model.SortOrder;

            var query = Context.Categories.Where(a=>a.IsDeleted == false).AsEnumerable().OrderBy(model.SortBy + " " + model.SortOrder);

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(z => 
                    ((z.Description != null && z.Description.ToLower().Contains(model.Search.ToLower())) || 
                    (z.Name != null && (z.Name.ToLower()).Contains(model.Search.ToLower()))));
            }
            var list = query
               .Skip((model.PageNo - 1) * model.RecordsPerPage).Take(model.RecordsPerPage)
               .ToList().Select(x => new CategoryListingModel(x)).ToList();

            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = "Category List";
            result.TotalCount = query.Count();
            return result;
        }

        ActionOutput ICategoryManager.AddCategory(AddCategoryModel model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var already = Context.Categories.Where(p => p.Name == model.Name).Any();
                if(!already)
                {
                    Category _category = new Category();
                    _category.Description = model.Description;
                    _category.IsDeleted = false;
                    _category.Name = model.Name;
                    _category.CreatedOn = DateTime.Now;
                    Context.Categories.Add(_category);
                    Context.SaveChanges();

                    return SuccessResponse("Category Added Successfully");
                }
                else
                {
                    return ErrorResponse("Category with the same name already exists.");
                }
            }
            catch(Exception ex)
            {
                return ErrorResponse("Some Error Occurred");
            }
        }

        ActionOutput ICategoryManager.ModifyCategory(EditCategoryModel model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.Categories.Where(p => p.Id == model.id).FirstOrDefault();
                if(exists!=null)
                {
                    var already = Context.Categories.Where(p => p.Name == model.Name && p.Id != model.id).Any();
                    if(!already)
                    {
                        exists.Description = model.Description;
                        exists.Name = model.Name;
                        Context.SaveChanges();

                        return SuccessResponse("Category updated Successfully");
                    }
                    else
                    {
                        return ErrorResponse("Category already exists with Same Name");
                    }
                }
                else
                {
                    return ErrorResponse("Category doesn't exists");
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse("Category doesn't exists");
            }
        }
        ActionOutput ICategoryManager.DeleteCategory(int Id)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.Categories.Where(p => p.Id == Id && p.IsDeleted==false).FirstOrDefault();
                if(exists!=null)
                {
                    exists.IsDeleted = true;
                    Context.SaveChanges();
                    return SuccessResponse("Category Deleted Successfully");
                }
                else
                {
                    return ErrorResponse("Category doesn't exists");
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse("Category doesn't exists");
            }
        }
        ActionOutput<EditCategoryModel> ICategoryManager.GetCategoryDetails(int Id)
        {
            ActionOutput<EditCategoryModel> res = new ActionOutput<EditCategoryModel>();
            try
            {
                var exists = Context.Categories.Where(p => p.Id == Id && p.IsDeleted == false).FirstOrDefault();
                if (exists != null)
                {
                    return SuccessResponse<EditCategoryModel>("Category details fetched successfully.", new EditCategoryModel(exists));
                }
                else
                {
                    return ErrorResponse<EditCategoryModel>("Category doesn't exists");
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse<EditCategoryModel>("Category doesn't exists");
            }
        }
        List<SelectListItem> ICategoryManager.GetCategoriesList()
        {
            var categoryList = Context.Categories.Where(p => p.IsDeleted == false).Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() }).ToList();
            return categoryList;
        }

    }
}
