using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Context;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DataContext _dataContext;

    public ProjectRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> AddAsync(Project project)
    {
        await _dataContext.AddAsync(project);
        return await SaveChanges();
    }

    public async Task<bool> UpdateAsync(Project project)
    {
        _dataContext.Update(project);
        return await SaveChanges();
    }

    public async Task<bool> DeleteAsync(Project project)
    {
        _dataContext.Remove(project);
        return await SaveChanges();
    }

    private async Task<bool> SaveChanges()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}