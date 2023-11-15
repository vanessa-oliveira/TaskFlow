using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Commands.Tasks;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.Handlers.Tasks;

public class ChangePriorityCommandHandler : IRequestHandler<ChangePriorityCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChangePriorityCommandHandler(ITaskRepository taskRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Unit> Handle(ChangePriorityCommand command, CancellationToken cancellationToken)
    {
        var userEmail = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email);
        
        if (userEmail != null)
        {
            var user = await _userRepository.FindUserByEmail(userEmail.Value);
            if (user != null)
            {
                var task = await _taskRepository.GetTaskById(command.TaskId);
                if (task != null)
                {
                    task.Priority = command.Priority;
                    task.LastModifiedAt = DateTime.Now;
                    task.LastModifiedById = user.Id;
                    await _taskRepository.UpdateAsync(task);
                }
            }
        }
        return Unit.Value;
    }
}