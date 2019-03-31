using OzzieLeads.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzzieLeads.BLL.Interfaces
{
    public interface IUserManager
    {

        /// <summary>
        /// This method is use to Authenticate the user credentials
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserModel RegisterUser(registerModel model);

        /// <summary>
        /// Check user session is valid or not
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        UserModel IsSessionValid(string sessionId);

        /// This method is used to validate the user session id
        /// </summary>
        UserModel ValidateUserSession(CreateNewSession SessionModel);

        /// <summary>
        /// Create session when user try to login
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        string CreateSession(CreateNewSession SessionModel);


        /// <summary>
        /// Admin Login
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ActionOutput<UserDetails> AdminLogin(LoginModal model);

        /// <summary>
        /// get user assigned modules
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<ModulesModel> GetAllModulesAtAuthentication(int userId);


        ///// <summary>
        ///// Dummy Method for testing purpose:  Get Welcome Message
        ///// </summary>
        ///// <returns></returns>
        //string GetWelcomeMessage();

        ///// <summary>
        ///// This will be used to get user listing model
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //PagingResult<UserListingModel> GetUserPagedList(PagingModel model);

        ///// <summary>
        ///// Update User Details from Admin Panel
        ///// </summary>
        ///// <param name="userDetails"></param>
        ///// <returns></returns>
        //ActionOutput UpdateUserDetails(UserModel userDetails);

        ///// <summary>
        ///// Add User Details from Admin Panel
        ///// </summary>
        ///// <param name="userDetails"></param>
        ///// <returns></returns>
        //ActionOutput AddUserDetails(AddUserModel userDetails);

        ///// <summary>
        ///// Get User Details by User Id
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //UserModel GetUserDetailsByUserId(int userId);

        ///// <summary>
        ///// Delete User By User Id
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //ActionOutput DeleteUser(int userId);



        



        //ForgotPasswordRequestModel AddForgotPasswordRequest(ForgotPasswordModel model, bool isAdmin = false);

        //int GetForgotPasswordTokenDetails(string token);

        //ActionOutput ResetPassword(ResetPassword model);

        ///// <summary>
        ///// Check user session is valid or not
        ///// </summary>
        ///// <param name=""></param>
        ///// <returns></returns>
        //UserModel IsSessionValid(string sessionId);
    }
    
}
