
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ApniMaa.DAL;

//namespace ApniMaa.BLL.Models
//{
//    public class ComissionModel
//    {
//        public int Id { get; set; }
//        public int FleetId { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string MunicipalityName { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string MunicipalityCode { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string TerritoryCode { get; set; }
//        [Required]
//        [StringLength(150)]
//        public string StreetAddress { get; set; }
//        [Required]
//        public int CityId { get; set; }
//        [Required]
//        public int ProvinceId { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string PostalCode { get; set; }
//        [Required]
//        [StringLength(50)]
//        public string ContactName { get; set; }
//        public string Phone { get; set; }
//        public string AlternatePhone { get; set; }
//        [StringLength(50)]
//        public string Fax { get; set; }
//        [Required]
//        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-??]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Invalid Email")]
//        public string Email { get; set; }
//        [Required]
//        public int CancelNoticeDaysId { get; set; }
//        [Required]
//        public int CertificateType { get; set; }
//        //public bool IsGenericCertificate { get; set; }
//        [Required]
//        public string CityName { get; set; }
//        public string Add_Certificate_Format { get; set; }
//        public string Delete_Certificate_Format { get; set; }
//        public bool IsActive { get; set; }
//        public List<MunicipalityPrefixesModel> MunicipalityPrefixesList { get; set; }

//        public ComissionModel()
//        {

//        }
//        public ComissionModel(Comission obj)
//        {
//            this.Id = obj.Id;
//            this.FleetId = obj.FleetId;
//            this.MunicipalityName = obj.MunicipalityName;
//            this.MunicipalityCode = obj.MunicipalityCode;
//            this.TerritoryCode = obj.TerritoryCode;
//            this.StreetAddress = obj.StreetAddress;
//            this.CityId = obj.CityId;
//            this.CityName = obj.City.Name;
//            this.ProvinceId = obj.ProvinceId;
//            this.PostalCode = obj.PostalCode;
//            this.ContactName = obj.ContactName;
//            this.Phone = obj.Phone;
//            this.AlternatePhone = obj.AlternatePhone;
//            this.Fax = obj.Fax;
//            this.Email = obj.Email;
//            this.CancelNoticeDaysId = obj.CancelNoticeDaysId;
//            this.CertificateType = obj.CertificateType;
//            this.Add_Certificate_Format = obj.Add_Certificate_Format;
//            this.Delete_Certificate_Format = obj.Delete_Certificate_Format;
//            this.IsActive = obj.IsActive;
//            this.MunicipalityPrefixesList = obj.MunicipalityPrefixes.Select(x => new MunicipalityPrefixesModel() { Value = x.Value }).ToList();

//        }

//    }

//    public class MunicipalityPrefixesModel
//    {
//        public int Index { get; set; }
//        public string Value { get; set; }
//    }
//}
