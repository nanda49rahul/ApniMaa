using ApniMaa.BLL.Common;
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ApniMaa.DAL;
using PagedList;

namespace ApniMaa.BLL.Models
{
    public class MotherModel
    {

       public UserTbl user { get; set; }
       public MotherTbl mother { get; set; }
       public List<MotherDish> dish { get; set; }

    }
    public class MotherListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ApplicationNo { get; set; }
        public int Ratings { get; set; }
        public string Description { get; set; }
        public string LOfflineTime { get; set; }
        public string DOfflineTime { get; set; }
        public string LDeliveryTime { get; set; }
        public string DDeliveryTime { get; set; }
        public string ProfilePhoto { get; set; }
        public string CoverPhoto { get; set; }
        public decimal Commision { get; set; }
        public decimal WalletAmount { get; set; }
        public MotherListModel(MotherTbl obj)
        {
            this.Id = obj.Id;
            this.UserId = obj.UserId;
            this.ApplicationNo = obj.ApplicationNo;
            this.Ratings = obj.Ratings;
            this.Description = obj.Description;
            this.LOfflineTime = obj.LOfflineTime;
            this.DOfflineTime = obj.DOfflineTime;
            this.LDeliveryTime = obj.LDeliveryTime;
            this.DDeliveryTime = obj.DDeliveryTime;

            this.ProfilePhoto = obj.ProfilePhoto;
            this.UserId = obj.UserId;
            this.WalletAmount = obj.WalletAmount;

        }
    }
    public class MotherListingModel
    {

        public UserModel user { get; set; }
        public MotherListModel mother { get; set; }
        public List<MotherDishModel> dish { get; set; }

    }
}
