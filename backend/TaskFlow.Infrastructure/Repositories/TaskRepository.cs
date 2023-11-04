using Microsoft.EntityFrameworkCore;
using TaskFlow.Infrastructure.Context;
using TaskFlow.Infrastructure.Contracts;
using Task = TaskFlow.Domain.Entities.Task;

namespace TaskFlow.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly DataContext _dataContext;

    public TaskRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> AddAsync(Task task)
    {
        await _dataContext.Tasks.AddAsync(task);
        return await SaveChanges();
    }

    public async Task<bool> UpdateAsync(Task task)
    {
        _dataContext.Tasks.Update(task);
        return await SaveChanges();
    }

    public async Task<bool> DeleteAsync(Task task)
    {
        _dataContext.Tasks.Remove(task);
        return await SaveChanges();
    }

    public async Task<Task?> GetTaskById(Guid taskId)
    {
        var task = await _dataContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
        return task;
    }

    public async Task<IList<Task>> ListAllTasksFromProject(Guid projectId)
    {
        var tasks = await _dataContext.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        return tasks;
    }

    private async Task<bool> SaveChanges()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }
}