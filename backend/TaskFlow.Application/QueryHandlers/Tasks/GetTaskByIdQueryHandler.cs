using MediatR;
using TaskFlow.Application.Models;
using TaskFlow.Application.Queries.Tasks;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.QueryHandlers.Tasks;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskViewModel>
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task<TaskViewModel> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskById(request.TaskId);
        var taskResult = new TaskViewModel();
        var assigneeResult = new UserViewModel();
        if (task != null)
        {
            if (task.Assignee != null)
            {
                assigneeResult.Id = task.Assignee.Id;
                assigneeResult.Username = task.Assignee.Username;
                assigneeResult.Email = task.Assignee.Email;
            }
            taskResult.Title = task.Title;
            taskResult.Description = task.Description;
            taskResult.Status = task.Status.ToString();
            taskResult.Priority = task.Priority.ToString();
            taskResult.Assignee = assigneeResult;
            taskResult.Comments = task.Comments;
        }

        return taskResult;
    }
}