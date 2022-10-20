using Application.Features.Auth.Commands.LoginCommand;
using Application.Features.Auth.Commands.RegisterCommand;
using Application.Features.Auth.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            var result = await Mediator.Send(registerCommand);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await Mediator.Send(loginCommand);
            return Ok(result);
        }
    }
}
