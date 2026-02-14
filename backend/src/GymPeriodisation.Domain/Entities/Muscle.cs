using GymPeriodisation.Domain.Entities;

public class Muscle
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}