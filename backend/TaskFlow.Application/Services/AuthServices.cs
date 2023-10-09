using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string HashPassword(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return hashedPassword;
    }

    public async Task<bool> VerifyPassword(string userEmail, string password)
    {
        var user = await _userRepository.FindUserByEmail(userEmail);
        bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        return passwordMatch;
    }
}