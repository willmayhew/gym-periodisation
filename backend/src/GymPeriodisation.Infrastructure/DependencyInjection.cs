using GymPeriodisation.Application.Interfaces;
using GymPeriodisation.Application.ServiceInterfaces;
using GymPeriodisation.Application.Services;
using GymPeriodisation.Infrastructure.Persistence;
using GymPeriodisation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymPeriodisation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<GymDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        // Register repositories
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Register services
        services.AddScoped<IWorkoutService, WorkoutService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
