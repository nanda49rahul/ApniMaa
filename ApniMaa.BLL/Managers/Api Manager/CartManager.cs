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
using System.Data;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ApniMaa.BLL.Managers
{
    public class CartManager : BaseManager, ICartManager
    {

        private readonly IEmailProvider _emailProvider;
        public CartManager()
        {

        }
        ActionOutput ICartManager.AddDishToCart(AddToCartModel model)
        {
            int? UserOrGuestID = 0;
            bool IsUser = false;
            try
            {
                var data = Context.Carts.AsQueryable();

                if (model.UserId == null && model.GuestId == null)
                {
                    return ErrorResponse("User or Guest Id atleast one is required");
                }

                if (model.UserId != null && model.GuestId != null)
                {
                    return ErrorResponse("User or Guest Id only one is required");
                }

                if (model.UserId == null && model.GuestId != null)
                {
                    UserOrGuestID = model.GuestId;
                    data = data.Where(a => a.GuestId == UserOrGuestID.Value);
                    IsUser = true;
                }

                else if (model.UserId != null && model.GuestId == null)
                {
                    UserOrGuestID = model.UserId;
                    data = data.Where(a => a.UserId == UserOrGuestID.Value);
                    IsUser = false;
                }
                var IsCartDataExists = data.FirstOrDefault();

                if (IsCartDataExists == null)
                {
                    var Cart = new Cart();
                    if (IsUser)
                    {
                        Cart.UserId = UserOrGuestID;
                    }
                    else
                    {
                        Cart.GuestId = UserOrGuestID;
                    }

                    Cart.Subtotal = model.Subtotal;
                    Cart.Tax = model.Tax;
                    Cart.Packing = model.Packing;
                    Cart.Delivery = model.Delivery;
                    Cart.Total = model.Total;
                    Cart.OrderStatus = model.OrderStatus;
                    Cart.CouponId = model.CouponId;
                    Cart.DiscountAmount = model.DiscountAmount;

                    Context.Carts.Add(Cart);
                    Context.SaveChanges();

                    var IsMotherCartEntryExists = Context.MotherCarts.Where(a => a.MotherId == model.MotherId).FirstOrDefault();
                    var MotherCart = new MotherCart();
                    if (IsMotherCartEntryExists == null)
                    {
                        MotherCart.MotherId = model.MotherId;
                        MotherCart.CartId = Cart.Id;
                        MotherCart.Tax = model.Tax;
                        MotherCart.Packing = model.Packing;
                        MotherCart.Delivery = model.Delivery;
                        MotherCart.Total = model.Total;
                        MotherCart.OrderStatus = model.OrderStatus;

                        Context.MotherCarts.Add(MotherCart);
                        Context.SaveChanges();
                    }

                    //var IsMotherCartDetailsEntryExists = Context.MotherCartDetails.Where(a => a.MotherCartId == MotherCart.Id ).FirstOrDefault();

                    var MotherCartDetails = new MotherCartDetail();
                    MotherCartDetails.MotherCartId = model.MotherId;
                    MotherCartDetails.MotherDishId = model.DishId;
                    MotherCartDetails.Quantity = model.Quantity;

                    Context.MotherCartDetails.Add(MotherCartDetails);
                    Context.SaveChanges();
                }
                else
                {
                    var IsMotherCartEntryExists = Context.MotherCarts.Where(a => a.MotherId == model.MotherId).FirstOrDefault();
                    var MotherCart = new MotherCart();
                    if (IsMotherCartEntryExists == null)
                    {
                        MotherCart.MotherId = model.MotherId;
                        MotherCart.CartId = IsCartDataExists.Id;
                        MotherCart.Tax = model.Tax;
                        MotherCart.Packing = model.Packing;
                        MotherCart.Delivery = model.Delivery;
                        MotherCart.Total = model.Total;
                        MotherCart.OrderStatus = model.OrderStatus;
                        Context.MotherCarts.Add(MotherCart);
                        Context.SaveChanges();
                    }

                    //var IsMotherCartDetailsEntryExists = Context.MotherCartDetails.Where(a => a.MotherCartId == MotherCart.Id ).FirstOrDefault();
                    var MotherCartDetails = new MotherCartDetail();
                    MotherCartDetails.MotherCartId = model.MotherId;
                    MotherCartDetails.MotherDishId = model.DishId;
                    MotherCartDetails.Quantity = model.Quantity;

                    Context.MotherCartDetails.Add(MotherCartDetails);
                    Context.SaveChanges();
                }

                return SuccessResponse("Dish added to cart Successfully");
            }
            catch (Exception ex)
            {
                return ErrorResponse("Error while adding to dish cart");
            }
        }
        ActionOutput ICartManager.RemoveDishFromCart(int ID)
        {
            var Data = Context.MotherCartDetails.Where(a => a.Id == ID).FirstOrDefault();
            if (Data == null)
            {
                return ErrorResponse("Dish Not Found");
            }
            Context.MotherCartDetails.Remove(Data);
            Context.SaveChanges();
            return SuccessResponse("Dish Deleted");
        }

        ActionOutput ICartManager.OrderCartData(int UserID, bool IsGuest)
        {
            try
            {
                var data = Context.Carts.AsQueryable();
                if (!IsGuest)
                {
                    data = data.Where(a => a.UserId == UserID);
                }
                else
                {
                    data = data.Where(a => a.GuestId == UserID);
                }

                var Order = new List<Order>();
                var MortherOrder = new List<MortherOrder>();
                var MortherOrderDetails = new List<MotherOrderDetail>();

                foreach (var item in data.ToList())
                {
                    var OrderItem = new Order()
                    {
                        UserId = item.UserId,
                        GuestId = item.GuestId,
                        Subtotal = item.Subtotal,
                        Tax = item.Tax,
                        Packing = item.Packing,
                        Delivery = item.Delivery,
                        Total = item.Total,
                        OrderStatus = item.OrderStatus,
                        CouponId = item.CouponId,
                        DiscountAmount = item.DiscountAmount
                    };
                    Order.Add(OrderItem);
                    
                    var MotherCartItem = Context.MotherCarts.Where(a => a.CartId == item.Id).ToList();

                    foreach (var MotherCartitem in MotherCartItem)
                    {
                        var MotherOrder = new MortherOrder()
                        {
                            MotherId = MotherCartitem.MotherId,
                            Tax = MotherCartitem.Tax,
                            Packing = MotherCartitem.Packing,
                            Delivery = MotherCartitem.Delivery,
                            Total = MotherCartitem.Total,
                            OrderStatus = MotherCartitem.OrderStatus,
                        };

                        MortherOrder.Add(MotherOrder);

                        var MotherOrderItem = Context.MotherCartDetails.Where(a => a.MotherCartId == MotherCartitem.MotherId).ToList();

                        foreach(var MotherOrderDetails in MotherOrderItem)
                        {
                            var MotherCartDetails = new MotherOrderDetail()
                            {
                                MotherOrderId = MotherCartitem.Id,
                                MotherDishId = MotherOrderDetails.MotherDishId,
                                Quantity = MotherOrderDetails.Quantity,
                            };

                            MortherOrderDetails.Add(MotherCartDetails);
                        }
                    };
                }

                Context.Orders.AddRange(Order);
                Context.MortherOrders.AddRange(MortherOrder);
                Context.MotherOrderDetails.AddRange(MortherOrderDetails);

                Context.SaveChanges();
                return SuccessResponse("Order Successfully");

            }
            catch (Exception ex)
            {
                return ErrorResponse("Error while processing order");
            }
        }


    }
}
