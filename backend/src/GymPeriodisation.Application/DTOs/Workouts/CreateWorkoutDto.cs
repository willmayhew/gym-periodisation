namespace GymPeriodisation.Application.DTOs.Workouts
{
    public class CreateWorkoutDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
