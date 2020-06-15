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
            Mapper.CreateMap<BloodType, BloodTypeDto>();
            Mapper.CreateMap<BloodTypeDto, BloodType>()
                .ForMember(b => b.Id, opt => opt.Ignore());

            //uses reflexion to map based on their property names
            Mapper.CreateMap<Donor, DonorDto>();
            Mapper.CreateMap<DonorDto, Donor>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}