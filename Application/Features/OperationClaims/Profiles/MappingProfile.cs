﻿using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
        }
    }
}
