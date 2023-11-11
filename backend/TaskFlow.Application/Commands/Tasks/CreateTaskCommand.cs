using MediatR;

namespace TaskFlow.Application.Commands.Tasks;

public class CreateTaskCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public Guid ProjectId { get; set; } 
}