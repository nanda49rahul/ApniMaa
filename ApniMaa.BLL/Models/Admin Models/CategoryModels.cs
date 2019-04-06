using ApniMaa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniMaa.BLL.Models.Admin_Models
{
    public class AddCategoryModel
    {
        [Required(ErrorMessage="Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
    }

    public class CategoryListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }

        public CategoryListingModel()
        {

        }

        public CategoryListingModel(Category obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.Description = obj.Description;
            this.CreatedDate = obj.CreatedOn.ToString(AppDefaults.DateTimeFormat);
        }
    }

    public class EditCategoryModel : AddCategoryModel
    {
        public int id { get; set; }
        public EditCategoryModel()
        {

        }
        public EditCategoryModel(Category obj)
        {
            this.id = obj.Id;
            this.Name = obj.Name;
            this.Description = obj.Description;
            //this.CreatedDate = obj.CreatedOn.ToString(AppDefaults.DateTimeFormat);
        }
    }
}
