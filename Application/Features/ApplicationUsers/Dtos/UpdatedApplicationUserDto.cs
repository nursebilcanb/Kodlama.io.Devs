using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Dtos
{
    public class UpdatedApplicationUserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
    }
}
