using OzzieLeads.BLL.Interfaces;
using OzzieLeads.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using OzzieLeads.DAL;
using OzzieLeads.BLL.Common;
using System.Threading;

namespace OzzieLeads.BLL.Managers
{
    public class UserManager : BaseManager, IUserManager
    {

        private string Passhash = string.Empty;

        UserModel IUserManager.RegisterUser(registerModel model)
        {
            Passhash = Crypto.Hash(model.Password);

            User data = new User();
            data.FirstName = model.Name;
            //data. = model.PhoneNo;
            data.Password = Passhash;
            //data.Email = "test@gmail.com";
            data.UserType = 1;
            data.CreatedAt = DateTime.Now;
            Context.Users.Add(data);
            Context.SaveChanges();

            return new UserModel(data);
        }


        /// <summary>
        /// Check session is valid or not 
        /// </summary>
        UserModel IUserManager.IsSessionValid(string sessionId)
        {
            var guid = new Guid(sessionId);
            var found = Context.UserLoginSessions.FirstOrDefault(p => p.UserLoginSessionID == guid && p.SessionExpired == false);
            if (found != null) return new UserModel(found.User);
            else return null;
        }


        /// This method is used to validate the user session id
        /// </summary>
        UserModel IUserManager.ValidateUserSession(CreateNewSession SessionModel)
        {
            var session = Context.UserLoginSessions.Where(o => !o.SessionExpired && o.LoggedOutTime == null && o.UniqueDeviceId.Equals(SessionModel.UniqueDeviceId)
              && SessionModel.sessionId == o.UserLoginSessionID && o.User.IsDeleted == false).FirstOrDefault();

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
            if (session != null) return new UserModel(session.UserLoginSessionID, session.User);
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


        ActionOutput<UserDetails> IUserManager.AdminLogin(LoginModal model)
        {
            model.Password = Utilities.EncryptPassword(model.Password, true);
            var user = Context.AdminUsers.Where(x => x.Email == model.UserName && x.Password == model.Password && x.IsDeleted == false).FirstOrDefault();
            if (user != null)
            {
                //user.IsPermissonUpdated = false; Context.SaveChanges();
                return new ActionOutput<UserDetails>
                {
                    Status = ActionStatus.Successfull,
                    Object = new UserDetails
                    {
                        UserID = user.AdminUserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        IsAuthenticated = true,
                        UserEmail = user.Email,
                        //IsSuperAdmin = user.IsSuperAdmin.GetValueOrDefault(false)
                    }
                };
            }
            else
            {
                return new ActionOutput<UserDetails>
                {
                    Status = ActionStatus.Error,
                    Message = "User Does Not Exists"
                };
            }

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

        //private readonly IEmailTemplateManager _emailTemplateManager;

        //public UserManager(IEmailTemplateManager emailTemplateManager)
        //{
        //    _emailTemplateManager = emailTemplateManager;
        //}

        //string IUserManager.GetWelcomeMessage()
        //{
        //    return "Welcome To Base Project Demo";
        //}

        //PagingResult<UserListingModel> IUserManager.GetUserPagedList(PagingModel model)
        //{
        //    var result = new PagingResult<UserListingModel>();
        //    var query = Context.Users.Where(z => !z.IsDeleted).OrderBy(model.SortBy + " " + model.SortOrder);
        //    if (!string.IsNullOrEmpty(model.Search))
        //    {
        //        query = query.Where(z => z.FirstName.Contains(model.Search) || z.LastName.Contains(model.Search) || z.Email.Contains(model.Search));
        //    }
        //    var list = query
        //       .Skip(model.PageNo - 1).Take(model.RecordsPerPage)
        //       .ToList().Select(x => new UserListingModel(x)).ToList();
        //    result.List = list;
        //    result.Status = ActionStatus.Successfull;
        //    result.Message = "User List";
        //    result.TotalCount = query.Count();
        //    return result;
        //}

        //ActionOutput IUserManager.UpdateUserDetails(UserModel userDetails)
        //{
        //    var user = Context.Users.Where(z => z.UserID == userDetails.UserId && !z.IsDeleted).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Error,
        //            Message = "User Not Exist."
        //        };
        //    }
        //    var existngUser = Context.Users.Where(z => z.Email.Trim().ToLower() == userDetails.Email.Trim().ToLower() && z.UserID != userDetails.UserId).FirstOrDefault();
        //    if (existngUser != null)
        //    {
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Error,
        //            Message = "This email-id already exists for another user."
        //        };
        //    }
        //    else
        //    {
        //        user.Email = userDetails.Email.Trim().ToLower();
        //        user.FirstName = userDetails.FirstName;
        //        user.LastName = userDetails.LastName;
        //        Context.SaveChanges();
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Successfull,
        //            Message = "User Details Updated Successfully."
        //        };
        //    }
        //}

        //ActionOutput IUserManager.AddUserDetails(AddUserModel userDetails)
        //{
        //    var existngUser = Context.Users.Where(z => z.Email.Trim().ToLower() == userDetails.Email.Trim().ToLower()).FirstOrDefault();
        //    if (existngUser != null)
        //    {
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Error,
        //            Message = "This email-id already exists for another user."
        //        };
        //    }
        //    else
        //    {
        //        Context.Users.Add(new User
        //        {
        //            FirstName = userDetails.FirstName,
        //            LastName = userDetails.LastName,
        //            Email = userDetails.Email.Trim().ToLower(),
        //            Password = userDetails.Password,
        //            CreatedAt = DateTime.Now,
        //            UserType = 2
        //        });
        //        Context.SaveChanges();
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Successfull,
        //            Message = "User Added Successfully."
        //        };
        //    }
        //}

        //UserModel IUserManager.GetUserDetailsByUserId(int userId)
        //{
        //    var user = Context.Users.Where(z => z.UserID == userId && !z.IsDeleted).FirstOrDefault();
        //    if (user == null)
        //        return null;
        //    else
        //        return new UserModel(user);
        //}

        //ActionOutput IUserManager.DeleteUser(int userId)
        //{
        //    var user = Context.Users.Where(z => z.UserID == userId).FirstOrDefault();
        //    if (user == null)
        //    {
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Error,
        //            Message = "User Not Exist."
        //        };
        //    }
        //    else
        //    {
        //        user.IsDeleted = true;
        //        user.DeletedOn = DateTime.Now;
        //        Context.SaveChanges();
        //        return new ActionOutput
        //        {
        //            Status = ActionStatus.Successfull,
        //            Message = "User Deleted Successfully."
        //        };
        //    }
        //}

        


        //ForgotPasswordRequestModel IUserManager.AddForgotPasswordRequest(ForgotPasswordModel model, bool isAdmin = false)
        //{
        //    if (isAdmin)
        //    {
        //        var adminUser = Context.AdminUsers.Where(x => x.Email == model.UserName).FirstOrDefault();
        //        if (adminUser != null)
        //        {
        //            var requests = Context.ForgotPasswordRequests.Where(x => x.AdminUserId == adminUser.AdminUserId && x.IsActive == true).ToList();
        //            if (requests.Count > 0)
        //            {
        //                requests.ForEach(x => x.IsActive = false);
        //            }

        //            ForgotPasswordRequest newRequest = new ForgotPasswordRequest();
        //            newRequest.AdminUserId = adminUser.AdminUserId;
        //            newRequest.OTPCode = Guid.NewGuid().ToString();
        //            newRequest.IsActive = true;
        //            newRequest.RequestedDate = DateTime.Now;
        //            newRequest.ValidTill = newRequest.RequestedDate.AddDays(7);
        //            newRequest.IsAdmin = isAdmin;
        //            Context.ForgotPasswordRequests.Add(newRequest);

        //            Context.SaveChanges();

        //            //new Thread(() =>
        //            //{
        //            //    Thread.CurrentThread.IsBackground = true;
        //            //    Emailer.SendAdminForgotPasswordOTPEmail(adminUser, newRequest);
        //            //}).Start();

        //            try
        //            {
        //                var userDetails = new UserModel() { FirstName = adminUser.FirstName, LastName = adminUser.LastName, Email = adminUser.Email };
        //                _emailTemplateManager.ForgotPassword(userDetails, newRequest.OTPCode);
        //                return new ForgotPasswordRequestModel { UserId = newRequest.AdminUserId.Value, OTPCode = newRequest.OTPCode, IsActive = newRequest.IsActive, RequestedDate = newRequest.RequestedDate };
        //            }
        //            catch (Exception e) { Console.Write(e); return null; }

        //            //return new ForgotPasswordRequestModel { UserId = newRequest.AdminUserId.Value, OTPCode = newRequest.OTPCode, IsActive = newRequest.IsActive, RequestedDate = newRequest.RequestedDate };
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        var user = Context.Users.Where(x => x.Email == model.UserName).FirstOrDefault();
        //        if (user != null)
        //        {
        //            var requests = Context.ForgotPasswordRequests.ToList();
        //            if (requests.Count > 0)
        //            {
        //                requests.ForEach(x => x.IsActive = false);
        //            }

        //            ForgotPasswordRequest newRequest = new ForgotPasswordRequest();
        //            newRequest.UserId = user.UserID;
        //            newRequest.OTPCode = Guid.NewGuid().ToString();
        //            newRequest.IsActive = true;
        //            newRequest.RequestedDate = DateTime.Now;
        //            newRequest.ValidTill = newRequest.RequestedDate.AddDays(7);
        //            newRequest.IsAdmin = isAdmin;
        //            Context.ForgotPasswordRequests.Add(newRequest);
        //            Context.SaveChanges();

        //            //new Thread(() =>
        //            //{
        //            //    Thread.CurrentThread.IsBackground = true;
        //            //   // Emailer.SendForgotPasswordOTPEmail(user, newRequest);
        //            //}).Start();

        //            //return new ForgotPasswordRequestModel { UserId = newRequest.UserId.Value, OTPCode = newRequest.OTPCode, IsActive = newRequest.IsActive, RequestedDate = newRequest.RequestedDate };
        //            try
        //            {
        //                var userDetails = new UserModel() { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
        //                _emailTemplateManager.ForgotPassword(userDetails, newRequest.OTPCode);
        //                return new ForgotPasswordRequestModel { UserId = newRequest.UserId.Value, OTPCode = newRequest.OTPCode, IsActive = newRequest.IsActive, RequestedDate = newRequest.RequestedDate };
        //            }
        //            catch (Exception e) { Console.Write(e); return null; }
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}


        //int IUserManager.GetForgotPasswordTokenDetails(string token)
        //{
        //    var forgotpassword = Context.ForgotPasswordRequests.FirstOrDefault(x => x.OTPCode.Equals(token));

        //    if (forgotpassword != null && DateTime.UtcNow <= forgotpassword.ValidTill && forgotpassword.IsActive)
        //    {
        //        return (int)AccountToken.Valid;
        //    }
        //    else
        //    {
        //        return (int)AccountToken.Expired;
        //    }

        //}


        //ActionOutput IUserManager.ResetPassword(ResetPassword model)
        //{
        //    var forgotpassword = Context.ForgotPasswordRequests.FirstOrDefault(x => x.OTPCode.Equals(model.Code));

        //    var action = new ActionOutput();
        //    if (forgotpassword == null)
        //    {
        //        action.Message = "ForgetLinkExpired";//WebResource.Content("ForgetLinkExpired");
        //        action.Status = ActionStatus.Error;
        //        return action;
        //    }
        //    if (forgotpassword.IsActive )
        //    {
        //        var user = Context.Users.FirstOrDefault(x => x.UserID == forgotpassword.UserId);
        //        if (user != null)
        //        {
        //            user.Password = Utilities.EncryptPassword(model.NewPassword, true);
        //            action.Message = "PasswordReset";
        //            action.Status = ActionStatus.Successfull;
        //            forgotpassword.IsActive = false;
        //            //forgotpassword.IsDeleted = true;
        //            Context.SaveChanges();
        //        }
        //        return action;
        //    }
        //    else
        //    {
        //        action.Message = "ForgetLinkExpired";//WebResource.Content("ForgetLinkExpired");
        //        action.Status = ActionStatus.Error;
        //        return action;
        //    }
        //}


        

        ///// <summary>
        ///// Create new session during login 
        ///// </summary>
        //string IUserManager.CreateSession(CreateNewSession SessionModel)
        //{
        //    var found = SessionModel;
        //    if (found != null)
        //    {
        //        //Context.UserLoginSessions.Where(p => p.UserId == model.UserId).ToList().ForEach(p => { p.SessionExpired = true; });
        //        Context.UserLoginSessions.Where(p => p.UserId == SessionModel.UserID).ToList().ForEach(p => { p.SessionExpired = true; p.DeviceToken = null; p.LoggedOutTime = DateTime.UtcNow; p.IsActive = false; });
        //        //Context.UserLoginSessions.Where(p => p.UniqueDeviceId == SessionModel.UniqueDeviceId).ToList().ForEach(p => { p.SessionExpired = true; p.DeviceToken = null; p.LoggedOutTime = DateTime.UtcNow; p.IsActive = false; });
        //        Context.SaveChanges();

        //        var session = new UserLoginSession()
        //        {
        //            LoggedInTime = DateTime.Now,
        //            SessionExpired = false,
        //            UserId = found.UserID,
        //            UserLoginSessionId = Guid.NewGuid(),
        //            UniqueDeviceId = SessionModel.UniqueDeviceId,
        //            DeviceToken = SessionModel.DeviceToken,
        //            DeviceType = SessionModel.DeviceType,
        //            LastActivityTime = DateTime.UtcNow,
        //            IsActive = true

        //        };
        //        Context.UserLoginSessions.Add(session);
        //        Context.SaveChanges();
        //        return session.UserLoginSessionId.ToString();
        //    }
        //    else return string.Empty;
        //}

        ///// <summary>
        ///// Check session is valid or not 
        ///// </summary>
        //UserModel IUserManager.IsSessionValid(string sessionId)
        //{
        //    var guid = new Guid(sessionId);
        //    var found = Context.UserLoginSessions.FirstOrDefault(p => p.UserLoginSessionId == guid && p.SessionExpired == false);
        //    if (found != null) return new UserModel(found.User);
        //    else return null;
        //}

    }


}
