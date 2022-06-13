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
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyGetBL, CompanyGetModel>();
            CreateMap<CompanyCreateModel, CompanyCreateBL>();

            CreateMap<Company, CompanyGetBL>();
            CreateMap<CompanyCreateBL, Company>();
        }
    }
}
