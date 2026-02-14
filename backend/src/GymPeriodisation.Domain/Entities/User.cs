using System;
using System.Collections.Generic;
using System.Text;

namespace GymPeriodisation.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;

    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
