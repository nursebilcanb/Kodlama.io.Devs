using Application.Features.ApplicationUsers.Commands.DeleteApplicationUser;
using Application.Features.ApplicationUsers.Commands.UpdateApplicationUser;
using Application.Features.ApplicationUsers.Dtos;
using Application.Features.ApplicationUsers.Models;
using Application.Features.ApplicationUsers.Queries.GetListApplicationUser;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : BaseController
    {

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteApplicationUserCommand deleteApplicationUserCommand)
        {
            DeletedApplicationUserDto result = await Mediator.Send(deleteApplicationUserCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationUserCommand updateApplicationUserCommand)
        {
            UpdatedApplicationUserDto result = await Mediator.Send(updateApplicationUserCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListApplicationUserQuery getListApplicationUserQuery = new() { PageRequest = pageRequest };
            ApplicationUserListModel result = await Mediator.Send(getListApplicationUserQuery);
            return Ok(result);
        }
    }
}
