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
    public class DishModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string CategoryName { get; set; }
        public DishModel() { }
        public DishModel(Dish obj)
        {
            this.Id = obj.Id;
            this.CategoryId = obj.CategoryId;
            this.Description = obj.Description;
            this.Name = obj.Name;
            this.IsDeleted = obj.IsDeleted;
            this.CategoryName = obj.Category.Name;
        }
    }


}
