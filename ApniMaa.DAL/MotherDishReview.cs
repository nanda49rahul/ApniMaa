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
    
    public partial class MotherDishReview
    {
        public int Id { get; set; }
        public int MotherDishId { get; set; }
        public int UserId { get; set; }
        public string Review { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual MotherDish MotherDish { get; set; }
        public virtual UserTbl UserTbl { get; set; }
    }
}
