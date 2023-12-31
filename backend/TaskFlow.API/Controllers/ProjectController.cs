﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Commands.Project;

namespace TaskFlow.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("RegisterProject")]
    public async Task<IActionResult> RegisterProject(CreateProjectCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }
    
    [HttpPost("UpdateProject")]
    public async Task<IActionResult> UpdateProject(UpdateProjectCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }

    [HttpPost("DeleteProject")]
    public async Task<IActionResult> DeleteProject(DeleteProjectCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
}