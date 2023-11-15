using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Commands.Tasks;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.CommandHandlers.Tasks;

public class AddAssigneeCommandHandler : IRequestHandler<AddAssigneeCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddAssigneeCommandHandler(ITaskRepository taskRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Unit> Handle(AddAssigneeCommand command, CancellationToken cancellationToken)
    {
        var userEmail = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email);
        
        if (userEmail != null)
        {
            var user = await _userRepository.FindUserByEmail(userEmail.Value);
            var assignee = await _userRepository.FindUserById(command.UserId);
            if (user != null && assignee != null)
            {
                var task = await _taskRepository.GetTaskById(command.TaskId);
                if (task != null)
                {
                    task.AssigneeId = command.UserId;
                    task.LastModifiedAt = DateTime.Now;
                    task.LastModifiedById = user.Id;
                    await _taskRepository.UpdateAsync(task);
                }
                else
                {
                    throw new Exception("Tarefa não encontrada!");
                }
            }
        }
        return Unit.Value;
    }
}