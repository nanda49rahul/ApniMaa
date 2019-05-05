using ApniMaa.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApniMaa.BLL.Models;
using System.Linq.Dynamic;
using ApniMaa.DAL;

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
    public class OrderManager : BaseManager, IOrderManager
    {

        private readonly IEmailProvider emailProvider;
        private string Passhash = string.Empty;
        public OrderManager()
        {
        }
        public OrderManager (IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;
        }
         
        #region UserManagement
        PagingResult<OrderListingModel> IOrderManager.GetOrderPagedList(PagingModel model)
        {
            var result = new PagingResult<OrderListingModel>();
            model.SortBy = model.SortBy == null ? "id" : model.SortBy;
            model.SortOrder = model.SortOrder == null ? "Desc" : model.SortOrder;
            var query = Context.Orders.AsEnumerable().OrderBy(model.SortBy + " " + model.SortOrder).AsQueryable();

            //if (model.UserRole != null)
            //{
            //    query = query.Where(p => p.RoleId == model.UserRole);
            //}
            //if (UserStatus != 0)
            //{
            //    query = query.Where(p => p.Status == UserStatus);
            //}

            //if (!string.IsNullOrEmpty(model.Search))
            //{
            //    query = query.Where(z =>
            //        (z.FirstName.ToLower() + " " + z.LastName.ToLower()).Contains(model.Search.ToLower()) ||
            //        z.Email.ToString().Contains(model.Search.ToLower()));
            //}

            var list = query.Skip(model.PageNo - 1).Take(model.RecordsPerPage)
               .ToList().Select(x => new OrderListingModel(x)).ToList();
            ////int SerialNumber = 1;

            //var StateList = (from state in Context.Provinces select state).ToList();
            //var CityList = (from city in Context.Cities select city).ToList();
            //foreach (var item in list)
            //{

            //    if (item.Province != null)
            //    {
            //        item.StateName = StateList.Where(p => p.Id == item.Province).Select(p => p.Name).FirstOrDefault();
            //    }
            //    if (item.City != null)
            //    {
            //        item.CityName = CityList.Where(p => p.Id == item.City).Select(p => p.Name).FirstOrDefault();
            //    }
            //}

            list = list

           .ToList().Select(x => x).ToList();
            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = "User List";
            result.TotalCount = query.Count();
            return result;
        }
        
        #endregion
    }
}
