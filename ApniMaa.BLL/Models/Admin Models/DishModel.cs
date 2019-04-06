using ApniMaa.BLL.Common;

using System;
using System.Web.Mvc;
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
    public class DishListingModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string CategoryName { get; set; }
        public DishListingModel() { }
        public DishListingModel(Dish obj)
        {
            this.Id = obj.Id;
            this.CategoryId = obj.CategoryId;
            this.Description = obj.Description;
            this.Name = obj.Name;
            this.IsDeleted = obj.IsDeleted;
            this.CategoryName = obj.Category.Name;
        }
    }


    public class AddDishModel
    {
        public List<SelectListItem> CategoryList { get; set; }
        [Required(ErrorMessage="Category is required field")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Name is required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required field")]
        public string Description { get; set; }
        public AddDishModel() {
            using (ApniMaaDBEntities Context = new ApniMaaDBEntities())
            {
                this.CategoryList = Context.Categories.Where(d => d.IsDeleted == false).ToList()
                    .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            }
        }
        public AddDishModel(Dish obj)
        {
            using(ApniMaaDBEntities Context = new ApniMaaDBEntities ())
            {
                this.CategoryList = Context.Categories.Where(d => d.IsDeleted == false).ToList()
                    .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            }
            this.CategoryId = obj.CategoryId;
            this.Description = obj.Description;
            this.Name = obj.Name;
        }
    }

    public class EditDishModel : AddDishModel
    {
        public int DishId { get; set; }
        public EditDishModel() { }
        public EditDishModel(Dish obj)
        {
            this.DishId = obj.Id;
            this.CategoryId = obj.CategoryId;
            this.Description = obj.Description;
            this.Name = obj.Name;
        }
    }



}
