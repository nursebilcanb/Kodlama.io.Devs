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

namespace Application.Features.ProgrammingLanguages.Commands.CreateLanguage
{
    public partial class CreateLanguageCommand : IRequest<CreatedLanguageDto>
    {
        public string Name { get; set; }

        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public CreateLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameCanNotBetDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdLanguage = await _programmingLanguageRepository.AddAsync(mappedLanguage);
                CreatedLanguageDto createdLanguageDto = _mapper.Map<CreatedLanguageDto>(createdLanguage);

                return createdLanguageDto;
            }
        }
    }
}
