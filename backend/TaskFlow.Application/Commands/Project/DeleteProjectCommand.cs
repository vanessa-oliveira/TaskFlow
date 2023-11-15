using MediatR;

namespace TaskFlow.Application.Commands.Project;

public class DeleteProjectCommand : IRequest<Unit>
{
    public Guid ProjectId { get; set; }
}