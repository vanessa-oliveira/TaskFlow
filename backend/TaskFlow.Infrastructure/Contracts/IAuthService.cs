namespace TaskFlow.Infrastructure.Contracts;

public interface IAuthService
{
    public string HashPassword(string password);
    public Task<bool> VerifyPassword(string userEmail, string password);
}