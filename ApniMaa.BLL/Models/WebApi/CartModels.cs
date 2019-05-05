using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApniMaa.BLL.Models
{
    /// <summary>
    /// register Model this will be  used to login in the application
    /// </summary>
    public class AddToCartModel
    {
        [Required(ErrorMessage = "Required")]
        public int MotherId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int DishId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Quantity { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> GuestId { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Subtotal { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Tax { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Packing { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Delivery { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "Required")]
        public int OrderStatus { get; set; }
        public Nullable<int> CouponId { get; set; }
        public decimal DiscountAmount { get; set; }

        public AddToCartModel()
        {

        }
        public AddToCartModel(Cart Obj)
        {

        }

    }

}