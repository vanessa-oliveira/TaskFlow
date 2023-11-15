using MediatR;
using TaskFlow.Application.Models;
using TaskFlow.Application.Queries.Tasks;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.QueryHandlers.Tasks;

public class GetAllTasksFromProjectQueryHandler : IRequestHandler<GetAllTasksFromProjectQuery, IList<TaskViewModel>>
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksFromProjectQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task<IList<TaskViewModel>> Handle(GetAllTasksFromProjectQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.ListAllTasksFromProject(request.ProjectId);
        var tasksResult = new List<TaskViewModel>();
        var assigneeResult = new UserViewModel(); 
        foreach (var task in tasks)
        {
            if (task.Assignee != null)
            {
                assigneeResult.Id = task.Assignee.Id;
                assigneeResult.Username = task.Assignee.Username;
                assigneeResult.Email = task.Assignee.Email;
            }
            tasksResult.Add(new TaskViewModel()
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
                Priority = task.Priority.ToString(),
                Assignee = assigneeResult,
                Comments = task.Comments
            });
        }

        return tasksResult;
    }
}