using Task = TaskFlow.Domain.Entities.Task;

namespace TaskFlow.Infrastructure.Contracts;

public interface ITaskRepository : IGenericRepository<Task>
{
    public Task<Task?> GetTaskById(Guid taskId);
    public Task<IList<Task>> ListAllTasksFromProject(Guid projectId);
}