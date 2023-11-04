using MediatR;

namespace TaskFlow.Application.Commands.Project;

public class CreateProjectCommand : IRequest<Guid>
{
    public string Title { get; set; }
}