using TaskFlow.Application.Commands.User;
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
        });
        services.AddRepositories();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAuthService, AuthService>();
        return services;
    }
}