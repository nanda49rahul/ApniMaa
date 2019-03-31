using ApniMaa.BLL.Models;
using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApniMaa.BLL.Interfaces
{
    public interface IUserManager
    {
        UserModel IsSessionValid(string sessionId);
        ActionOutput<UserModel> RegisterUser(UserModel model);
        ActionOutput<UserModel> VeifyOTP(OTPModel model);
        UserModel ValidateUserSession(CreateNewSession SessionModel);

        IList<ModulesModel> GetAllModulesAtAuthentication(int userId);
        string CreateSession(CreateNewSession SessionModel);
        ActionOutput<UserModel> AuthenticateUser(LoginModel model);
        ActionOutput SetUserStatus(long userId, int statusId);
        PagingResult<UserModel> GetUserPagedList(PagingModel model, long? UserRole = 0, long? UserStatus = 0);
        ActionOutput UpdateUserProfile(UserModel model);
        ActionOutput<UserModel> GetUserProfile(int Id);

        ActionOutput PhoneLogin(LoginModel model);
        ActionOutput<UserModel> OTPLogin(LoginModel model);
        ActionOutput<Guest> GenrateGuestId();
        ActionOutput<UserModel> AdminLogin(LoginModal model);

        //ActionOutput AddUserDetails(UserModel model);

        //PagingResult<UserModel> GetUserPagedList(PagingModel model);

        //UserModel GetUserByUserId(int userId);

        //ActionOutput UpdateUserDetails(UserModel model);

        //ActionOutput DeleteUser(int userId);

        //ActionOutput<UserInfo> LoginUser(LoginModal userDetails);

        //ActionOutput ValidateUserByEmail(string email, string token);

        //ActionOutput ChangePassword(GenerateNewPasswordModel model);

        //UserModel GetUserDetails(UserInfo user,int LoginType);

        //ActionOutput UpdateUserProfile(UserModel model);

        //ActionOutput UpdateUserPassword(string Old, string New, string Confirm, UserInfo user,int loginType);
        //ActionOutput UpdateFirmPassword(string Old, string New, string Confirm, UserInfo user, int loginType);

        //List<SelectListItem> GetSelectListUsers(int? UserId=0);

        //ActionOutput BulkUpload(BulkImportModel model);

        //ActionOutput BulkUploadCases(BulkImportModel model);
    }
}
