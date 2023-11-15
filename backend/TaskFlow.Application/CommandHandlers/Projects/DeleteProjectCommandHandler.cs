using MediatR;
using TaskFlow.Application.Commands.Project;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.CommandHandlers.Projects;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetProjectById(command.ProjectId);
        if (project != null)
        {
            await _projectRepository.DeleteAsync(project);
        }

        return Unit.Value;
    }
}