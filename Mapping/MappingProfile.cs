using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;
using TestWebApi.ModelsDTO;

namespace TestWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountCreationDTO>();
            CreateMap<AccountCreationDTO, Account>();
            CreateMap<Contact, ContactsCreationDTO>();
            CreateMap<ContactsCreationDTO, Contact>();
            CreateMap<Incident, IncidentCreationDTO>();
            CreateMap<IncidentCreationDTO, Incident>();
            CreateMap<ContactLinkToAccountDTO, Contact>();
            CreateMap<IncidentCreationDTO, Contact>();
        }
        
    }
}
