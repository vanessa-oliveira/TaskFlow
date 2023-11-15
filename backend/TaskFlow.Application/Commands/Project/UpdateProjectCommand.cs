using MediatR;

namespace TaskFlow.Application.Commands.Project;

public class UpdateProjectCommand : IRequest<Unit>
{
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
}