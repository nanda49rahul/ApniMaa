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
    
    public partial class MotherDishDailySchedule
    {
        public int Id { get; set; }
        public int MotherDishId { get; set; }
        public System.DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; }
        public bool Availabilty { get; set; }
    
        public virtual MotherDish MotherDish { get; set; }
    }
}
