using MediatR;
using TaskFlow.Application.Commands.User;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.Handlers.Users;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseMessage>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<ResponseMessage> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.HashPassword(command.Password);
        var userInput = new User()
        {
            Firstname = command.Firstname,
            LastName = command.LastName,
            Username = command.Username,
            Email = command.Email,
            PasswordHash = passwordHash
        };
        return await _userRepository.InsertUser(userInput) ? new ResponseMessage("Usuário cadastrado com sucesso!") : new ResponseMessage("Não foi possível realizar o cadastro");
    }
}