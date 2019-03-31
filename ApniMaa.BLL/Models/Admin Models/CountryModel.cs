
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class CountryModel
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public bool IsActive { get; set; }
//    }

//    public class ProvinceModel
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public int CountryID { get; set; }
//        public string CountryName { get; set; }
//        public bool IsActive { get; set; }
//        public string Code { get; set; }
//        public ProvinceModel() { }
//        public ProvinceModel(Province obj) {
//            this.CountryID = obj.CountryID;
//            this.CountryName = obj.Country.Name;
//            this.Id = obj.Id;
//            this.IsActive = obj.IsActive;
//            this.Name = obj.Name;
//            this.Code = obj.Code;
//        }
//    }
//    public class CityModel
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public int CountryID { get; set; }
//        public string CountryName { get; set; }
//        public int ProvinceID { get; set; }
//        public string ProvinceName { get; set; }
//        public bool IsActive { get; set; }

//        public CityModel() { }
//        public CityModel(City obj)
//        {
//            this.CountryID = obj.Province.CountryID;
//            this.CountryName = obj.Province.Country.Name;
//            this.Id = obj.Id;
//            this.IsActive = obj.IsActive;
//            this.Name = obj.Name;
//            this.ProvinceID = obj.ProvinceID;
//            this.ProvinceName = obj.Province.Name;
//        }
//    }
//}
