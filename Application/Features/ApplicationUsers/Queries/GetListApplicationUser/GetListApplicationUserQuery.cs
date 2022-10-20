using Application.Features.ApplicationUsers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Queries.GetListApplicationUser
{
    public class GetListApplicationUserQuery : IRequest<ApplicationUserListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListApplicationQueryHandler : IRequestHandler<GetListApplicationUserQuery, ApplicationUserListModel>
        {
            private readonly IApplicationUserRepository _applicationUserRepository;
            private readonly IMapper _mapper;

            public GetListApplicationQueryHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper)
            {
                _applicationUserRepository = applicationUserRepository;
                _mapper = mapper;
            }

            public async Task<ApplicationUserListModel> Handle(GetListApplicationUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ApplicationUser> appUsers = await _applicationUserRepository.GetListAsync(include: a => a.Include(a => a.User),
                                                                                                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                
                ApplicationUserListModel mappedApplicationUserListModel = _mapper.Map<ApplicationUserListModel>(appUsers);

                return mappedApplicationUserListModel;


            }
        }
    }
}
