using GymPeriodisation.Application.DTOs.Workouts;
using GymPeriodisation.Application.Interfaces;
using GymPeriodisation.Application.ServiceInterfaces;
using GymPeriodisation.Domain.Entities;

namespace GymPeriodisation.Application.Services;

/// <summary>
/// Manages workout-related operations
/// CRUD operations for workouts, retrieving workouts for users, etc.
/// </summary>
public class WorkoutService : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository;

    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task StartWorkoutAsync(CreateWorkoutDto workoutDto)
    {
        var workout = new Workout
        {
            UserId = workoutDto.UserId,
            Name = workoutDto.Name,
            DateStarted = DateTime.Now,
            DateEnded = null,
        };

        await _workoutRepository.AddAsync(workout);
    }

    public async Task EndWorkoutAsync(int id, EndWorkoutDto workoutDto)
    {
        var workout = await _workoutRepository.GetByIdAsync(id);

        if (workout == null)
            throw new Exception("Workout not found");

        if (workout.DateEnded != null)
            throw new Exception("Workout already ended");

        workout.DateEnded = DateTime.UtcNow;
        workout.Comment = workoutDto.Comment;

        await _workoutRepository.SaveChangesAsync();
    }

    public async Task<List<Workout>> GetUserWorkoutsAsync(int userId)
    {
        return await _workoutRepository.GetByUserIdAsync(userId);
    }
}
