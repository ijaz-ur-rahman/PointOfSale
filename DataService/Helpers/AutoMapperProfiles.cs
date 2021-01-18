using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using PointOfSale.DataService.ViewModels;

namespace PointOfSale.DataService.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //category
            CreateMap<Categories, CategoryForCreateVM>().ReverseMap();
            CreateMap<Categories, CategoryForUpdateVM>().ReverseMap();
            CreateMap<Categories, CategoryForListVM>().ReverseMap();

            //product
        }
    }
}
