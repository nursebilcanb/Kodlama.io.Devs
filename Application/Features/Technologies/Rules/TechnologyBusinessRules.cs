using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBetDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(l => l.Name == name);
            if (result.Items.Any()) throw new BusinessException("Technology already exists.");
        }

        public async Task TechnologyNameMustBeExistedWhenDeleted(int id)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(l => l.Id == id);
            if (!result.Items.Any()) throw new BusinessException("Technology should be existed");
        }
    }
}
