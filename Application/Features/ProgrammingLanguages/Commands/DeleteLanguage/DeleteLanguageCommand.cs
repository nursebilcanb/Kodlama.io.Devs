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

namespace Application.Features.ProgrammingLanguages.Commands.DeleteLanguage
{
    public partial class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeleteLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageNameMustBeExistedWhenDeleted(request.Id);

                ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedLanguage = await _programmingLanguageRepository.DeleteAsync(mappedLanguage);
                DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);
                
                return deletedLanguageDto;
            }
        }
    }
}
