using MediatR;
using TaskFlow.Application.Commands.Project;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.Handlers.Projects;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<Guid> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var project = new Project()
        {
            Title = command.Title
        };
        await _projectRepository.AddAsync(project);
        return project.Id;
    }
}