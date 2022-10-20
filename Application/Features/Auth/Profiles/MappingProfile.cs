using Application.Features.Auth.Commands.RegisterCommand;
using Application.Features.Auth.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisteredDto, RegisterCommand>().ReverseMap();

            CreateMap<ApplicationUser, RegisteredDto>()
                .ForMember(c => c.Status, opt => opt.MapFrom(c => c.User.Status))
                .ForMember(c => c.FirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(c => c.LastName, opt => opt.MapFrom(c => c.User.LastName))
                .ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email))
                .ForMember(c => c.AuthenticatorType, opt => opt.MapFrom(c => c.User.AuthenticatorType))
                .ReverseMap();

            CreateMap<RegisterCommand, ApplicationUser>().ReverseMap();
            CreateMap<RegisterCommand, User>();

            CreateMap<ApplicationUser, LoggedInDto>()
                 .ForMember(c => c.Status, opt => opt.MapFrom(c => c.User.Status))
                .ForMember(c => c.FirstName, opt => opt.MapFrom(c => c.User.FirstName))
                .ForMember(c => c.LastName, opt => opt.MapFrom(c => c.User.LastName))
                .ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email))
                .ForMember(c => c.AuthenticatorType, opt => opt.MapFrom(c => c.User.AuthenticatorType))
                .ReverseMap();
        }
    }
}
