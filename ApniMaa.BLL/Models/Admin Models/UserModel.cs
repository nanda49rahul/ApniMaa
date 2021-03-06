﻿using ApniMaa.BLL.Common;
// 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ApniMaa.DAL;
using System.Web.Mvc;
//using PagedList;

namespace ApniMaa.BLL.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OTP { get; set; }
        public string Password { get; set; }
        public int? City { get; set; }
        public int? Province { get; set; }
        public string Address { get; set; }
        public string Longitute { get; set; }
        public string Latitute { get; set; }
        public Nullable<int> RoleId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsOnHold { get; set; }
        public string RoleName { get; set; }
        public string DeviceId { get; set; }
        public Guid SessionId { get; set; }
        public int DeviceType { get; set; }
        public string UniqueDeviceId { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public int Status { get; set; }
        public UserModel() { }
        public UserModel(UserTbl obj)
        {
            this.UserID = obj.Id;
            this.RoleId = obj.RoleId;
            this.RoleName = UtilitiesHelp.EnumToDecription(typeof(UserRoleTypes), obj.RoleId.Value);
            this.Email = obj.Email;
            this.FirstName = obj.FirstName;
            this.LastName = obj.LastName;
            this.Password = UtilitiesHelp.EncryptPassword(obj.Password, true);
            this.Phone = obj.Phone;
            this.City = obj.City;
            this.Province = obj.Province;
            this.Address = obj.Address;
            this.Longitute = obj.Longitute;
            this.Latitute = obj.Latitute;
            this.RoleId = obj.RoleId;
            this.Status = obj.Status;
        }

        public UserModel(Guid sessionId, UserTbl obj)
            : this(obj)
        {
            SessionId = sessionId;
        }
    }


    public class AdminUserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "First Name is required field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required field")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Email is required field")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OTP { get; set; }
        public string Password { get; set; }
        public int? City { get; set; }
        public int? Province { get; set; }
        public string Address { get; set; }
        public string Longitute { get; set; }
        public string Latitute { get; set; }
        public Nullable<int> RoleId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsOnHold { get; set; }
        public string RoleName { get; set; }
        public string DeviceId { get; set; }
        public Guid SessionId { get; set; }
        public int DeviceType { get; set; }
        public string UniqueDeviceId { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public int Status { get; set; }
        public AdminUserModel() { }
        public AdminUserModel(UserTbl obj)
        {
            this.UserID = obj.Id;
            this.RoleId = obj.RoleId;
            this.RoleName = UtilitiesHelp.EnumToDecription(typeof(UserRoleTypes), obj.RoleId.Value);
            this.Email = obj.Email;
            this.FirstName = obj.FirstName;
            this.LastName = obj.LastName;
            this.Password = UtilitiesHelp.EncryptPassword(obj.Password, true);
            this.Phone = obj.Phone;
            this.City = obj.City;
            this.Province = obj.Province;
            this.Address = obj.Address;
            this.Longitute = obj.Longitute;
            this.Latitute = obj.Latitute;
            this.RoleId = obj.RoleId;
            this.Status = obj.Status;
        }
    }
    public class UserDetailModel : AdminUserModel
    {
        public List<MotherDishModel> MotherDishList { get; set; }
        public UserDetailModel()
        {
            
        }
        public UserDetailModel(UserTbl obj) : base(obj)
        {
            this.MotherDishList = obj.MotherTbls.Count() > 0 ? obj.MotherTbls.FirstOrDefault().MotherDishes.Where(a=>a.IsDeleted == false).Select(s => new MotherDishModel(s)).ToList(): null;
        }
    }

    public class AddDishForMotherModel
    {
        public int MotherID { get; set; }
        [Required(ErrorMessage="Dish is required field")]
        public int DishId { get; set; }
        [Required(ErrorMessage = "Dish Image is required field")]
        public HttpPostedFileBase DishImage { get; set; }
        public List<SelectListItem> DishList { get; set; }
        public AddDishForMotherModel()
        {
            
        }
    }


    public class MotherDishModel
    {
        public int Id { get; set; }
        public int MotherId { get; set; }
        public int DishId { get; set; }
        public string DishName { get; set; }
        public int Limit { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMainDish { get; set; }
        public bool IsSignatureDish { get; set; }
        public MotherDishModel(MotherDish obj)
        {
            this.Id = obj.Id;
            this.MotherId = obj.MotherId;
            this.DishId = obj.DishId;
            this.DishName = obj.Dish.Name;
            this.Limit = obj.Limit;
            this.Price = obj.Price;
            this.Image = UtilitiesHelp.GetFilePath(AppFolderName.DishImage, obj.Image);
            this.CreatedOn = obj.CreatedOn.ToString(AppDefaults.DateTimeFormat);
            this.IsDeleted = obj.IsDeleted;
            this.IsMainDish = obj.IsMainDish;
            this.IsSignatureDish = obj.IsSignatureDish;
        }
    }

    public class LoginModel
    {
        public string ContactNo { get; set; }
        public string OTP { get; set; }
    }

    public class OTPModel
    {
        public int Id { get; set; }
        public int OTP { get; set; }
    }
    public class CreateNewSession
    {
        public int UserID { get; set; }
        public string UniqueDeviceId { get; set; }
        public string DeviceToken { get; set; }
        public int DeviceType { get; set; }
        public string Session { get; set; }
        public Guid sessionId { get; set; }
        public string TokenVOIP { get; set; }
    }
    public class RegisterModel : UserModel
    {

    }


}
