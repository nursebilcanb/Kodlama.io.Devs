using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public LanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task LanguageNameCanNotBetDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(l => l.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language already exists.");
        }

        public async Task LanguageNameMustBeExistedWhenDeleted(int id)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(l => l.Id == id);
            if (!result.Items.Any()) throw new BusinessException("Programming language should be existed");
        }

        public void LanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exist");
        }
    }
}
