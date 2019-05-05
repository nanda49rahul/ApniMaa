using ApniMaa.BLL.Common;
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
    public class OrderListingModel
    {
        public int Id { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Packing { get; set; }
        public decimal Delivery { get; set; }
        public decimal Total { get; set; }
        public int OrderStatus { get; set; }
        public Nullable<int> CouponId { get; set; }
        public decimal DiscountAmount { get; set; }
        public OrderListingModel() { }
        public OrderListingModel(Order obj)
        {
             
        }
    }
}
