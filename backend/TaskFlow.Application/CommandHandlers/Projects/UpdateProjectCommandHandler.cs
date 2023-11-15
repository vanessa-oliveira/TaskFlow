using MediatR;
using TaskFlow.Application.Commands.Project;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.CommandHandlers.Projects;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetProjectById(command.ProjectId);
        if (project != null)
        {
            project.Title = command.Title;
            await _projectRepository.UpdateAsync(project);
        }

        return Unit.Value;
    }
}