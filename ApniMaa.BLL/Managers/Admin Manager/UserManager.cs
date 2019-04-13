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
    public class UserManager : BaseManager, IUserManager
    {

        private readonly IEmailProvider emailProvider;
        private string Passhash = string.Empty;
        public UserManager()
        {
        }
        public UserManager(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;
        }

        #region Api Functions
        ActionOutput IUserManager.PhoneLogin(LoginModel model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.UserTbls.Where(p => p.Phone == model.ContactNo && (p.Status == (int)UserStatuss.Approved || p.Status != (int)UserStatuss.Subscribed)).FirstOrDefault();

                if (exists != null)
                {
                    //DEV
                    const string accountSid = "ACa8fc7a52b4ee46f45cfc07c1cccf5137";
                    const string authToken = "3c83a5093211b78584f34265691163dd";
                    //LIVE
                    //const string accountSid = "ACa8fc7a52b4ee46f45cfc07c1cccf5137";
                    //const string authToken = "3c83a5093211b78584f34265691163dd";
                    exists.OTP = UtilitiesHelp.GenerateOTP();
                    Context.SaveChanges();
                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        body: "OTP for ApniMaa app is ." + exists.OTP,
                        from: new Twilio.Types.PhoneNumber("+12013717756"),
                        to: new Twilio.Types.PhoneNumber("+91" + exists.Phone)
                    );
                    res.Status = ActionStatus.Successfull;
                    res.Message = "OTP Sent";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Contact No. not registered.";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<UserModel> IUserManager.AdminLogin(LoginModal model)
        {
            ActionOutput<UserModel> res = new ActionOutput<UserModel>();
            try
            {
                model.Password = UtilitiesHelp.EncryptPassword(model.Password, true);
                //var HashPass = EncryptionHelper.EncryptToByte(model.Password);
                var user = Context.UserTbls.Where(p => p.Email == model.UserName && p.Password == model.Password &&
                    p.RoleId == (int)UserRoleTypes.Admin).FirstOrDefault();

                if (user != null)
                {
                    //user.IsPermissonUpdated = false; Context.SaveChanges();

                    res.Status = ActionStatus.Successfull;
                    res.Message = "Login Success";
                    res.Object = new UserModel
                    {
                        UserID = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,

                    };

                }
                else
                {


                    res.Status = ActionStatus.Error;
                    res.Message = "User Does Not Exists";

                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<UserModel> IUserManager.OTPLogin(LoginModel model)
        {
            ActionOutput<UserModel> res = new ActionOutput<UserModel>();
            try
            {
                var exists = Context.UserTbls.Where(p => p.Phone == model.ContactNo && (p.Status == (int)UserStatuss.Approved || p.Status != (int)UserStatuss.Subscribed)).FirstOrDefault();

                if (exists != null)
                {
                    if (exists.OTP == model.OTP)
                    {

                        res.Object = new UserModel(exists);
                        res.Status = ActionStatus.Successfull;
                        res.Message = "Login Successfull";
                    }
                    else
                    {
                        res.Message = "Invalid OTP";
                        res.Status = ActionStatus.Error;
                    }
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Contact No. not registered.";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<UserModel> IUserManager.AuthenticateUser(LoginModel model)
        {
            ActionOutput<UserModel> res = new ActionOutput<UserModel>();
            try
            {
                var HashPass = UtilitiesHelp.EncryptPassword(model.ContactNo, true);
                var exists = Context.UserTbls.Where(p => p.Phone == model.ContactNo && p.Password == HashPass && (p.Status == (int)UserStatuss.Approved || p.Status != (int)UserStatuss.Subscribed)).FirstOrDefault();

                if (exists != null)
                {
                    res.Object = new UserModel(exists);
                    res.Status = ActionStatus.Successfull;
                    res.Message = "Login Successfull";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "User doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<Guest> IUserManager.GenrateGuestId()
        {
            ActionOutput<Guest> res = new ActionOutput<Guest>();
            try
            {
                Guest _guest = new Guest();
                Context.Guests.Add(_guest);
                Context.SaveChanges();
                res.Object = _guest;
                res.Status = ActionStatus.Successfull;
                res.Message = "Welcome Guest";
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<UserModel> IUserManager.RegisterUser(UserModel model)
        {
            ActionOutput<UserModel> res = new ActionOutput<UserModel>();
            try
            {
                var Phone_Exists = Context.UserTbls.Where(p => p.Phone == model.Phone && p.Status != (int)UserStatuss.Deleted).Any();
                if (!Phone_Exists)
                {

                    UserTbl _user = new UserTbl();
                    _user.FirstName = model.FirstName;
                    _user.LastName = model.LastName;
                    _user.Phone = model.Phone;
                    _user.Email = model.Email;
                    _user.Password = UtilitiesHelp.EncryptPassword(model.Password, true);
                    _user.RoleId = model.RoleId;
                    _user.Address = model.Address;
                    _user.City = model.City;
                    _user.Latitute = model.Latitute;
                    _user.Longitute = model.Longitute;
                    _user.Province = model.Province;
                    _user.OTP = UtilitiesHelp.GenerateOTP();
                    _user.Status = (int)UserStatuss.Registered;
                    _user.CreatedOn = DateTime.Now;
                    Context.UserTbls.Add(_user);
                    Context.SaveChanges();

                    //DEV
                    const string accountSid = "ACa8fc7a52b4ee46f45cfc07c1cccf5137";
                    const string authToken = "3c83a5093211b78584f34265691163dd";
                    //LIVE
                    //const string accountSid = "ACa8fc7a52b4ee46f45cfc07c1cccf5137";
                    //const string authToken = "3c83a5093211b78584f34265691163dd";

                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        body: "OTP for ApniMaa app is ." + _user.OTP,
                        from: new Twilio.Types.PhoneNumber("+12013717756"),
                        to: new Twilio.Types.PhoneNumber("+91" + _user.Phone)
                    );
                    res.Object = new UserModel(_user);
                    res.Status = ActionStatus.Successfull;
                    res.Message = "User Registered successfully";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "Phone Number already registered.";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Errpr Occurred";
            }

            return res;
        }
        ActionOutput<UserModel> IUserManager.VeifyOTP(OTPModel model)
        {
            ActionOutput<UserModel> res = new ActionOutput<UserModel>();
            try
            {
                var user = Context.UserTbls.Where(p => p.Id == model.Id && p.Status == (int)UserStatuss.Registered).FirstOrDefault();
                if (user != null)
                {
                    if (user.OTP == model.OTP.ToString())
                    {

                        if (user.RoleId == (int)UserRoleTypes.Mother)
                        {
                            user.Status = (int)UserStatuss.Verified;
                            MotherTbl _mother = new MotherTbl();
                            _mother.ApplicationNo = UtilitiesHelp.GenerateApplicationNo();
                            _mother.UserId = user.Id;
                            _mother.WalletAmount = 0;
                            Context.MotherTbls.Add(_mother);
                            Context.SaveChanges();
                            res.Object = new UserModel(user);
                            res.Status = ActionStatus.Successfull;


                            res.Message = "Mother Verified successfully. Wait for Admin approval.";
                        }
                        else
                        {
                            user.Status = (int)UserStatuss.Approved;
                            Context.SaveChanges();
                            res.Object = new UserModel(user);
                            res.Status = ActionStatus.Successfull;
                            res.Message = "User Verified successfully";
                        }


                    }
                    else
                    {
                        res.Status = ActionStatus.Error;
                        res.Message = "Incorrect OTP.";
                    }


                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "User doesnt exists.";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Errpr Occurred";
            }

            return res;
        }
        /// <summary>
        /// Check session is valid or not 
        /// </summary>
        UserModel IUserManager.IsSessionValid(string sessionId)
        {
            var guid = new Guid(sessionId);
            var found = Context.UserLoginSessions.FirstOrDefault(p => p.UserLoginSessionID == guid && p.SessionExpired == false);
            if (found != null) return new UserModel(found.UserTbl);
            else return null;
        }
        /// This method is used to validate the user session id
        /// </summary>
        UserModel IUserManager.ValidateUserSession(CreateNewSession SessionModel)
        {
            var session = Context.UserLoginSessions.Where(o => !o.SessionExpired && o.LoggedOutTime == null && o.UniqueDeviceId.Equals(SessionModel.UniqueDeviceId)
              && SessionModel.sessionId == o.UserLoginSessionID && o.UserTbl.Status != (int)UserStatuss.Deleted && o.UserTbl.Status != (int)UserStatuss.Blocked).FirstOrDefault();

            if (session != null)
            {
                session.IsActive = true;
                session.LastActivityTime = DateTime.UtcNow;
                session.UniqueDeviceId = SessionModel.UniqueDeviceId;
                session.DeviceToken = SessionModel.DeviceToken;
                session.DeviceType = SessionModel.DeviceType;
                session.LoggedOutTime = null;
                session.TokenVOIP = SessionModel.TokenVOIP;
                Context.SaveChanges();
            }
            if (session != null) return new UserModel(session.UserLoginSessionID, session.UserTbl);
            else return null;
        }
        /// <summary>
        /// Create new session during login 
        /// </summary>
        string IUserManager.CreateSession(CreateNewSession SessionModel)
        {
            var found = SessionModel;
            if (found != null)
            {
                //Context.UserLoginSessions.Where(p => p.UserId == model.UserId).ToList().ForEach(p => { p.SessionExpired = true; });
                Context.UserLoginSessions.Where(p => p.UserId == SessionModel.UserID).ToList().ForEach(p => { p.SessionExpired = true; p.DeviceToken = null; p.LoggedOutTime = DateTime.UtcNow; p.IsActive = false; });
                //Context.UserLoginSessions.Where(p => p.UniqueDeviceId == SessionModel.UniqueDeviceId).ToList().ForEach(p => { p.SessionExpired = true; p.DeviceToken = null; p.LoggedOutTime = DateTime.UtcNow; p.IsActive = false; });
                Context.SaveChanges();

                var session = new UserLoginSession()
                {
                    LoggedInTime = DateTime.Now,
                    SessionExpired = false,
                    UserId = found.UserID,
                    UserLoginSessionID = Guid.NewGuid(),
                    UniqueDeviceId = SessionModel.UniqueDeviceId,
                    DeviceToken = SessionModel.DeviceToken,
                    DeviceType = SessionModel.DeviceType,
                    LastActivityTime = DateTime.UtcNow,
                    IsActive = true

                };
                Context.UserLoginSessions.Add(session);
                Context.SaveChanges();
                return session.UserLoginSessionID.ToString();
            }
            else return string.Empty;
        }
        #endregion

        #region Get ALl Modules Authorization
        public IList<ModulesModel> GetAllModulesAtAuthentication(int userId)
        {
            var moduleListModel = new List<ModulesModel>();
            var modulesPermissons = Context.UserAssignedModules.Where(x => x.AdminUserID == userId).ToList().Select(x => x.ModuleId);
            var modules = Context.Modules.ToList().Where(c => modulesPermissons.Contains(c.ModuleId));
            if (modules.Count() > 0)
            {
                moduleListModel = modules.Select(x => new ModulesModel(x)).ToList();

            }
            return moduleListModel;
        }
        #endregion

        #region UserManagement
        PagingResult<UserModel> IUserManager.GetUserPagedList(PagingModel model)
        {
            var result = new PagingResult<UserModel>();
            model.SortBy = model.SortBy == null ? "CreatedOn" : model.SortBy;
            model.SortOrder = model.SortOrder == null ? "Desc" : model.SortOrder;
            var query = Context.UserTbls.Where(p => p.RoleId != (int)UserRoleTypes.Admin).AsEnumerable().OrderBy(model.SortBy + " " + model.SortOrder).AsQueryable();

            if (model.UserRole != null)
            {
                query = query.Where(p => p.RoleId == model.UserRole);
            }
            //if (UserStatus != 0)
            //{
            //    query = query.Where(p => p.Status == UserStatus);
            //}

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(z =>
                    (z.FirstName.ToLower() + " " + z.LastName.ToLower()).Contains(model.Search.ToLower()) ||
                    z.Email.ToString().Contains(model.Search.ToLower()));
            }
            var list = query.Skip(model.PageNo - 1).Take(model.RecordsPerPage)
               .ToList().Select(x => new UserModel(x)).ToList();
            //int SerialNumber = 1;

            var StateList = (from state in Context.Provinces select state).ToList();
            var CityList = (from city in Context.Cities select city).ToList();
            foreach (var item in list)
            {

                if (item.Province != null)
                {
                    item.StateName = StateList.Where(p => p.Id == item.Province).Select(p => p.Name).FirstOrDefault();
                }
                if (item.City != null)
                {
                    item.CityName = CityList.Where(p => p.Id == item.City).Select(p => p.Name).FirstOrDefault();
                }
            }

            list = list

           .ToList().Select(x => x).ToList();
            result.List = list;
            result.Status = ActionStatus.Successfull;
            result.Message = "User List";
            result.TotalCount = query.Count();
            return result;
        }
        ActionOutput IUserManager.SetUserStatus(long UserId, int StatusId)
        {
            try
            {
                var _user = (from user in Context.UserTbls where user.Id == UserId select user).FirstOrDefault();
                if (_user != null)
                {
                    _user.Status = StatusId;

                    Context.SaveChanges();
                    var message = "User Status Successfully Updated";
                    return new ActionOutput
                    {
                        Message = message,
                        Status = ActionStatus.Successfull
                    };

                }
                else
                {
                    return new ActionOutput
                    {
                        Message = "User doesn't exists",
                        Status = ActionStatus.Error
                    };
                }
            }
            catch
            {
                return new ActionOutput
                {
                    Message = "Some Error Occured",
                    Status = ActionStatus.Error
                };
            }
        }
        ActionOutput IUserManager.UpdateUserProfile(UserModel model)
        {
            ActionOutput res = new ActionOutput();
            try
            {
                var exists = Context.UserTbls.Where(p => p.Id == model.UserID).FirstOrDefault();
                if (exists != null)
                {
                    exists.LastName = model.LastName;
                    exists.Latitute = model.Latitute;
                    exists.Longitute = model.Longitute;
                    exists.Province = model.Province;
                    exists.Address = model.Address;
                    exists.City = model.City;
                    exists.Email = model.Email;
                    exists.FirstName = model.FirstName;
                    Context.SaveChanges();
                    res.Status = ActionStatus.Successfull;
                    res.Message = "User Details updated successfully.";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "User doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        ActionOutput<UserModel> IUserManager.GetUserProfile(int Id)
        {
            ActionOutput<UserModel> res = new ActionOutput<UserModel>();
            try
            {
                var exists = Context.UserTbls.Where(p => p.Id == Id).FirstOrDefault();
                if (exists != null)
                {
                    res.Object = new UserModel(exists);
                    res.Status = ActionStatus.Successfull;
                    res.Message = "User Details fetched successfully.";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "User doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }
        #endregion

        ActionOutput<UserDetailModel> IUserManager.GetUserDetails(int Id)
        {
            ActionOutput<UserDetailModel> res = new ActionOutput<UserDetailModel>();
            try
            {
                var exists = Context.UserTbls.Where(p => p.Id == Id).FirstOrDefault();

                if (exists != null)
                {
                    res.Object = new UserDetailModel(exists);
                    res.Status = ActionStatus.Successfull;
                    res.Message = "User Details fetched successfully.";
                }
                else
                {
                    res.Status = ActionStatus.Error;
                    res.Message = "User doesn't exists";
                }
            }
            catch (Exception ex)
            {
                res.Status = ActionStatus.Error;
                res.Message = "Some Error Occurred";
            }
            return res;
        }

        ActionOutput IUserManager.UpdateUserDetails(UserDetailModel model)
        {
            ActionOutput res = new ActionOutput();
            var Data = Context.UserTbls.Where(p => p.Id == model.UserID).FirstOrDefault();
            var Exists = Context.UserTbls.Where(p => p.Id != model.UserID && p.Email == model.Email.Trim()).FirstOrDefault();

            if (Exists == null)
            {
                Data.Email = model.Email;
                Data.FirstName = model.FirstName;
                Data.LastName = model.LastName;
                Context.SaveChanges();

                return new ActionOutput
                {
                    Status = ActionStatus.Successfull,
                    Message = "Updated Successfully"
                };
            }
            else
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "Email already exists."
                };
            }
            //}
            //catch (Exception ex)
            //{
            //    res.Status = ActionStatus.Error;
            //    res.Message = "Some Error Occurred";
            //}
            return res;
        }
        ActionOutput IUserManager.AddDishForMother(AddDishForMotherModel model)
        {

            var GetMotherID = Context.MotherTbls.Where(a => a.UserId == model.MotherID).FirstOrDefault().Id;
            var ExistingDish = Context.MotherDishes.Where(a => a.MotherId == GetMotherID && 
                a.DishId == model.DishId && a.IsDeleted == false
                ).FirstOrDefault();

            if(ExistingDish != null)
            {
                return new ActionOutput
                {
                    Status = ActionStatus.Error,
                    Message = "Dish Already Exists."
                };
            }
            string FileName = "";

            if (model.DishImage != null)
            {
                FileName = UtilitiesHelp.SavePostedFile(AppFolderName.DishImage, model.DishImage);
            }

            var MotherDish = new MotherDish
            {
                MotherId = GetMotherID,
                DishId = model.DishId,
                Image = FileName,
                Limit = 100,
                Price = 200,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                IsMainDish = false,
                IsSignatureDish = false
            };

            Context.MotherDishes.Add(MotherDish);
            Context.SaveChanges();

            
            //    return new ActionOutput
            //    {
            //        Status = ActionStatus.Error,
            //        Message = "This Part already exists."
            //    };

            return new ActionOutput
            {
                Status = ActionStatus.Successfull,
                Message = "Dish Added Successfully."
            };
        }
        List<MotherDishModel> IUserManager.GetMotherDishList(int MotherId)
        {
            var GetMotherID = Context.MotherTbls.Where(a => a.UserId == MotherId).FirstOrDefault().Id;
            var result = new List<MotherDishModel>();
            var query = Context.MotherDishes.Where(z => z.IsDeleted == false && z.MotherId == GetMotherID);
            var list = query.ToList().Select(x => new MotherDishModel(x)).ToList();
            result = list;
            return result;
        }
        ActionOutput IUserManager.DeleteDish(int dishid)
        {
            var data = Context.MotherDishes.Where(a => a.Id == dishid && a.IsDeleted == false).FirstOrDefault();

            if (data!= null)
            {
                data.IsDeleted = true;
            }
            Context.SaveChanges();

            return new ActionOutput
            {
                Status = ActionStatus.Successfull,
                Message = "Dish Deleted Successfully."
            };

        }


    }
}
