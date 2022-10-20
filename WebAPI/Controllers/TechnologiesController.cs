﻿using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }
    }
}