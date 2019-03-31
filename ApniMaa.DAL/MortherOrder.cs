//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class MortherOrder
    {
        public MortherOrder()
        {
            this.MotherOrderDetails = new HashSet<MotherOrderDetail>();
        }
    
        public int Id { get; set; }
        public int MotherId { get; set; }
        public int OrderId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Packing { get; set; }
        public decimal Delivery { get; set; }
        public decimal Total { get; set; }
        public int OrderStatus { get; set; }
    
        public virtual ICollection<MotherOrderDetail> MotherOrderDetails { get; set; }
        public virtual MotherTbl MotherTbl { get; set; }
        public virtual Order Order { get; set; }
    }
}
