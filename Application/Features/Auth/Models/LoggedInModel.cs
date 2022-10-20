using Application.Features.Auth.Dtos;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Models
{
    public class LoggedInModel
    {
        public LoggedInDto ApplicationUser { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
