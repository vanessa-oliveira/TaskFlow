using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Contracts;

public interface IProjectRepository : IGenericRepository<Project>
{
    public Task<Project?> GetProjectById(Guid projectId);
}