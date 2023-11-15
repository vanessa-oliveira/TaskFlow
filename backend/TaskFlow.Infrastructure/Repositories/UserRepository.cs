using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Context;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> InsertUser(User user)
    {
        await _dataContext.Users.AddAsync(user);
        return await SaveChanges();
    }

    public async Task<User?> FindUserByEmail(string email)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
    
    public async Task<User?> FindUserById(Guid id)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    private async Task<bool> SaveChanges()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}