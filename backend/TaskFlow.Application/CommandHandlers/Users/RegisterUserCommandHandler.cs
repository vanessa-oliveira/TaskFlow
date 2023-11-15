using MediatR;
using TaskFlow.Application.Commands.Users;
using TaskFlow.Application.Services;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.CommandHandlers.Users;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseMessage>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<ResponseMessage> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordService.HashPassword(command.Password);
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