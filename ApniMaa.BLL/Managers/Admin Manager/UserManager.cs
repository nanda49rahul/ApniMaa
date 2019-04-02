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
                    _user.Password = UtilitiesHelp.EncryptPassword(model.Password,true);
                    _user.RoleId = model.RoleId;
                    _user.Address = model.Address;
                    _user.City = model.City;
                    _user.Latitute = model.Latitute;
                    _user.Longitute = model.Longitute;
                    _user.Province = model.Province;
                    _user.OTP = UtilitiesHelp.GenerateOTP();
                    _user.Status = (int)UserStatuss.Registered;
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

        public UserManager()
        {

        }
        public UserManager(IEmailProvider emailProvider)
        {
            this.emailProvider = emailProvider;

        }

        //public ActionOutput AddUserDetails(UserModel model)
        //{
        //    var existingRec = Context.UserTbls.FirstOrDefault(x => x.Email.ToLower() == model.Email.ToLower());
        //    if (existingRec != null)
        //    {
        //        return new ActionOutput
        //        {
        //            Message = "This email Id has been already taken.",
        //            Status = ActionStatus.Error
        //        };
        //    }
        //    else
        //    {
        //        var user = Context.UserTbls.Add(new UserTbl
        //        {
        //            //City = model.City,
        //            //Country = model.Country,
        //            Email = model.Email,
        //            FirstName = model.FirstName,
        //            IsApproved = true,
        //            IsDeleted = false,
        //            LastName = model.LastName,
        //            Password = EncryptionHelper.EncryptToByte(model.Password),
        //            //Phone = model.Phone,
        //            //PostalCode = model.PostalCode,
        //            //Province = model.Province,
        //            //RoleID = model.RoleID,
        //            // StreetAddress = model.StreetAddress
        //        });

        //        var userRole = new UserRole()
        //        {
        //            FKUserId = user.UserId,
        //            RoleId = (int)UserRoleTypes.Driver,
        //            CreatedDate = DateTime.UtcNow,
        //            IsActive = true,
        //        };

        //        user.UserRoles.Add(userRole);

        //        var obj = new UserContactDetail()
        //        {
        //            FKUserId = user.UserId,
        //            Phone = model.Phone,
        //            StreetAddress = model.StreetAddress,
        //            ProvinceId = model.Province,
        //            CityId = model.City,
        //            CountryId = model.Country,
        //            PostalCode = model.PostalCode
        //        };

        //        user.UserContactDetails.Add(obj);

        //        Context.SaveChanges();
        //        dynamic expando = new ExpandoObject();
        //        expando.Name = user.FirstName + " " + user.LastName;
        //        expando.userName = user.Email;
        //        expando.password = model.Password;
        //        expando.link = Common.Config.BaseUrl;
        //        emailProvider.Send(user.Email, "", TemplateTypes.SignUpEmail, expando, "");
        //        return new ActionOutput
        //        {
        //            Message = "User details saved successfully.",
        //            Status = ActionStatus.Successfull
        //        };
        //    }
        //}

        //public PagingResult<UserModel> GetUserPagedList(PagingModel model)
        //{
        //    var result = new PagingResult<UserModel>();
        //    model.SortBy = model.SortBy == null ? "CreatedDate" : model.SortBy;
        //    model.SortOrder = model.SortOrder == null ? "Desc" : model.SortOrder;
        //    var query = Context.Users.AsEnumerable().OrderBy(model.SortBy + " " + model.SortOrder);
        //    if (!string.IsNullOrEmpty(model.Search))
        //    {
        //        query = query.Where(z => ((z.Email != null && z.Email.ToLower().Contains(model.Search.ToLower())) || (z.LastName != null && (z.FirstName.ToLower() + " " + z.LastName.ToLower()).Contains(model.Search.ToLower()))
        //           || (z.FirstName.ToLower()).Contains(model.Search.ToLower())));
        //    }
        //    var list = query
        //       .Skip((model.PageNo - 1) * model.RecordsPerPage).Take(model.RecordsPerPage)
        //       .ToList().Select(x => new UserModel(x)).ToList();
        //    result.List = list;
        //    result.Status = ActionStatus.Successfull;
        //    result.Message = "User List";
        //    result.TotalCount = query.Count();
        //    return result;
        //}

        //public UserModel GetUserByUserId(int userId)
        //{
        //    var user = Context.Users.Find(userId);
        //    return new UserModel(user) ?? null;
        //}

        //public ActionOutput UpdateUserDetails(UserModel model)
        //{
        //    var duplicateRec = Context.Users.FirstOrDefault(x => x.Email.ToLower() == model.Email.ToLower() && x.UserId != model.UserID);
        //    if (duplicateRec != null)
        //    {
        //        return new ActionOutput
        //        {
        //            Message = "This email Id is associated with another user",
        //            Status = ActionStatus.Error
        //        };
        //    }
        //    var existingRec = Context.Users.FirstOrDefault(x => x.Email == model.Email && x.UserId == model.UserID);
        //    if (existingRec == null)
        //    {
        //        return new ActionOutput
        //        {
        //            Message = "This user doesn't exist.",
        //            Status = ActionStatus.Error
        //        };
        //    }
        //    else
        //    {
        //        //existingRec.City = model.City;
        //        //existingRec.Country = model.Country;
        //        existingRec.Email = model.Email;
        //        existingRec.FirstName = model.FirstName;
        //        existingRec.IsActive = true;
        //        existingRec.IsDeleted = false;
        //        existingRec.LastName = model.LastName;
        //        existingRec.Password = EncryptionHelper.EncryptToByte(model.Password);
        //        //existingRec.Phone = model.Phone;
        //        //existingRec.PostalCode = model.PostalCode;
        //        //existingRec.Province = model.Province;
        //        //existingRec.RoleID = model.RoleID;
        //        //existingRec.StreetAddress = model.StreetAddress;


        //        var userContactDetail = existingRec.UserContactDetails.FirstOrDefault();

        //        userContactDetail.Phone = model.Phone;
        //        userContactDetail.StreetAddress = model.StreetAddress;
        //        userContactDetail.ProvinceId = model.Province;
        //        userContactDetail.CityId = model.City;
        //        userContactDetail.CountryId = model.Country;
        //        userContactDetail.PostalCode = model.PostalCode;


        //        Context.SaveChanges();
        //        return new ActionOutput
        //        {
        //            Message = "User details updated successfully.",
        //            Status = ActionStatus.Successfull
        //        };
        //    }
        //}

        //public ActionOutput DeleteUser(int userId)
        //{
        //    var user = Context.Users.Find(userId);
        //    if (user != null)
        //    {
        //        user.IsDeleted = true;
        //        user.IsActive = false;
        //        Context.SaveChanges();
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Successfull,
        //            Message = "User has been deleted successfully"
        //        };
        //    }
        //    else
        //    {
        //        return new ActionOutput
        //        {
        //            Message = "This user doesn't exist.",
        //            Status = ActionStatus.Error
        //        };
        //    }

        //}

        //public ActionOutput<UserInfo> LoginUser(LoginModal userDetails)
        //{
        //    var password = EncryptionHelper.EncryptToByte(userDetails.Password);

        //    var data = new ActionOutput<UserInfo>();
        //    var user = Context.Users.FirstOrDefault(z => z.Email == userDetails.UserName && z.Password == password && !z.IsDeleted);
        //    if (user != null && user.IsActive == true)
        //    {
        //        var userRole = user.UserRoles.FirstOrDefault().RoleId;


        //        if (userRole == (int)UserRoleTypes.FleetAdmin || userRole == (int)UserRoleTypes.Employee)
        //        {
        //            data.Status = ActionStatus.Error;
        //            data.Message = "Invalid Credentials! Please check your credentials and login again!";
        //            return data;
        //        }

        //        data.Status = ActionStatus.Successfull;
        //        data.Object = new UserInfo
        //        {
        //            FullName = user.FirstName + " " + user.LastName,
        //            UserId = user.UserId,
        //            Email = user.Email,
        //            UserType = user.UserRoles.FirstOrDefault().RoleId,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            IsAuthenticated = true,
        //            ProfileImage = user.Image != null ? "/Documents/ProfileImages/0/" + user.Image : "/Content/images/img.jpg",
        //            RoleId = user.UserRoles.FirstOrDefault().RoleId
        //        };

        //    }
        //    else if (user != null && user.IsActive == false)
        //    {
        //        data.Status = ActionStatus.Error;
        //        data.Message = "Your account has been de-activated!";
        //    }
        //    else
        //    {
        //        data.Status = ActionStatus.Error;
        //        data.Message = "Invalid Credentials! Please check your credentials and login again!";
        //    }
        //    return data;

        //}

        //public ActionOutput ValidateUserByEmail(string email, string token)
        //{
        //    var user = Context.Users.FirstOrDefault(m => m.Email.ToLower() == email && m.IsDeleted == false);
        //    if (user != null)
        //    {
        //        user.ForgetPassword = true;
        //        Context.SaveChanges();
        //        dynamic obj = new ExpandoObject();
        //        obj.link = Common.Config.BaseUrl + "/Home/ResetPassword?token=" + token;
        //        obj.Name = user.FirstName + " " + user.LastName;
        //        emailProvider.Send(user.Email, "", TemplateTypes.ForgetPassword, obj, "");
        //        return new ActionOutput { Message = "Password reset link has been sent to your email", Status = ActionStatus.Successfull };
        //    }
        //    else
        //    {
        //        return new ActionOutput { Message = "This email doesn't exist in our records, Please check the email", Status = ActionStatus.Error };
        //    }
        //}

        //public ActionOutput ChangePassword(GenerateNewPasswordModel model)
        //{
        //    var user = Context.Users.FirstOrDefault(m => m.Email.ToLower() == model.UserMail);
        //    if (user != null && user.ForgetPassword == true)
        //    {
        //        user.Password = EncryptionHelper.EncryptToByte(model.NewPassword);
        //        user.ForgetPassword = false;
        //        Context.SaveChanges();
        //        dynamic obj = new ExpandoObject();
        //        obj.link = Common.Config.BaseUrl;
        //        obj.Name = user.FirstName + " " + user.LastName;
        //        emailProvider.Send(user.Email, "", TemplateTypes.ResetPassword, obj, "");
        //        return new ActionOutput { Message = "Password has been changed successfully", Status = ActionStatus.Successfull };
        //    }
        //    else
        //    {
        //        return new ActionOutput { Message = "You can't perform this action now, please contact help desk", Status = ActionStatus.Error };
        //    }
        //}

        //public UserModel GetUserDetails(UserInfo user, int loginType)
        //{
        //    var UserDetail = new UserModel();
        //    if (loginType == 1)
        //    {
        //        var User = Context.ContactMasters.Find(user.UserId);
        //        UserDetail.FirstName = User.FirstName;
        //        UserDetail.LastName = User.LastName;
        //        UserDetail.IsActive = User.IsActive;
        //        UserDetail.RoleID = User.ContactRole;
        //        UserDetail.Email = User.Email;
        //        UserDetail.Phone = User.PhoneNumber;
        //        UserDetail.CreatedDate = User.CreatedDate.ToString();
        //        UserDetail.UserID = User.Id;
        //        if (!string.IsNullOrEmpty(User.Image))
        //            UserDetail.ImagePath = "/Documents/ProfileImages/0/" + User.Image;
        //    }
        //    else
        //    {
        //        var User = Context.Users.Find(user.UserId);
        //        UserDetail.FirstName = User.FirstName;
        //        UserDetail.LastName = User.LastName;
        //        UserDetail.IsActive = User.IsActive;
        //        UserDetail.RoleID = User.UserRoles.FirstOrDefault().RoleId;
        //        UserDetail.Email = User.Email;
        //        UserDetail.Phone = User.UserContactDetails.FirstOrDefault().Phone;
        //        UserDetail.City = User.UserContactDetails.FirstOrDefault().CityId;
        //        UserDetail.Country = User.UserContactDetails.FirstOrDefault().CountryId;
        //        UserDetail.Province = User.UserContactDetails.FirstOrDefault().ProvinceId;
        //        UserDetail.StreetAddress = User.UserContactDetails.FirstOrDefault().StreetAddress;
        //        UserDetail.CreatedDate = User.CreatedDate.ToString();
        //        UserDetail.UserID = User.UserId;
        //        UserDetail.PostalCode = User.UserContactDetails.FirstOrDefault().PostalCode;
        //        if (!string.IsNullOrEmpty(User.Image))
        //            UserDetail.ImagePath = "/Documents/ProfileImages/0/" + User.Image;
        //    }
        //    return UserDetail;
        //}

        //public ActionOutput UpdateUserProfile(UserModel model)
        //{
        //    var ImagePath = "";
        //    if (model.UserID > 0)
        //    {
        //        if (model.City > 0)
        //        {
        //            var user = Context.Users.Find(model.UserID);
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;
        //            user.Email = model.Email;
        //            //user.Phone = model.Phone;
        //            //user.Country = model.Country;
        //            //user.City = model.City;
        //            //user.Province = model.Province;

        //            var userContactDetail = user.UserContactDetails.FirstOrDefault();

        //            userContactDetail.Phone = model.Phone;
        //            userContactDetail.StreetAddress = model.StreetAddress;
        //            userContactDetail.ProvinceId = model.Province;
        //            userContactDetail.CityId = model.City;
        //            userContactDetail.CountryId = model.Country;
        //            userContactDetail.PostalCode = model.PostalCode;

        //            if (model.UserImage != null)
        //            {
        //                if (user.Image != null)
        //                    UtilitiesHelp.DeletePostedFile(user.Image, "ProfileImages", 0);

        //                var image = UtilitiesHelp.SavePostedFile("ProfileImages", model.UserImage, 0);
        //                ImagePath = "/Documents/ProfileImages/0/" + image;
        //                user.Image = image;
        //            }
        //            Context.SaveChanges();
        //        }
        //        else
        //        {
        //            var user = Context.ContactMasters.Find(model.UserID);
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;
        //            user.Email = model.Email;
        //            user.PhoneNumber = model.Phone;
        //            if (model.UserImage != null)
        //            {
        //                if (user.Image != null)
        //                    UtilitiesHelp.DeletePostedFile(user.Image, "ProfileImages", 0);

        //                var image = UtilitiesHelp.SavePostedFile("ProfileImages", model.UserImage, 0);
        //                ImagePath = "/Documents/ProfileImages/0/" + image;
        //                user.Image = image;
        //            }
        //            Context.SaveChanges();
        //        }
        //        return new ActionOutput
        //        {
        //            Message = ImagePath,
        //            Status = ActionStatus.Successfull
        //        };
        //    }
        //    else
        //    {
        //        return new ActionOutput
        //        {
        //            Message = "Error",
        //            Status = ActionStatus.Error
        //        };
        //    }
        //}

        //public ActionOutput UpdateUserPassword(string Old, string New, string Confirm, UserInfo user, int loginType)
        //{
        //    if (loginType == 1)
        //    {
        //        var User = Context.Users.Find(user.UserId);
        //        var password = EncryptionHelper.DecryptFromByte(User.Password);
        //        if (Old == password)
        //        {
        //            User.Password = EncryptionHelper.EncryptToByte(New);
        //            Context.SaveChanges();
        //            return new ActionOutput
        //            {
        //                Message = "Password Updated successfully",
        //                Status = ActionStatus.Successfull
        //            };
        //        }
        //        else
        //        {
        //            return new ActionOutput
        //            {
        //                Message = "Old Password is not correct",
        //                Status = ActionStatus.Error
        //            };
        //        }
        //    }
        //    else
        //    {
        //        var User = Context.Users.Find(user.UserId);
        //        var password = EncryptionHelper.DecryptFromByte(User.Password);
        //        if (Old == password)
        //        {
        //            User.Password = EncryptionHelper.EncryptToByte(New);
        //            Context.SaveChanges();
        //            return new ActionOutput
        //            {
        //                Message = "Password Updated successfully",
        //                Status = ActionStatus.Successfull
        //            };
        //        }
        //        else
        //        {
        //            return new ActionOutput
        //            {
        //                Message = "Old Password is not correct",
        //                Status = ActionStatus.Error
        //            };
        //        }
        //    }
        //}

        //public ActionOutput UpdateFirmPassword(string Old, string New, string Confirm, UserInfo user, int loginType)
        //{
        //    if (loginType == 1)
        //    {
        //        var User = Context.ContactMasters.Find(user.UserId);
        //        var password = EncryptionHelper.DecryptFromByte(User.Password);
        //        if (Old == password)
        //        {
        //            User.Password = EncryptionHelper.EncryptToByte(New);
        //            Context.SaveChanges();
        //            return new ActionOutput
        //            {
        //                Message = "Password Updated successfully",
        //                Status = ActionStatus.Successfull
        //            };
        //        }
        //        else
        //        {
        //            return new ActionOutput
        //            {
        //                Message = "Old Password is not correct",
        //                Status = ActionStatus.Error
        //            };
        //        }
        //    }
        //    else
        //    {
        //        var User = Context.Users.Find(user.UserId);
        //        var password = EncryptionHelper.DecryptFromByte(User.Password);
        //        if (Old == password)
        //        {
        //            User.Password = EncryptionHelper.EncryptToByte(New);
        //            Context.SaveChanges();
        //            return new ActionOutput
        //            {
        //                Message = "Password Updated successfully",
        //                Status = ActionStatus.Successfull
        //            };
        //        }
        //        else
        //        {
        //            return new ActionOutput
        //            {
        //                Message = "Old Password is not correct",
        //                Status = ActionStatus.Error
        //            };
        //        }
        //    }
        //}

        //public List<SelectListItem> GetSelectListUsers(int? UserId = 0)
        //{
        //    var users = Context.Users.Where(x => x.IsActive == true).AsEnumerable();
        //    return users.Select(x => new SelectListItem { Text = x.FirstName + " " + x.LastName + "(" + x.Email + ")", Value = x.UserId.ToString() }).ToList();
        //}

        ////public ActionOutput BulkUpload(BulkImportModel model)
        ////{
        ////    if (model.FilePath != "")
        ////    {
        ////        var savedFile = UtilitiesHelp.MoveImportFile("BulkImport", model.FilePath);

        ////        BulkImport _bulk = new BulkImport();
        ////        _bulk.FileName = savedFile;
        ////        _bulk.OriginalName = model.FileName;
        ////        _bulk.CreatedDate = DateTime.Now;
        ////        _bulk.Status = false;
        ////        _bulk.Before_Firms = GetFirmCount();
        ////        _bulk.After_Firms = GetFirmCount();
        ////        _bulk.Before_CaseFiles = GetCaseFileCount();
        ////        _bulk.After_CaseFiles = GetCaseFileCount();
        ////        _bulk.BulkType = (int)BulkType.Firms;
        ////        Context.BulkImports.Add(_bulk);
        ////        Context.SaveChanges();

        ////        using (DbContextTransaction dbTran = Context.Database.BeginTransaction())
        ////        {
        ////            try
        ////            {
        ////                if (model.Excel_File != null && model.Excel_File.ContentLength > 0)
        ////                {
        ////                    //ExcelDataReader works on binary excel file
        ////                    Stream stream = model.Excel_File.InputStream;
        ////                    //We need to written the Interface.
        ////                    IExcelDataReader reader = null;
        ////                    if (model.Excel_File.FileName.EndsWith(".xls"))
        ////                    {
        ////                        //reads the excel file with .xls extension
        ////                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
        ////                    }
        ////                    else if (model.Excel_File.FileName.EndsWith(".xlsx"))
        ////                    {
        ////                        //reads excel file with .xlsx extension
        ////                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        ////                    }
        ////                    else
        ////                    {
        ////                        //Shows error if uploaded file is not Excel file
        ////                        //("File", "This file format is not supported");
        ////                        return null;
        ////                    }
        ////                    //treats the first row of excel file as Coluymn Names
        ////                    reader.IsFirstRowAsColumnNames = true;
        ////                    //Adding reader data to DataSet()
        ////                    DataSet result = reader.AsDataSet();
        ////                    int counter = 0;
        ////                    var CityMaster = Context.Cities.Where(p => p.IsActive == true).ToList();
        ////                    var ProvinceMaster = Context.Provinces.Where(p => p.IsActive == true).ToList();
        ////                    while (reader.Read())
        ////                    {

        ////                        dynamic expando = new ExpandoObject();
        ////                        if (counter == 0)
        ////                        {
        ////                            counter++;
        ////                        }
        ////                        else
        ////                        {
        ////                            //reader.GetString(0);
        ////                            var firm = Context.Firms.Add(new Firm
        ////                            {
        ////                                CityID = CityMaster.Where(p => p.Name.ToLower() == reader.GetString(3).ToLower()).Select(p => p.Id).FirstOrDefault(),
        ////                                CountryID = ProvinceMaster.Where(p => p.Name.ToLower() == reader.GetString(2).ToLower()).Select(p => p.CountryID).FirstOrDefault(),
        ////                                CoverageType = (reader.GetString(5).ToLower() == "firm protect") ? (int)CoverageType.LISCFirmProtect : (int)CoverageType.LISCFileProtect,
        ////                                Email = reader.GetString(8),
        ////                                EnquiryDate = DateTime.Now,
        ////                                UpdatedDate = DateTime.Now.Date,
        ////                                FirmDescription = "Law Firm",
        ////                                FirmName = reader.GetString(0),
        ////                                IsProspects = false,
        ////                                MeetingNotes = "",
        ////                                MeetingTypeID = 1,
        ////                                Phone = reader.GetString(7),
        ////                                CreatedDate = DateTime.UtcNow,
        ////                                PostalCode = reader.GetString(4),
        ////                                PrimaryContact = reader.GetString(6),
        ////                                ProvinceID = ProvinceMaster.Where(p => p.Name.ToLower() == reader.GetString(2).ToLower()).Select(p => p.Id).FirstOrDefault(),
        ////                                StreetAddress = reader.GetString(1),
        ////                                IsActive = true,
        ////                                YearEstablished = reader.GetString(9),
        ////                                ActiveFilesReceived = null,
        ////                                ApplicationReceived = null,
        ////                                IndicationLetterSent = null,
        ////                                PolicyIssued = null,
        ////                                QuoteAccepted = null,
        ////                                QuoteSent = null,
        ////                                RenewalNotified = null,
        ////                                RenewalPackageAccepted = null,
        ////                                RenewalPackageSent = null

        ////                            });
        ////                            var Branch = Context.BranchMasters.Add(new BranchMaster
        ////                            {
        ////                                BranchName = "Head Office",
        ////                                BranchNotes = "Head Office",
        ////                                CityID = firm.CityID,
        ////                                CountryID = firm.CountryID,
        ////                                CreatedDate = DateTime.Now,
        ////                                FirmID = firm.Id,
        ////                                IsActive = true,
        ////                                PostalCode = firm.PostalCode,
        ////                                ProvinceID = firm.ProvinceID,
        ////                                StreetAddress = firm.StreetAddress
        ////                            });

        ////                            var existingContact = Context.ContactMasters.FirstOrDefault(x => x.Email.ToLower() == firm.Email.ToLower());
        ////                            if (existingContact != null)
        ////                            {
        ////                                return new ActionOutput
        ////                                {
        ////                                    Message = "This email already exists with another firm/prospects.",
        ////                                    Status = ActionStatus.Error
        ////                                };
        ////                            }
        ////                            else
        ////                            {
        ////                                var name = firm.PrimaryContact.Split(' ');
        ////                                var firstname = "";
        ////                                var lastname = "";
        ////                                int counters = 1;
        ////                                foreach (var item in name)
        ////                                {
        ////                                    if (counters == 1)
        ////                                    {
        ////                                        firstname = item;
        ////                                        counters++;
        ////                                    }
        ////                                    else if (counter == 2)
        ////                                    {
        ////                                        lastname = item;
        ////                                        counters++;
        ////                                    }
        ////                                    else
        ////                                    {
        ////                                        lastname = lastname + " " + item;
        ////                                    }
        ////                                }
        ////                                var contact = Context.ContactMasters.Add(new ContactMaster
        ////                               {
        ////                                   ContactRole = (int)ContactRole.Administrator,
        ////                                   CreatedDate = DateTime.UtcNow,
        ////                                   Email = firm.Email,
        ////                                   FirmID = firm.Id,
        ////                                   FirstName = firstname,
        ////                                   LastName = lastname,
        ////                                   IsActive = true,
        ////                                   Password = EncryptionHelper.EncryptToByte(UtilitiesHelp.GeneratePassword(6)),
        ////                                   PhoneNumber = firm.Phone,
        ////                                   Title = "User",
        ////                                   IsApproved = (int)ApprovalStatus.Pending,
        ////                                   BranchID = Branch.Id
        ////                               });
        ////                                expando.Password = EncryptionHelper.DecryptFromByte(contact.Password);
        ////                            }
        ////                            Context.SaveChanges();
        ////                            var EndorsementList = policyManager.GetEndorsementsList().Select(p => new SelectListItem { Text = p.Text.Split('–')[0], Value = p.Value }).ToList();
        ////                            var ReducedStandardLimitTypeList = policyManager.GetReducedStandardLimitTypeList();
        ////                            var ReducedStandardLimitTypes = "";
        ////                            var Endorsements = "";
        ////                            if (reader.GetString(17) != "")
        ////                            {
        ////                                var endo = reader.GetString(17).Split(',');
        ////                                foreach (var item in endo)
        ////                                {
        ////                                    foreach (var items in EndorsementList)
        ////                                    {
        ////                                        if (item.ToLower() == items.Text.Trim().ToLower())
        ////                                        {
        ////                                            if (Endorsements == "")
        ////                                            {
        ////                                                Endorsements = items.Value;
        ////                                            }
        ////                                            else
        ////                                            {
        ////                                                Endorsements = Endorsements + "," + items.Value;
        ////                                            }
        ////                                            break;
        ////                                        }
        ////                                    }
        ////                                }
        ////                            }
        ////                            if (reader.GetString(22) != "")
        ////                            {
        ////                                var endo = reader.GetString(22).Split(',');
        ////                                foreach (var item in endo)
        ////                                {
        ////                                    foreach (var items in ReducedStandardLimitTypeList)
        ////                                    {
        ////                                        if (item.ToLower() == items.Text.Trim().ToLower())
        ////                                        {
        ////                                            if (ReducedStandardLimitTypes == "")
        ////                                            {
        ////                                                ReducedStandardLimitTypes = items.Value;
        ////                                            }
        ////                                            else
        ////                                            {
        ////                                                ReducedStandardLimitTypes = ReducedStandardLimitTypes + "," + items.Value;
        ////                                            }
        ////                                            break;
        ////                                        }
        ////                                    }
        ////                                }
        ////                            }
        ////                            var policy = Context.PolicyDocuments.Add(new PolicyDocument
        ////                            {
        ////                                AddedBy = model.UserID,
        ////                                AddedOn = DateTime.UtcNow,
        ////                                //FileName = savedFile,
        ////                                FirmID = firm.Id,
        ////                                //OriginalName = model.FileName,
        ////                                CommencementDate = Convert.ToDateTime(reader.GetString(11)),
        ////                                StandardLimit = reader.GetDecimal(12),
        ////                                StandardPremiumRate = reader.GetDecimal(13),
        ////                                SupplimentalLimit = reader.GetDecimal(14),
        ////                                ProductType = (reader.GetString(5).ToLower() == "firm protect") ? (int)CoverageType.LISCFirmProtect : (int)CoverageType.LISCFileProtect,
        ////                                PolicyNumber = reader.GetString(10),
        ////                                ReducedStandardLimit = reader.GetDecimal(15),
        ////                                ReducedSupplimentalLimit = reader.GetDecimal(16),
        ////                                ReducedStandardLimitType = ReducedStandardLimitTypes,
        ////                                Endorsments = Endorsements,
        ////                                LiscPolicyNumber = reader.GetString(10),

        ////                                PreDiscoveryBefore = reader.GetDecimal(23),
        ////                                PreDiscoveryAfter = reader.GetDecimal(24),

        ////                                PostDiscoveryPreMedBefore = reader.GetDecimal(25),
        ////                                PostDiscoveryPreMedAfter = reader.GetDecimal(26),

        ////                                PostMedPreTrialBefore = reader.GetDecimal(27),
        ////                                PostMedPreTrialAfter = reader.GetDecimal(28),

        ////                                IsApproved = (int)PolicyStatus.Approved,
        ////                                //PolicyFileName = savedPolicyFile,
        ////                                // PolicyOriginalName = model.PolicyFileName,
        ////                                //SchFileName = savedSchFile,
        ////                                // SchOriginalName = model.SchFileName,
        ////                                // EndFileName = savedEndFile,
        ////                                // EndOriginalName = model.EndFileName,
        ////                                //AmountOmegaApproval = savedLimitFile,
        ////                                //PercentOmegaApproval = savedMedmalFile,
        ////                                MedmalPercent = (reader.GetString(18) == "") ? 0 : reader.GetDecimal(18),
        ////                                LimitAmount = (reader.GetString(19) == "") ? 0 : reader.GetDecimal(19),
        ////                                TotalCap = (reader.GetString(20) == "") ? 0 : reader.GetDecimal(20),
        ////                                IndividualCap = (reader.GetString(21) == "") ? 0 : reader.GetDecimal(21)
        ////                            });
        ////                            //expando.Name = firm.PrimaryContact + " (@" + firm.FirmName + ")";
        ////                            //expando.Email = firm.Email;
        ////                            //expando.link = Common.Config.FirmUrl;
        ////                            //emailProvider.Send(firm.Email, "", TemplateTypes.Prospect, expando, "");
        ////                        }

        ////                        //Sending result data to View



        ////                    }

        ////                    reader.Close();
        ////                    Context.SaveChanges();
        ////                    _bulk.After_Firms = GetFirmCount();
        ////                    _bulk.After_CaseFiles = GetCaseFileCount();
        ////                    _bulk.Status = true;
        ////                    Context.SaveChanges();
        ////                    dbTran.Commit();
        ////                    return new ActionOutput
        ////                    {
        ////                        Message = "Done !",
        ////                        Status = ActionStatus.Successfull
        ////                    };
        ////                }
        ////                else
        ////                {
        ////                    return new ActionOutput
        ////                    {
        ////                        Message = "Empty File !",
        ////                        Status = ActionStatus.Error
        ////                    };
        ////                }
        ////            }
        ////            catch (DbEntityValidationException ex)
        ////            {
        ////                dbTran.Rollback();
        ////                return new ActionOutput
        ////                {
        ////                    Message = "Error :" + ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message),
        ////                    Status = ActionStatus.Error
        ////                };
        ////            }
        ////        }
        ////    }
        ////    else
        ////    {
        ////        return new ActionOutput
        ////        {
        ////            Message = "Please select a file !",
        ////            Status = ActionStatus.Error
        ////        };
        ////    }
        ////}

        ////public ActionOutput BulkUploadCases(BulkImportModel model)
        ////{
        ////    if (model.FilePath != "")
        ////    {
        ////        var savedFile = UtilitiesHelp.MoveImportFile("BulkImport", model.FilePath);

        ////        BulkImport _bulk = new BulkImport();
        ////        _bulk.FileName = savedFile;
        ////        _bulk.OriginalName = model.FileName;
        ////        _bulk.CreatedDate = DateTime.Now;
        ////        _bulk.Status = false;
        ////        _bulk.Before_Firms = GetFirmCount();
        ////        _bulk.After_Firms = GetFirmCount();
        ////        _bulk.Before_CaseFiles = GetCaseFileCount();
        ////        _bulk.After_CaseFiles = GetCaseFileCount();
        ////        _bulk.BulkType = (int)BulkType.Cases;
        ////        Context.BulkImports.Add(_bulk);
        ////        Context.SaveChanges();

        ////        using (DbContextTransaction dbTran = Context.Database.BeginTransaction())
        ////        {
        ////            try
        ////            {
        ////                if (model.Excel_File1 != null && model.Excel_File1.ContentLength > 0)
        ////                {
        ////                    //ExcelDataReader works on binary excel file
        ////                    Stream stream = model.Excel_File1.InputStream;
        ////                    //We need to written the Interface.
        ////                    IExcelDataReader reader = null;
        ////                    if (model.Excel_File1.FileName.EndsWith(".xls"))
        ////                    {
        ////                        //reads the excel file with .xls extension
        ////                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
        ////                    }
        ////                    else if (model.Excel_File1.FileName.EndsWith(".xlsx"))
        ////                    {
        ////                        //reads excel file with .xlsx extension
        ////                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        ////                    }
        ////                    else
        ////                    {
        ////                        //Shows error if uploaded file is not Excel file
        ////                        //("File", "This file format is not supported");
        ////                        return null;
        ////                    }
        ////                    //treats the first row of excel file as Coluymn Names
        ////                    reader.IsFirstRowAsColumnNames = true;
        ////                    //Adding reader data to DataSet()
        ////                    DataSet result = reader.AsDataSet();
        ////                    int counter = 0;
        ////                    var CityMaster = Context.Cities.Where(p => p.IsActive == true).ToList();
        ////                    var ProvinceMaster = Context.Provinces.Where(p => p.IsActive == true).ToList();
        ////                    var ClaimMaster = Context.ClaimTypes.Where(p => p.IsActive == true).ToList();
        ////                    var ActionList = typeManager.GetTypeList(MasterType.ActionType);
        ////                    var LitigationList = typeManager.GetTypeList(MasterType.Other);

        ////                    while (reader.Read())
        ////                    {

        ////                        dynamic expando = new ExpandoObject();
        ////                        if (counter == 0)
        ////                        {
        ////                            counter++;
        ////                        }
        ////                        else
        ////                        {

        ////                            var LiscActions = "";
        ////                            if (reader.GetString(10) != "")
        ////                            {
        ////                                var endo = reader.GetString(10).Split(',');
        ////                                foreach (var item in endo)
        ////                                {
        ////                                    foreach (var items in ActionList)
        ////                                    {
        ////                                        if (item.ToLower() == items.Text.Trim().ToLower())
        ////                                        {
        ////                                            if (LiscActions == "")
        ////                                            {
        ////                                                LiscActions = items.Value;
        ////                                            }
        ////                                            else
        ////                                            {
        ////                                                LiscActions = LiscActions + "," + items.Value;
        ////                                            }
        ////                                            break;
        ////                                        }
        ////                                    }
        ////                                }
        ////                            }
        ////                            var FirmName = reader.GetString(0);
        ////                            var FirmDetails = Context.Firms.Where(p => p.FirmName.Trim().ToLower() == FirmName.Trim().ToLower()).FirstOrDefault();
        ////                            if (FirmDetails == null)
        ////                            {
        ////                                dbTran.Rollback();
        ////                                return new ActionOutput
        ////                                {
        ////                                    Message = "Firm doesn't exists",
        ////                                    Status = ActionStatus.Error
        ////                                };
        ////                            }
        ////                            var BranchDetails = Context.BranchMasters.Where(p => p.FirmID == FirmDetails.Id && p.IsActive == true).OrderBy(p => p.CreatedDate).FirstOrDefault();
        ////                            var LawyerList = contactManager.LawyerList(FirmDetails.Id);
        ////                            var LawyerName = reader.GetString(1);
        ////                            var LawyerDetails = LawyerList.Where(p => p.Text.Trim().ToLower() == LawyerName.Trim().ToLower()).FirstOrDefault();
        ////                            if (LawyerDetails == null)
        ////                            {
        ////                                var contact = Context.ContactMasters.Create();
        ////                                contact.BranchID = BranchDetails.Id;
        ////                                contact.ContactRole = (int)ContactRole.Lawyer;
        ////                                contact.Email = reader.GetString(16);
        ////                                contact.FirmID = FirmDetails.Id;
        ////                                contact.FirstName = reader.GetString(1).Split(' ')[0];
        ////                                contact.LastName = (reader.GetString(1).Split(' ')[1] != null) ? reader.GetString(1).Split(' ')[1] : "";
        ////                                contact.Password = EncryptionHelper.EncryptToByte("123456");
        ////                                contact.PhoneNumber = "";
        ////                                contact.Title = "";
        ////                                contact.CreatedDate = DateTime.UtcNow;
        ////                                contact.YearOfCall = "";
        ////                                contact.IsActive = true;
        ////                                contact.IsApproved = (int)ApprovalStatus.Approved;
        ////                                contact.AddedByLisc = model.UserID;
        ////                                Context.ContactMasters.Add(contact);
        ////                                Context.SaveChanges();
        ////                                LawyerDetails = new SelectListItem();
        ////                                LawyerDetails.Value = contact.Id.ToString();
        ////                                LawyerDetails.Text = contact.FirstName.ToString() + " " + contact.LastName.ToString();

        ////                            }

        ////                            var PolicyDetails = Context.PolicyDocuments.Where(p => p.FirmID.Value == FirmDetails.Id && p.CommencementDate <= DateTime.Now).FirstOrDefault();
        ////                            var cases = Context.CaseDetails.Add(new CaseDetail
        ////                            {
        ////                                ActionType = LiscActions,
        ////                                ClaimantFirstName = reader.GetString(2),
        ////                                ClaimantLastName = reader.GetString(3),
        ////                                LawyerID = Convert.ToInt32(LawyerDetails.Value),
        ////                                LitigationState = LitigationList.Where(p => p.Text == reader.GetString(7)).Select(p => Convert.ToInt32(p.Value)).FirstOrDefault(),
        ////                                StandardLimit = PolicyDetails.StandardLimit.ToString(),
        ////                                StandardLimitRate = PolicyDetails.StandardPremiumRate,
        ////                                SuplementalRate = 0,
        ////                                LossDate = reader.GetDateTime(5),
        ////                                PolicyHolderClientNo = (reader.GetString(13) != null) ? reader.GetString(13) : "",
        ////                                PolicyHolderRefNo = (reader.GetString(14) != null) ? reader.GetString(14) : "",
        ////                                ProvinceID = ProvinceMaster.Where(p => p.Name.ToLower() == reader.GetString(4).ToLower()).Select(p => p.Id).FirstOrDefault(),
        ////                                SubClaimType = (reader.GetString(9) != null) ? (ClaimMaster.Where(p => p.Name == reader.GetString(9)).Select(p => p.Id).FirstOrDefault()) : reader.GetInt32(9),
        ////                                StatementDate = reader.GetDateTime(6),
        ////                                FirmID = FirmDetails.Id,
        ////                                CreatedDate = DateTime.UtcNow,
        ////                                IsActive = true,
        ////                                IsApproved = (int)ApprovalStatus.Approved,
        ////                                ApprovalMessage = "Imported",
        ////                                Status = 4,
        ////                                ClaimID = ClaimMaster.Where(p => p.Name == reader.GetString(8)).Select(p => p.Id).FirstOrDefault(),
        ////                                AddedByLisc = model.UserID,
        ////                                TrialDate = reader.GetDateTime(12),
        ////                                InsurerName = (reader.GetString(11) != null) ? reader.GetString(11) : "",
        ////                                IsCaseTransfered = (reader.GetString(15) != "Y") ? true : false,
        ////                                Products = "Case Addition - Standard"
        ////                            });
        ////                            var lastValue = Context.CaseDetails.OrderByDescending(p => p.Id).FirstOrDefault();
        ////                            int value = 1;
        ////                            if (lastValue != null)
        ////                            {
        ////                                value = lastValue.Id + 1;
        ////                            }
        ////                            cases.LiscRefrenceID = UtilitiesHelp.GenerateLiscRefID(FirmName, value);
        ////                            //reader.GetString(0);
        ////                        }
        ////                    }

        ////                    reader.Close();
        ////                    Context.SaveChanges();
        ////                    _bulk.After_Firms = GetFirmCount();
        ////                    _bulk.After_CaseFiles = GetCaseFileCount();
        ////                    _bulk.Status = true;
        ////                    Context.SaveChanges();
        ////                    dbTran.Commit();
        ////                    return new ActionOutput
        ////                    {
        ////                        Message = "Done !",
        ////                        Status = ActionStatus.Successfull
        ////                    };
        ////                }
        ////                else
        ////                {
        ////                    return new ActionOutput
        ////                    {
        ////                        Message = "Empty File !",
        ////                        Status = ActionStatus.Error
        ////                    };
        ////                }
        ////            }
        ////            catch (DbEntityValidationException ex)
        ////            {
        ////                dbTran.Rollback();
        ////                return new ActionOutput
        ////                {
        ////                    Message = "Error :" + ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message),
        ////                    Status = ActionStatus.Error
        ////                };
        ////            }
        ////        }
        ////    }
        ////    else
        ////    {
        ////        return new ActionOutput
        ////        {
        ////            Message = "Please select a file !",
        ////            Status = ActionStatus.Error
        ////        };
        ////    }
        ////}

        //public int GetFirmCount()
        //{
        //    return Context.Firms.Where(p => p.MeetingTypeID != 19 || p.MeetingTypeID != 20 || p.MeetingTypeID != 21 || p.MeetingTypeID != 22 || p.MeetingTypeID != 23).Count();
        //}

        //public int GetCaseFileCount()
        //{
        //    return Context.CaseDetails.Where(p => p.Status <= 4).Count();
        //}

        #region UserManagement
        PagingResult<UserModel> IUserManager.GetUserPagedList(PagingModel model)
        {
            var result = new PagingResult<UserModel>();
            model.SortBy = model.SortBy == null ? "Id" : model.SortBy;
            model.SortOrder = model.SortOrder == null ? "Desc" : model.SortOrder;
            var query = Context.UserTbls.Where(p => p.RoleId != (int)UserRoleTypes.Admin).AsEnumerable().OrderBy(model.SortBy + " " + model.SortOrder).AsQueryable();

            //if (UserRole != 0)
            //{
            //    query = query.Where(p => p.RoleId == UserRole);
            //}
            //if (UserStatus != 0)
            //{
            //    query = query.Where(p => p.Status == UserStatus);
            //}

            if (!string.IsNullOrEmpty(model.Search))
            {
                query = query.Where(z => z.FirstName.ToLower().Contains(model.Search.ToLower()) || z.Email.ToString().Contains(model.Search.ToLower()) || (z.Phone != null && z.Phone.ToString().Contains(model.Search.ToLower())) || (z.LastName != null && z.LastName.ToString().Contains(model.Search.ToLower())));
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
    }
}
