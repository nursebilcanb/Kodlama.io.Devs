using Application.Services.AuthRepositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.AuthRepositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
