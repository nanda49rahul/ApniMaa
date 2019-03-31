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

namespace ApniMaa.BLL.Managers
{
    public class CategoryManager : BaseManager, ICategoryManager
    {

        private readonly IEmailProvider emailProvider;
        public CategoryManager()
        {

        }
        public CategoryManager(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;
            
        }

        ActionOutput ICategoryManager.AddCategory(Category model)
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
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Category Added Successfully";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Category with the same name already exists.";
                }
            }
            catch(Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }

        ActionOutput ICategoryManager.ModifyCategory(Category model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.Categories.Where(p => p.Id == model.Id).FirstOrDefault();
                if(exists!=null)
                {
                    var already = Context.Categories.Where(p => p.Name == model.Name && p.Id != model.Id).Any();
                    if(!already)
                    {
                        exists.Description = model.Description;
                        exists.Name = model.Name;
                        Context.SaveChanges();
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Category updated Successfully";
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Category already exists with Same Name";
                    }
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Category doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput ICategoryManager.DeleteCategory(Category model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.Categories.Where(p => p.Id == model.Id && p.IsDeleted==false).FirstOrDefault();
                if(exists!=null)
                {
                    exists.IsDeleted = true;
                    Context.SaveChanges();
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Category Deleted Successfully";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Category doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<Category> ICategoryManager.GetCategoryDetails(int Id)
        {
            ActionOutput<Category> res = new ActionOutput<Category>();
            try
            {
                var exists = Context.Categories.Where(p => p.Id == Id && p.IsDeleted == false).FirstOrDefault();
                if (exists != null)
                {
                    res.Object =exists;
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Category details fetched successfully.";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Category doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        PagingResult<Category> ICategoryManager.GetCategoriesPagedList(PagingModel model)
        {
            var result = new PagingResult<Category>();
            model.SortBy = model.SortBy == null ? "CreatedDate" : model.SortBy;
            model.SortOrder = model.SortOrder == null ? "Desc" : model.SortOrder;
            var query = Context.Categories.AsEnumerable().OrderBy(model.SortBy + " " + model.SortOrder);
            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(z => ((z.Description != null && z.Description.ToLower().Contains(model.Search.ToLower())) || (z.Name != null && (z.Name.ToLower()).Contains(model.Search.ToLower()))
                   ));
            }
            var list = query
               .Skip((model.PageNo - 1) * model.RecordsPerPage).Take(model.RecordsPerPage)
               .ToList().Select(x => x).ToList();
            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = "Category List";
            result.TotalCount = query.Count();
            return result;
        }
        List<SelectListItem> ICategoryManager.GetCategoriesList()
        {
            var categoryList = Context.Categories.Where(p => p.IsDeleted == false).Select(p => new SelectListItem() { Text = p.Name, Value = p.Id.ToString() }).ToList();
            return categoryList;
        }

    }
}
