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

            CreateMap<DSUserCreateModel, DSUser>();
            CreateMap<DSUser, DSUserViewModel>();
            CreateMap<DSUserUpdateModel, DSUser>()
                .ForAllMembers(opt => opt.Condition((src, des, srcMember) => srcMember != null));

            CreateMap<DSBuildingCreateModel, DSBuilding>();
            CreateMap<DSBuilding, DSBuildingViewModel>();
            CreateMap<DSBuildingUpdateModel, DSBuilding>()
                .ForAllMembers(opt => opt.Condition((src, des, srcMember) => srcMember != null));

            CreateMap<DSMonitorCreateModel, DSMonitor>();
            CreateMap<DSMonitor, DSMonitorViewModel>();
            CreateMap<DSMonitorUpdateModel, DSMonitor>()
                .ForAllMembers(opt => opt.Condition((src, des, srcMember) => srcMember != null));

            CreateMap<DSMediaCreateModel, DSMedia>();
            CreateMap<DSMedia, DSMediaViewModel>();
            CreateMap<DSMediaUpdateModel, DSMedia>()
                .ForAllMembers(opt => opt.Condition((src, des, srcMember) => srcMember != null));


        }
    }
}
