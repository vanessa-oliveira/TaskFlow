using MediatR;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Commands.Tasks;

public class ChangePriorityCommand : IRequest<Unit>
{
    public Guid TaskId { get; set; }
    public Priority Priority { get; set; }
}