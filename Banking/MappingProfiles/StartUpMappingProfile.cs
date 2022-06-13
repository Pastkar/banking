using AutoMapper;
using BusinessLogic.Entities;
using CommonModels.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.MappingProfiles
{
    public class StartUpMappingProfile : Profile
    {
        public StartUpMappingProfile()
        {
            CreateMap<StartUpGetBL, StartUpGetModel>();
            CreateMap<StartUpCreateModel, StartUpCreateBL>();

            CreateMap<StartUp, StartUpGetBL>();
            CreateMap<StartUpCreateBL, StartUp>();
        }
    }
}
