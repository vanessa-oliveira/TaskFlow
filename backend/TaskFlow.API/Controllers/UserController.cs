using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Commands.User;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }
}