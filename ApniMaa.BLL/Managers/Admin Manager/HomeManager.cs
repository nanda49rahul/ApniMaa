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
    public class HomeManager : BaseManager, IHomeManager
    {

        private readonly IEmailProvider emailProvider;
        public HomeManager()
        {

        }
        public HomeManager(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;
            
        }
        ActionOutput<List<Category>> IHomeManager.GetCategoryList()
        {
            ActionOutput<List<Category>> res = new ActionOutput<List<Category>>();
            try
            {
                res.Object = Context.Categories.Where(p => p.IsDeleted == false).ToList();
                res.Message = "Categories fetched successfully";
                res.Status = ActionStatus.Successfull;
            }
            catch(Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<List<MotherDish>> IHomeManager.GetAmazingDishesList(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyTypes)
        {
            ActionOutput<List<MotherDish>> res = new ActionOutput<List<MotherDish>>();
            try
            {
                var data = (from m in Context.MotherTbls join u in Context.UserTbls on m.UserId equals (u.Id) where (u.Status == (int)UserStatuss.Verified || u.Status == (int)UserStatuss.Subscribed) && UtilitiesHelp.HaversineDistance(new LatLng(Convert.ToDouble(u.Latitute), Convert.ToDouble(u.Longitute)), new LatLng(Latitute, Longitute)) >= 5 select m).ToList();
                var DaySchedule = Context.MotherDailySchedules.Where(p => p.Date == ReqDate).AsQueryable();

                if (AvailabiltyTypes == (int)AvailibiltyType.Dinner)
                {
                    DaySchedule = DaySchedule.Where(p => p.Type == (int)AvailibiltyType.Both && p.Type == (int)AvailibiltyType.Dinner).AsQueryable();
                }
                else
                {
                    DaySchedule = DaySchedule.Where(p => p.Type == (int)AvailibiltyType.Both && p.Type == (int)AvailibiltyType.Lunch).AsQueryable();
                }

                List<MotherTbl> _mothers = new List<MotherTbl>();
                foreach (var item in data)
                {
                    var s = DaySchedule.Where(p => p.MotherId == item.Id).FirstOrDefault();
                    if (s != null)
                    {
                        if (s.Availabilty == true)
                        {
                            _mothers.Add(item);
                        }
                    }
                }
                var DailyDishSchedule = Context.MotherDishDailySchedules.Where(p => p.Date == DateTime.Now).AsQueryable();
                List<MotherTbl> _fmothers = new List<MotherTbl>();
                foreach (var item in _mothers)
                {
                    var s = DailyDishSchedule.Where(p => p.MotherDish.MotherId == item.Id).ToList();
                    if (s.Count != 0)
                    {
                        foreach (var items in s)
                        {
                            if (items.Availabilty == true)
                            {
                                if (!_fmothers.Contains(item))
                                {
                                    if (CategoryId != 0)
                                    {
                                        if (items.MotherDish.Dish.CategoryId == CategoryId)
                                        {
                                            _fmothers.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        _fmothers.Add(item);
                                    }
                                }
                            }
                        }

                    }
                }
                List<MotherDish> model = new List<MotherDish>();

                foreach (var item in _fmothers)
                {
                    MotherDish mm = new MotherDish();
                    
                    mm = DailyDishSchedule.Where(p => p.MotherDish.MotherId == item.Id && p.Availabilty == true).Select(p => p.MotherDish).OrderBy(p=>p.Id).FirstOrDefault();
                    model.Add(mm);
                }
                res.Object = model;
                res.Message = "Data Fetched Successfully";
                res.Status = ActionStatus.Successfull;
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<List<MotherModel>> IHomeManager.GetMothersList(double Longitute, double Latitute,DateTime ReqDate,int CategoryId,int AvailabiltyTypes)
        {
            ActionOutput<List<MotherModel>> res = new ActionOutput<List<MotherModel>>();
            try
            {
                var data = (from m in Context.MotherTbls join u in Context.UserTbls on m.UserId equals (u.Id) where (u.Status == (int)UserStatuss.Verified || u.Status == (int)UserStatuss.Subscribed) && UtilitiesHelp.HaversineDistance(new LatLng(Convert.ToDouble(u.Latitute),Convert.ToDouble(u.Longitute)), new LatLng(Latitute,Longitute)) >= 5 select m).ToList();
                var DaySchedule = Context.MotherDailySchedules.Where(p => p.Date == ReqDate).AsQueryable();
               
                if(AvailabiltyTypes==(int)AvailibiltyType.Dinner)
                {
                    DaySchedule = DaySchedule.Where(p => p.Type == (int)AvailibiltyType.Both && p.Type==(int)AvailibiltyType.Dinner).AsQueryable();
                }
                else
                {
                    DaySchedule = DaySchedule.Where(p => p.Type == (int)AvailibiltyType.Both && p.Type == (int)AvailibiltyType.Lunch).AsQueryable();
                }
               
                List<MotherTbl> _mothers = new List<MotherTbl>();
                foreach (var item in data)
                {
                    var s=DaySchedule.Where(p => p.MotherId == item.Id).FirstOrDefault();
                    if(s!=null)
                    {
                        if(s.Availabilty==true)
                        {
                            _mothers.Add(item);
                        }
                    }
                }
                var DailyDishSchedule= Context.MotherDishDailySchedules.Where(p => p.Date == DateTime.Now).AsQueryable();
                List<MotherTbl> _fmothers = new List<MotherTbl>();
                foreach (var item in _mothers)
                {
                    var s = DailyDishSchedule.Where(p => p.MotherDish.MotherId == item.Id).ToList();
                    if (s.Count!=0)
                    {
                        foreach (var items in s)
                        {
                            if (items.Availabilty == true)
                            {
                                if (!_fmothers.Contains(item))
                                {
                                    if (CategoryId != 0)
                                    {
                                        if (items.MotherDish.Dish.CategoryId == CategoryId)
                                        {
                                            _fmothers.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        _fmothers.Add(item);
                                    }
                                }
                            }
                        }
                        
                    }
                }
                List<MotherModel> model = new List<MotherModel>();
                
                foreach (var item in _fmothers)
                {
                    MotherModel mm = new MotherModel();
                    mm.user = item.UserTbl;
                    mm.mother = item;
                    mm.dish = DailyDishSchedule.Where(p => p.MotherDish.MotherId == item.Id && p.Availabilty == true).Select(p=>p.MotherDish).ToList();
                    model.Add(mm);
                }
                res.Object = model;
                res.Message = "Data Fetched Successfully";
                res.Status = ActionStatus.Successfull;
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<List<MotherDish>> IHomeManager.GetSignatureDishes(double Longitute, double Latitute, DateTime ReqDate, int CategoryId, int AvailabiltyTypes)
        {
            ActionOutput<List<MotherDish>> res = new ActionOutput<List<MotherDish>>();
            try
            {
                var data = (from m in Context.MotherTbls join u in Context.UserTbls on m.UserId equals (u.Id) where (u.Status == (int)UserStatuss.Verified || u.Status == (int)UserStatuss.Subscribed) && UtilitiesHelp.HaversineDistance(new LatLng(Convert.ToDouble(u.Latitute), Convert.ToDouble(u.Longitute)), new LatLng(Latitute, Longitute)) >= 5 select m).ToList();
                var DaySchedule = Context.MotherDailySchedules.Where(p => p.Date == ReqDate).AsQueryable();

                if (AvailabiltyTypes == (int)AvailibiltyType.Dinner)
                {
                    DaySchedule = DaySchedule.Where(p => p.Type == (int)AvailibiltyType.Both && p.Type == (int)AvailibiltyType.Dinner).AsQueryable();
                }
                else
                {
                    DaySchedule = DaySchedule.Where(p => p.Type == (int)AvailibiltyType.Both && p.Type == (int)AvailibiltyType.Lunch).AsQueryable();
                }

                List<MotherTbl> _mothers = new List<MotherTbl>();
                foreach (var item in data)
                {
                    var s = DaySchedule.Where(p => p.MotherId == item.Id).FirstOrDefault();
                    if (s != null)
                    {
                        if (s.Availabilty == true)
                        {
                            _mothers.Add(item);
                        }
                    }
                }
                var DailyDishSchedule = Context.MotherDishDailySchedules.Where(p => p.Date == DateTime.Now).AsQueryable();
                List<MotherTbl> _fmothers = new List<MotherTbl>();
                foreach (var item in _mothers)
                {
                    var s = DailyDishSchedule.Where(p => p.MotherDish.MotherId == item.Id).ToList();
                    if (s.Count != 0)
                    {
                        foreach (var items in s)
                        {
                            if (items.Availabilty == true)
                            {
                                if (!_fmothers.Contains(item))
                                {
                                    if (CategoryId != 0)
                                    {
                                        if (items.MotherDish.Dish.CategoryId == CategoryId)
                                        {
                                            _fmothers.Add(item);
                                        }
                                    }
                                    else
                                    {
                                        _fmothers.Add(item);
                                    }
                                }
                            }
                        }

                    }
                }
                List<MotherDish> model = new List<MotherDish>();

                foreach (var item in _fmothers)
                {
                    MotherDish mm = new MotherDish();

                    mm = DailyDishSchedule.Where(p => p.MotherDish.MotherId == item.Id && p.Availabilty == true && p.MotherDish.IsSignatureDish==true).Select(p => p.MotherDish).OrderBy(p => p.Id).FirstOrDefault();
                    model.Add(mm);
                }
                res.Object = model;
                res.Message = "Data Fetched Successfully";
                res.Status = ActionStatus.Successfull;
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }



    }
}
