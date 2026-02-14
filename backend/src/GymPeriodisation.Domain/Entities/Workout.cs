namespace GymPeriodisation.Domain.Entities;

public class Workout
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime Date { get; set; }

    public ICollection<WorkoutSet> Sets { get; set; } = new List<WorkoutSet>();
}
