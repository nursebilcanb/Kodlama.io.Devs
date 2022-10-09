using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery : IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, LanguageGetByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public GetByIdLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, LanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _languageBusinessRules = businessRules;
            }

            public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(l => l.Id == request.Id);

                _languageBusinessRules.LanguageShouldExistWhenRequested(programmingLanguage);

                LanguageGetByIdDto languageGetByIdDto = _mapper.Map<LanguageGetByIdDto>(programmingLanguage);

                return languageGetByIdDto;

            }
        }

    }
}
