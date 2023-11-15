using MediatR;

namespace TaskFlow.Application.Commands.Tasks;

public class AddAssigneeCommand : IRequest<Unit>
{
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
}