﻿using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Commands.Tasks;
using TaskFlow.Infrastructure.Contracts;

namespace TaskFlow.Application.CommandHandlers.Tasks;

public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChangeStatusCommandHandler(ITaskRepository taskRepository, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Unit> Handle(ChangeStatusCommand command, CancellationToken cancellationToken)
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
                    task.Status = command.Status;
                    task.LastModifiedAt = DateTime.Now;
                    task.LastModifiedById = user.Id;
                    await _taskRepository.UpdateAsync(task);
                }
            }
        }
        return Unit.Value;
    }
}