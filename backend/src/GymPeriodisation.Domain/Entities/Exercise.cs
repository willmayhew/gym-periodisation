namespace GymPeriodisation.Domain.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Muscle> MuscleGroups { get; set; } = new List<Muscle>();

    public ICollection<WorkoutSet> WorkoutSets { get; set; } = new List<WorkoutSet>();
}
