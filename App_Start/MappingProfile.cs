using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IBlood002.Dtos;
using IBlood002.Models;

namespace IBlood002.App_Start
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            //uses reflexion to map based on their property names
            Mapper.CreateMap<Donor, DonorDto>();
            Mapper.CreateMap<DonorDto, Donor>();
        }
    }
}