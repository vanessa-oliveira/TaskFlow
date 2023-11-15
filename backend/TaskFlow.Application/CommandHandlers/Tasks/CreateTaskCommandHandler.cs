using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Commands.Tasks;
using TaskFlow.Domain.Enums;
using TaskFlow.Infrastructure.Contracts;
using Task = TaskFlow.Domain.Entities.Task;

namespace TaskFlow.Application.CommandHandlers.Tasks;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateTaskCommandHandler(ITaskRepository taskRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var userEmail = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email);
        var taskResponse = new Task();
        if (userEmail != null)
        {
            var user = await _userRepository.FindUserByEmail(userEmail.Value);
            taskResponse.Title = command.Title;
            taskResponse.CreatedById = user.Id;
            taskResponse.CreatedAt = DateTime.Now;
            taskResponse.LastModifiedById = user.Id;
            taskResponse.LastModifiedAt = DateTime.Now;
            taskResponse.Status = Status.ToDo;
            taskResponse.Priority = Priority.Low;
            taskResponse.ProjectId = command.ProjectId;
        }
        await _taskRepository.AddAsync(taskResponse);
        return taskResponse.Id;
    }
}