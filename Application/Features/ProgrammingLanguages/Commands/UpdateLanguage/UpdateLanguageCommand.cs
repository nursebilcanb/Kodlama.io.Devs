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

namespace Application.Features.ProgrammingLanguages.Commands.UpdateLanguage
{
    public partial class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public UpdateLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameCanNotBetDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage updatedLanguage = await _programmingLanguageRepository.UpdateAsync(mappedLanguage);
                UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);

                return updatedLanguageDto;

            }
        }
    }
}
