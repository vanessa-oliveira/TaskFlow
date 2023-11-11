using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Commands.Tasks;

namespace TaskFlow.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("CreateTask")]
    public async Task<IActionResult> CreateTask(CreateTaskCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }
}