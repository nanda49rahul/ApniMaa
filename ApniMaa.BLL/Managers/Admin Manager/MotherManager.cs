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
    public class MotherManager : BaseManager, IMotherManager
    {

        private readonly IEmailProvider emailProvider;
        public MotherManager()
        {

        }
        public MotherManager(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;
            
        }
        ActionOutput<List<MotherQuestion>> IMotherManager.GetMotherQuestions()
        {
            ActionOutput<List<MotherQuestion>> res = new ActionOutput<List<MotherQuestion>>();
            try
            {
                var Questions = Context.MotherQuestions.Where(p=>p.IsDeleted==false).ToList();
                res.Object = Questions;
                res.Status = ActionStatus.Successfull;
                res.Message = "Questions fetched Successfully";
            }
            catch(Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput IMotherManager.SaveMotherAnswers(List<MotherAnswer> model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                foreach (var item in model)
                {
                    MotherAnswer _motherans = new MotherAnswer();
                    _motherans.Answer = item.Answer;
                    _motherans.MotherId = item.MotherId;
                    _motherans.QuestionId = item.QuestionId;
                    Context.MotherAnswers.Add(_motherans);
                }

                Context.SaveChanges();
                res.Status = ActionStatus.Successfull;
                res.Message = "Your answers are submitted to admin.";
                
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }

        ActionOutput<MotherModel> IMotherManager.UpdateMotherProfile(MotherModel model)
        {
            ActionOutput<MotherModel> res = new ActionOutput<MotherModel>();
            MotherModel resModel = new MotherModel();
            try
            {
                var existss = Context.UserTbls.Where(p => p.Id == model.user.Id).FirstOrDefault();
                if (existss != null)
                {
                    existss.LastName = model.user.LastName;
                    existss.Latitute = model.user.Latitute;
                    existss.Longitute = model.user.Longitute;
                    existss.Province = model.user.Province;
                    existss.Address = model.user.Address;
                    existss.City = model.user.City;
                    existss.Email = model.user.Email;
                    existss.FirstName = model.user.FirstName;
                    resModel.user = existss;
                     var exists = Context.MotherTbls.Where(p => p.Id == model.mother.Id).FirstOrDefault();
                    if (exists != null)
                    {
                        exists.Commision = model.mother.Commision;
                        exists.CoverPhoto = model.mother.CoverPhoto;
                        exists.DDeliveryTime = model.mother.DDeliveryTime;
                        exists.Description = model.mother.Description;
                        exists.DOfflineTime = model.mother.DOfflineTime;
                        exists.LDeliveryTime = model.mother.LDeliveryTime;
                        exists.LOfflineTime = model.mother.LOfflineTime;
                        exists.ProfilePhoto = model.mother.ProfilePhoto;
                        exists.Ratings = (model.mother.Ratings != null) ? model.mother.Ratings : 0;
                        resModel.mother = exists;
                        var dishes = Context.MotherDishes.Where(p => p.MotherId == exists.Id).ToList();
                        if (dishes != null)
                        {
                            foreach (var item in dishes)
                            {
                                int counter = 0;
                                foreach (var mitem in model.dish)
                                {
                                    if (mitem.DishId == item.DishId)
                                    {
                                        counter = 1;
                                        model.dish.Remove(mitem);
                                    }
                                }
                                if (counter == 0)
                                {
                                    item.IsDeleted = true;
                                }

                            }
                            Context.SaveChanges();
                            List<MotherDish> _list = new List<MotherDish>();
                            foreach (var item in model.dish)
                            {

                                MotherDish m = new MotherDish();
                                m.DishId = item.DishId;
                                m.MotherId = exists.Id;
                                m.Image = item.Image;
                                m.Limit = item.Limit;
                                m.IsDeleted = false;
                                m.IsSignatureDish = item.IsSignatureDish;
                                m.CreatedOn = DateTime.Now;
                                _list.Add(m);
                            }
                            Context.MotherDishes.AddRange(_list);
                            Context.SaveChanges();
                        }
                        else
                        {
                            List<MotherDish> _list = new List<MotherDish>();
                            foreach (var item in model.dish)
                            {

                                MotherDish m = new MotherDish();
                                m.DishId = item.DishId;
                                m.MotherId = exists.Id;
                                m.Image = item.Image;
                                m.Limit = item.Limit;
                                m.IsDeleted = false;
                                m.IsMainDish = true;
                                m.IsSignatureDish = item.IsSignatureDish;
                                m.CreatedOn = DateTime.Now;
                                _list.Add(m);
                            }
                            Context.MotherDishes.AddRange(_list);
                            Context.SaveChanges();
                        }
                        resModel.dish = model.dish;
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Mother Details updated successfully.";
                        res.Object = resModel;
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Mother doesnt exists";
                    }
                   
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Mother doesn't exists";
                }
                
            }
            catch(Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }

        ActionOutput<MotherModel> IMotherManager.GetMotherProfile(int Id)
        {
            ActionOutput<MotherModel> res = new ActionOutput<MotherModel>();
            MotherModel resModel = new MotherModel();
            try
            {
                var existss = Context.UserTbls.Where(p => p.Id == Id).FirstOrDefault();
                if (existss != null)
                {
                   
                    resModel.user = existss;
                    var exists = Context.MotherTbls.Where(p => p.UserId == existss.Id).FirstOrDefault();
                    if (exists != null)
                    {
                        
                        resModel.mother = exists;
                        var dishes = Context.MotherDishes.Where(p => p.MotherId == exists.Id).ToList();
                       
                       
                        resModel.dish = dishes;
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Mother Details fetched successfully.";
                        res.Object = resModel;
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Mother doesnt exists";
                    }

                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Mother doesn't exists";
                }

            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }

        ActionOutput<MotherScheduleModel> IMotherManager.GetMotherDailySchedule(int Id)
        {
            ActionOutput<MotherScheduleModel> res = new ActionOutput<MotherScheduleModel>();
            try
            {
                var sch = (from p in Context.MotherDailySchedules join m in Context.MotherTbls on p.MotherId equals (m.Id) where m.UserId == Id && p.Date == DateTime.Now select p).FirstOrDefault();
                if(sch==null)
                {
                    var MotherDetails = Context.MotherTbls.Where(p => p.UserId == Id).FirstOrDefault();
                    if(MotherDetails!=null)
                    {
                        MotherDailySchedule mds = new MotherDailySchedule();
                        mds.Availabilty = true;
                        mds.Date = DateTime.Now;
                        mds.Type = (int)AvailibiltyType.Both;
                        mds.MotherId = MotherDetails.Id;
                        Context.MotherDailySchedules.Add(mds);
                        Context.SaveChanges();

                        var dishes = Context.MotherDishes.Where(p => p.MotherId == MotherDetails.Id).ToList();
                        List<MotherDishDailySchedule> list = new List<MotherDishDailySchedule>();
                        foreach (var item in dishes)
                        {
                            MotherDishDailySchedule mdds = new MotherDishDailySchedule();
                            mdds.Availabilty = true;
                            mdds.Date = DateTime.Now;
                            mdds.MotherDishId = item.DishId;
                            mdds.Quantity = 15;
                            mdds.Type = (int)AvailibiltyType.Both;
                            list.Add(mdds);

                        }
                        Context.MotherDishDailySchedules.AddRange(list);
                        Context.SaveChanges();
                        res.Object = new MotherScheduleModel(mds);
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Daily Schedule Fetched Successfully.";
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Mother doesn't exists";
                    }
                }
                else
                {

                    var dishsch = (from p in Context.MotherDishDailySchedules join m in Context.MotherDishes on p.MotherDishId equals (m.Id) where m.MotherId == sch.MotherId && p.Date == DateTime.Now select p).ToList();
                    if(dishsch.Count<=0)
                    {
                        var dishes = Context.MotherDishes.Where(p => p.MotherId == sch.MotherId).ToList();
                        List<MotherDishDailySchedule> list = new List<MotherDishDailySchedule>();
                        foreach (var item in dishes)
                        {
                            MotherDishDailySchedule mdds = new MotherDishDailySchedule();
                            mdds.Availabilty = true;
                            mdds.Date = DateTime.Now;
                            mdds.MotherDishId = item.DishId;
                            mdds.Quantity = 15;
                            mdds.Type = (int)AvailibiltyType.Both;
                            list.Add(mdds);

                        }
                        Context.MotherDishDailySchedules.AddRange(list);
                        Context.SaveChanges();
                    }         
                    res.Object = new MotherScheduleModel(sch);
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Daily Schedule Fetched Successfully.";
                }
            }
            catch(Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput IMotherManager.UpdateMotherDailySchedule(MotherScheduleModel model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var sch = (from p in Context.MotherDailySchedules join m in Context.MotherTbls on p.MotherId equals (m.Id) where m.UserId == model.UserId && p.Date == DateTime.Now select p).FirstOrDefault();
                if (sch == null)
                {
                    var MotherDetails = Context.MotherTbls.Where(p => p.UserId == model.UserId).FirstOrDefault();
                    if (MotherDetails != null)
                    {
                        MotherDailySchedule mds = new MotherDailySchedule();
                        mds.Availabilty = model.Availabilty; ;
                        mds.Date = model.CreatedDate;
                        mds.Type = model.Type;
                        mds.MotherId = MotherDetails.Id;
                        Context.MotherDailySchedules.Add(mds);
                        Context.SaveChanges();
                        
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Daily Schedule Saved Successfully.";
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Mother doesn't exists";
                    }
                }
                else
                {
                    sch.Availabilty = model.Availabilty; ;
                    sch.Date = model.CreatedDate;
                    sch.Type = model.Type;
                    
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Daily Schedule Saved Successfully.";
                }
            }
            catch(Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }

        ActionOutput<List<MotherDishScheduleModel>> IMotherManager.GetMotherDishDailySchedule(int Id)
        {
            ActionOutput<List<MotherDishScheduleModel>> res = new ActionOutput<List<MotherDishScheduleModel>>();
            try
            {
                var dishsch = (from p in Context.MotherDishDailySchedules join m in Context.MotherDishes on p.MotherDishId equals (m.Id) join mo in Context.MotherTbls on m.MotherId equals(mo.Id) where mo.UserId == Id && p.Date == DateTime.Now select p).ToList();
                if (dishsch.Count <= 0)
                {
                    var MotherDetails = Context.MotherTbls.Where(p => p.UserId == Id).FirstOrDefault();
                    if (MotherDetails != null)
                    {
                        var dishes = Context.MotherDishes.Where(p => p.MotherId == MotherDetails.Id).ToList();
                        List<MotherDishDailySchedule> list = new List<MotherDishDailySchedule>();
                        foreach (var item in dishes)
                        {
                            MotherDishDailySchedule mdds = new MotherDishDailySchedule();
                            mdds.Availabilty = true;
                            mdds.Date = DateTime.Now;
                            mdds.MotherDishId = item.DishId;
                            mdds.Quantity = 15;
                            mdds.Type = (int)AvailibiltyType.Both;
                            list.Add(mdds);

                        }
                        Context.MotherDishDailySchedules.AddRange(list);
                        Context.SaveChanges();
                        var listt = (from p in Context.MotherDishDailySchedules join m in Context.MotherDishes on p.MotherDishId equals (m.Id) join mo in Context.MotherTbls on m.MotherId equals (mo.Id) where mo.UserId == Id && p.Date == DateTime.Now select new MotherDishScheduleModel(p)).ToList();
                        res.Object = listt;
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Mother's Daily Dish Scheduled fetched Successfully.";
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Mother doesn't exists";
                    }
                }
                else
                {
                    res.Object = dishsch.Select(p=>new MotherDishScheduleModel(p)).ToList();
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Mother's Daily Dish Scheduled fetched Successfully.";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput IMotherManager.UpdateMotherDishDailySchedule(List<MotherDishScheduleModel> model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var dishsch = (from p in Context.MotherDishDailySchedules join m in Context.MotherDishes on p.MotherDishId equals (m.Id) join mo in Context.MotherTbls on m.MotherId equals (mo.Id) where mo.UserId == model.FirstOrDefault().motherdish.MotherTbl.UserId && p.Date == DateTime.Now select p).ToList();
                if (dishsch.Count <= 0)
                {
                    var MotherDetails = Context.MotherTbls.Where(p => p.UserId == model.FirstOrDefault().motherdish.MotherTbl.UserId).FirstOrDefault();
                    if (MotherDetails != null)
                    {
                        List<MotherDishDailySchedule> list = new List<MotherDishDailySchedule>();
                        foreach (var item in model)
                        {
                            MotherDishDailySchedule mdds = new MotherDishDailySchedule();
                            mdds.Availabilty = item.Availabilty;
                            mdds.Date = item.Date;
                            mdds.MotherDishId = item.MotherDishId;
                            mdds.Quantity = item.Quantity;
                            mdds.Type = item.Type;
                            list.Add(mdds);
                        }
                        Context.MotherDishDailySchedules.AddRange(list);
                        Context.SaveChanges();
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Mother's Daily Dish Scheduled updated Successfully.";
                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Mother doesn't exists";
                    }
                }
                else
                {
                    foreach (var item in dishsch)
                    {
                        var partdata = model.Where(p => p.MotherDishId == item.MotherDishId).FirstOrDefault();
                        if (partdata != null)
                        {
                            item.Availabilty = partdata.Availabilty;
                            item.Date = partdata.Date;
                            item.Quantity = partdata.Quantity;
                            item.Type = partdata.Type;

                        }
                    }
                    Context.SaveChanges();
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Mother's Daily Dish Schedule updated Successfully.";
                }
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
