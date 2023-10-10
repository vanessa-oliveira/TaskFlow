using MediatR;

namespace TaskFlow.Application.Commands.User;

public class RegisterUserCommand : IRequest<ResponseMessage>
{
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}