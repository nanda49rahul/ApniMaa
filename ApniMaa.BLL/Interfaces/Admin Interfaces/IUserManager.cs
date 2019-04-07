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
        PagingResult<UserModel> GetUserPagedList(PagingModel model);
        ActionOutput UpdateUserProfile(UserModel model);
        ActionOutput<UserModel> GetUserProfile(int Id);

        ActionOutput PhoneLogin(LoginModel model);
        ActionOutput<UserModel> OTPLogin(LoginModel model);
        ActionOutput<Guest> GenrateGuestId();
        ActionOutput<UserModel> AdminLogin(LoginModal model);
        ActionOutput<UserDetailModel> GetUserDetails(int Id);
        ActionOutput UpdateUserDetails(UserDetailModel model);
        ActionOutput AddDishForMother(AddDishForMotherModel Details);
        List<MotherDishModel> GetMotherDishList(int MotherId);
        ActionOutput DeleteDish(int dishid);
    }
}
