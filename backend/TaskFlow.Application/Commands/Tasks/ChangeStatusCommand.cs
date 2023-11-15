using MediatR;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Commands.Tasks;

public class ChangeStatusCommand : IRequest<Unit>
{
    public Guid TaskId { get; set; }
    public Status Status { get; set; }
}