using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Queries.GetByIdApplicationUser
{
    public class GetByIdApplicationUserQuery : IRequest<ApplicationUserGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdApplicationUserQueryHandler : IRequestHandler<GetByIdApplicationUserQuery, ApplicationUserGetByIdDto>
        {
            private readonly IApplicationUserRepository _applicationUserRepository;
            private readonly IMapper _mapper;
            private readonly ApplicationUserBusinessRules _applicationUserBusinessRules;

            public GetByIdApplicationUserQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper, ApplicationUserBusinessRules applicationUserBusinessRules)
            {
                _applicationUserRepository = applicationUserRepository;
                _mapper = mapper;
                _applicationUserBusinessRules = applicationUserBusinessRules;
            }

            public async Task<ApplicationUserGetByIdDto> Handle(GetByIdApplicationUserQuery request, CancellationToken cancellationToken)
            {
                ApplicationUser? applicationUser = await _applicationUserRepository.GetAsync(a => a.Id == request.Id);
                _applicationUserBusinessRules.ApplicationUserMustBeExistedWhenRequested(applicationUser.Id);

                ApplicationUserGetByIdDto applicationUserGetByIdDto = _mapper.Map<ApplicationUserGetByIdDto>(applicationUser);
               
                return applicationUserGetByIdDto;
            }
        }
    }
}
