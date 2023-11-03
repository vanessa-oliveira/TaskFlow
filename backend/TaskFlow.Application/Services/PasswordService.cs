namespace TaskFlow.Application.Services;

public interface IPasswordService
{
    public string HashPassword(string password);
    public Task<bool> VerifyPassword(string passwordInput, string userHashedPassword);
}

public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return hashedPassword;
    }

    public async Task<bool> VerifyPassword(string passwordInput, string userHashedPassword)
    {
        bool passwordMatch = BCrypt.Net.BCrypt.Verify(passwordInput, userHashedPassword);
        return passwordMatch;
    }
}