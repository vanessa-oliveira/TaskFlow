using MediatR;

namespace TaskFlow.Application.Commands.Tasks;

public class ChangeTitleCommand : IRequest<Unit>
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
}