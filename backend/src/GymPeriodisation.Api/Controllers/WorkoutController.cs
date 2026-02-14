using GymPeriodisation.Application.DTOs.Workouts;
using GymPeriodisation.Application.Interfaces;
using GymPeriodisation.Application.ServiceInterfaces;
using GymPeriodisation.Application.Services;
using GymPeriodisation.Domain.Entities;
using GymPeriodisation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymPeriodisation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartWorkout(CreateWorkoutDto workout)
        {
            await _workoutService.StartWorkoutAsync(workout);
            return Ok(workout);
        }

        [HttpPost("{id}/end")]
        public async Task<IActionResult> EndWorkout(int id, [FromBody] EndWorkoutDto workout)
        {
            await _workoutService.EndWorkoutAsync(id, workout);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserWorkouts([FromRoute] int userId)
        {
            var workout = await _workoutService.GetUserWorkoutsAsync(userId);
            return Ok(workout);
        }
    }
}
