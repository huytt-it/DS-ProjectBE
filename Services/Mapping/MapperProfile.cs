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

            CreateMap<LocationCreateModel, Location>()
                .ForMember(x=>x.LocationId, src=>src.MapFrom(x=>new Random().Next(999999)));


            CreateMap<BrandCreateModel, Brand>();
        }
    }
}
