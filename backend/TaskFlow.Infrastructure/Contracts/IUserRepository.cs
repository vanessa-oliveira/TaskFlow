using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Contracts;

public interface IUserRepository
{
    public Task<bool> InsertUser(User user);
    public Task<User> FindUserByEmail(string email);
}