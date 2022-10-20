using Application.Features.Auth.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Models
{
    public class RegisteredModel
    {
        public RegisteredDto ApplicationUser { get; set; }
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
