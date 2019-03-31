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
using PagedList;
using ApniMaa.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ApniMaa.BLL.Managers
{
    public class DishManager : BaseManager, IDishManager
    {

        private readonly IEmailProvider emailProvider;
        public DishManager()
        {

        }
        public DishManager(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;
            
        }

        ActionOutput IDishManager.AddDish(Dish model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var already = Context.Dishes.Where(p => p.Name == model.Name).Any();
                if(!already)
                {
                    Dish _dish = new Dish();
                    _dish.CategoryId = model.CategoryId;
                    _dish.Description = model.Description;
                    _dish.IsDeleted = false;
                    _dish.Name = model.Name;
                    _dish.CreatedDate = DateTime.Now;
                    Context.Dishes.Add(_dish);
                    Context.SaveChanges();
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Dish Added Successfully";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Dish with the same name already exists.";
                }
            }
            catch(Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }

        ActionOutput IDishManager.ModifyDish(Dish model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.Dishes.Where(p => p.Id == model.Id).FirstOrDefault();
                if(exists!=null)
                {
                    var already = Context.Dishes.Where(p => p.Name == model.Name && p.Id != model.Id).Any();
                    if(!already)
                    {
                        exists.CategoryId = model.CategoryId;
                        exists.Description = model.Description;
                        exists.Name = model.Name;
                        Context.SaveChanges();
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Dish updated Successfully";
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Dish already exists with Same Name";
                    }
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Dish doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput IDishManager.DeleteDish(Dish model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.Dishes.Where(p => p.Id == model.Id && p.IsDeleted==false).FirstOrDefault();
                if(exists!=null)
                {
                    exists.IsDeleted = true;
                    Context.SaveChanges();
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Dish Deleted Successfully";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Dish doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<DishModel> IDishManager.GetDishDetails(int Id)
        {
            ActionOutput<DishModel> res = new ActionOutput<DishModel>();
            try
            {
                var exists = Context.Dishes.Where(p => p.Id == Id && p.IsDeleted == false).FirstOrDefault();
                if (exists != null)
                {
                    res.Object = new DishModel(exists);
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Dish details fetched successfully.";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Dish doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        PagingResult<DishModel> IDishManager.GetDishPagedList(PagingModel model)
        {
            var result = new PagingResult<DishModel>();
            model.SortBy = model.SortBy == null ? "CreatedDate" : model.SortBy;
            model.SortOrder = model.SortOrder == null ? "Desc" : model.SortOrder;
            var query = Context.Dishes.AsEnumerable().OrderBy(model.SortBy + " " + model.SortOrder);
            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(z => ((z.Description != null && z.Description.ToLower().Contains(model.Search.ToLower())) || (z.Name != null && (z.Name.ToLower()).Contains(model.Search.ToLower()))
                   || (z.Category.Name.ToLower()).Contains(model.Search.ToLower())));
            }
            var list = query
               .Skip((model.PageNo - 1) * model.RecordsPerPage).Take(model.RecordsPerPage)
               .ToList().Select(x => new DishModel(x)).ToList();
            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = "Dish List";
            result.TotalCount = query.Count();
            return result;
        }


    }
}
