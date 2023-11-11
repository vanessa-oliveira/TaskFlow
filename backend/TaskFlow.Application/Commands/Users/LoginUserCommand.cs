using MediatR;

namespace TaskFlow.Application.Commands.Users;

public class LoginUserCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}