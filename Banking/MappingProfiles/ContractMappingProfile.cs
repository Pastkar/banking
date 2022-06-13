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
    public class ContractMappingProfile : Profile
    {
        public ContractMappingProfile()
        {
            CreateMap<ContractGetBL, ContractGetModel>();
            CreateMap<ContractCreateModel, ContractCreateBL>();

            CreateMap<Contract, ContractGetBL>();
            CreateMap<ContractCreateBL, Contract>();
        }
    }
}
