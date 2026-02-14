using GymPeriodisation.Application.DTOs.Workouts;
using GymPeriodisation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymPeriodisation.Application.ServiceInterfaces
{
    public interface IWorkoutService
    {
        Task StartWorkoutAsync(CreateWorkoutDto workout);
        Task EndWorkoutAsync(int id, EndWorkoutDto workout);
        Task<List<Workout>> GetUserWorkoutsAsync(int id);
    }
}
