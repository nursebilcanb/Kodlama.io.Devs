using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimListDto>().ReverseMap();

        }
    }
}
