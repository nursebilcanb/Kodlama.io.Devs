using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteTechnologyCommand)
        //{
        //    DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);
        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        //{
        //    GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
        //    TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
        //    return Ok(result);
        //}

    }
}
