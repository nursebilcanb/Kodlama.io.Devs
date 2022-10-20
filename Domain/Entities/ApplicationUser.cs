using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationUser : Entity
    {
        public string GithubAddress { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ApplicationUser(int id,string githubAddress, int userId, User user) : this()
        {
            Id = id;
            UserId = userId;
            User = user;
            GithubAddress = githubAddress;
        }

        public ApplicationUser()
        {

        }
    }
}
