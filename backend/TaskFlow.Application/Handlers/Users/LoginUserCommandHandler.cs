using MediatR;
using TaskFlow.Application.Commands.User;
using TaskFlow.Application.Services;

namespace TaskFlow.Application.Handlers.Users;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public LoginUserCommandHandler(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _authService.SignIn(command.Email, command.Password);
        var token = _tokenService.GenerateToken(command.Email);
        return token;
    }
}