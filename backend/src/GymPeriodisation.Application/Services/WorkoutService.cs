using GymPeriodisation.Application.Interfaces;
using GymPeriodisation.Domain.Entities;

namespace GymPeriodisation.Application.Services;

public class WorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task AddWorkoutAsync(Workout workout)
    {
        await _workoutRepository.AddAsync(workout);
    }

    public async Task<List<Workout>> GetUserWorkoutsAsync(int userId)
    {
        return await _workoutRepository.GetByUserIdAsync(userId);
    }
}
