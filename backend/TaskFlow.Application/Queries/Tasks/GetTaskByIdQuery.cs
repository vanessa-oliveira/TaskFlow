using MediatR;
using TaskFlow.Application.Models;

namespace TaskFlow.Application.Queries.Tasks;

public class GetTaskByIdQuery : IRequest<TaskViewModel>
{
    public Guid TaskId { get; set; }
}