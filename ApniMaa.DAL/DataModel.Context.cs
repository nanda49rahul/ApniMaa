﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApniMaa.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApniMaaDBEntities : DbContext
    {
        public ApniMaaDBEntities()
            : base("name=ApniMaaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CMSPage> CMSPages { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Favourite> Favourites { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<MortherOrder> MortherOrders { get; set; }
        public virtual DbSet<MotherAnswer> MotherAnswers { get; set; }
        public virtual DbSet<MotherBankDetail> MotherBankDetails { get; set; }
        public virtual DbSet<MotherCart> MotherCarts { get; set; }
        public virtual DbSet<MotherCartDetail> MotherCartDetails { get; set; }
        public virtual DbSet<MotherCoupon> MotherCoupons { get; set; }
        public virtual DbSet<MotherDailySchedule> MotherDailySchedules { get; set; }
        public virtual DbSet<MotherDish> MotherDishes { get; set; }
        public virtual DbSet<MotherDishDailySchedule> MotherDishDailySchedules { get; set; }
        public virtual DbSet<MotherDishReview> MotherDishReviews { get; set; }
        public virtual DbSet<MotherGallery> MotherGalleries { get; set; }
        public virtual DbSet<MotherOrderDetail> MotherOrderDetails { get; set; }
        public virtual DbSet<MotherQuestion> MotherQuestions { get; set; }
        public virtual DbSet<MotherStatement> MotherStatements { get; set; }
        public virtual DbSet<MotherTbl> MotherTbls { get; set; }
        public virtual DbSet<Notificationss> Notificationsses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OTP> OTPs { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<PushNotificationsMessageLog> PushNotificationsMessageLogs { get; set; }
        public virtual DbSet<QueuedPushNotification> QueuedPushNotifications { get; set; }
        public virtual DbSet<UserAchievement> UserAchievements { get; set; }
        public virtual DbSet<UserAddressTbl> UserAddressTbls { get; set; }
        public virtual DbSet<UserAssignedModule> UserAssignedModules { get; set; }
        public virtual DbSet<UserEnquiry> UserEnquiries { get; set; }
        public virtual DbSet<UserLoginSession> UserLoginSessions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTbl> UserTbls { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
    }
}
