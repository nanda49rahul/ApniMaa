using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApniMaa.BLL.Models
{
    public class AddProspectModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-??]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The phone number field is required.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        public Nullable<int> countryId { get; set; }

        public Nullable<int> Campaign { get; set; }

        public Nullable<bool> status { get; set; }

        public Nullable<System.DateTime> addedDate { get; set; }

        public Nullable<System.DateTime> modifiedDate { get; set; }

        public Nullable<bool> isDeleted { get; set; }

        public Nullable<bool> isActive { get; set; }

        public List<SelectListItem> CountryList { get; set; }


        public AddProspectModel()
        {

            using (ApniMaaDBEntities context = new ApniMaaDBEntities())
            {
                this.CountryList = context.Countries.Select(a => new SelectListItem { Text = a.CountryName, Value = a.CountryID.ToString() }).ToList();
            }
        }

        //public AddProspectModel(Prospect obj)
        //{

        //}
    }


    public class ProspectListingModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> countryId { get; set; }
        public Nullable<int> Campaign { get; set; }
        public Nullable<bool> status { get; set; }
        public string addedDate { get; set; }
        public string modifiedDate { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<bool> isActive { get; set; }

        public ProspectListingModel() { }

        //public ProspectListingModel(Prospect obj)
        //{
        //    this.id = obj.id;
        //    this.firstName = obj.firstName;
        //    this.lastName = obj.lastName;
        //    this.Email = obj.Email;
        //    this.MobileNumber = obj.MobileNumber;
        //    this.countryId = obj.countryId;
        //    this.Campaign = obj.Campaign;
        //    this.status = obj.status;
        //    this.addedDate = obj.addedDate.HasValue ? obj.addedDate.Value.ToShortDateString() : Convert.ToString(obj.addedDate);
        //    this.modifiedDate = obj.modifiedDate.HasValue ? obj.modifiedDate.Value.ToShortDateString() : Convert.ToString(obj.modifiedDate);
        //    this.isDeleted = obj.isDeleted;
        //    this.isActive = obj.isActive;
        //}
    }

}