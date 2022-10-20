using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ApplicationUserRepository : EfRepositoryBase<ApplicationUser, BaseDbContext>, IApplicationUserRepository
    {
        public ApplicationUserRepository(BaseDbContext context) : base(context)
        {
        }

        public IList<OperationClaim> GetClaims(ApplicationUser applicationUser)
        {
            return Context.UserOperationClaims
                .Include(u => u.OperationClaim)
                .Where(u => u.UserId == applicationUser.UserId)
                .Select(u => u.OperationClaim)
                .ToList();
        }
    }
}
