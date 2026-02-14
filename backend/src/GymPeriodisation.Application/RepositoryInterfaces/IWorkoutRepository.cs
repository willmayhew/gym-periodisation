using GymPeriodisation.Domain.Entities;

namespace GymPeriodisation.Application.Interfaces;

public interface IWorkoutRepository
{
    Task AddAsync(Workout workout);
    Task<List<Workout>> GetByUserIdAsync(int userId);
    Task<Workout?> GetByIdAsync(int workoutId);
    Task SaveChangesAsync();
}
