using TaskFlow.Application.Exceptions;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.Services;

public interface IAuthService
{
    public Task<bool> SignIn(string email, string password);
}

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public AuthService(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<bool> SignIn(string email, string password)
    {
        var user = await _userRepository.FindUserByEmail(email);
        if (user == null)
        {
            throw new UserException("Usuário não encontrado!");
        }
        return await _passwordService.VerifyPassword(password, user.PasswordHash);
    }
    
}