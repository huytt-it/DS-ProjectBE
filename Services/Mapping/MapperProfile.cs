using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Data.ViewModels;


namespace Services.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DeviceCreateModel, Device>();



            CreateMap<LocationCreateModel, Location>();
            CreateMap<Location, LocationViewModel>();

            CreateMap<LocationUpdateModel, Location>()
                .ForAllMembers(opt => opt.Condition((src, des, srcMember) => srcMember != null));

            CreateMap<BrandCreateModel, Brand>();
            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandUpdateModel, Brand>()
                .ForAllMembers(opt => opt.Condition((src, des, srcMember) => srcMember != null));
        }
    }
}
