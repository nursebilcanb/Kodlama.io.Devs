using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Dtos
{
    public class RegisteredDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public string GithubAddress { get; set; }
    }
}
