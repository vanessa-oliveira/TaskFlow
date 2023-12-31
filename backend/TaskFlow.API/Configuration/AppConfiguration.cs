﻿using TaskFlow.Application.CommandHandlers.Tasks;
using TaskFlow.Application.Commands.Users;
using TaskFlow.Application.Services;
using TaskFlow.Infrastructure.Contracts;
using TaskFlow.Infrastructure.Repositories;

namespace TaskFlow.API.Configuration;

public static class AppConfiguration
{
    public static IServiceCollection AddConfig(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommandHandler).Assembly);
        });
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IPasswordService, PasswordService>();
        return services;
    }
}