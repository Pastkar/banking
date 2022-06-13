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
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientGetBL, ClientGetModel>();
            CreateMap<ClientCreateModel, ClientCreateBL>();

            CreateMap<Client, ClientGetBL>();
            CreateMap<ClientCreateBL, Client>();
        }
    }
}
