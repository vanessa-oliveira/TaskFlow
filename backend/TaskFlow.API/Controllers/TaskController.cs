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
    
    [HttpPost("ChangeTitle")]
    public async Task<IActionResult> UpdateTitle(ChangeTitleCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("InsertDescription")]
    public async Task<IActionResult> InsertDescription(InsertDescriptionCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
    
    [HttpPost("ChangeStatus")]
    public async Task<IActionResult> UpdateStatus(ChangeStatusCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
    
    [HttpPost("ChangePriority")]
    public async Task<IActionResult> UpdatePriority(ChangePriorityCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }

    [HttpPost("AddAssignee")]
    public async Task<IActionResult> AddAssignee(AddAssigneeCommand cmd)
    {
        await _mediator.Send(cmd);
        return NoContent();
    }
}