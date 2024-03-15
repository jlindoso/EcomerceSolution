using Application.Company.DTO;
using Application.Company.DTO.Requests;
using Application.User.DTO;
using Application.User.DTO.Requests;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Entities.Company, CompanyDTO>();
            CreateMap<CompanyCreateRequest, Domain.Entities.Company>();
            CreateMap<CustomerCreateAccountDTO, IdentityUser>().ForMember(dest => dest.UserName, opt=>opt.MapFrom(src=>src.Email.ToUpper()));
            CreateMap<IdentityUser, CustomerDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NormalizedEmail))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.NormalizedEmail));
        }

    }
}
