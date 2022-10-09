using Application.Features.ProgrammingLanguages.Commands.CreateLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdateLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProgrammingLanguage, CreatedLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateLanguageCommand>().ReverseMap();
            
            CreateMap<ProgrammingLanguage, UpdatedLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateLanguageCommand>().ReverseMap();
            
            CreateMap<ProgrammingLanguage, DeletedLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, LanguageGetByIdDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, LanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, LanguageListDto>().ReverseMap();

        }
    }
}
