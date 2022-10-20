using Application.Features.ApplicationUsers.Commands.DeleteApplicationUser;
using Application.Features.ApplicationUsers.Commands.UpdateApplicationUser;
using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, DeletedApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, DeleteApplicationUserCommand>().ReverseMap();

            CreateMap<ApplicationUser, UpdatedApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateApplicationUserCommand>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserGetByIdDto>().ReverseMap();

            CreateMap<IPaginate<ApplicationUser>, ApplicationUserListModel>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserListDto>().ForMember(c => c.FirstName, opt => opt.MapFrom(c => c.User.FirstName))
                                                                .ForMember(c => c.LastName, opt => opt.MapFrom(c => c.User.LastName))
                                                                .ForMember(c => c.Email, opt => opt.MapFrom(c => c.User.Email))
                                                                .ReverseMap();
        }
    }
}
