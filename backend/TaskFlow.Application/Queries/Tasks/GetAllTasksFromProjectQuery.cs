using MediatR;
using TaskFlow.Application.Models;

namespace TaskFlow.Application.Queries.Tasks;

public class GetAllTasksFromProjectQuery : IRequest<IList<TaskViewModel>>
{
    public Guid ProjectId { get; set; }
}