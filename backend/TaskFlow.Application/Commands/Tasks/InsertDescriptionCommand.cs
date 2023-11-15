using MediatR;

namespace TaskFlow.Application.Commands.Tasks;

public class InsertDescriptionCommand : IRequest<Unit>
{
    public Guid TaskId { get; set; }
    public required string Description { get; set; }
}