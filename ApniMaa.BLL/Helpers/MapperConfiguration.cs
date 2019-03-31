using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApniMaa.BLL.Models;
using ApniMaa.DAL;

namespace ApniMaa.BLL.Helpers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            //CreateMap<CountryModel,CountryModel>();
        }


        public static void Configure()
        {
            Mapper.Initialize(cg =>
            {
                cg.AddProfile<MapperConfiguration>();
            });
        }
    }

}
