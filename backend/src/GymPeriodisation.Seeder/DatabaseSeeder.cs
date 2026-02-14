using GymPeriodisation.Domain.Entities;
using GymPeriodisation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GymPeriodisation.Seeder.Seeding;

public class DatabaseSeeder
{
    private readonly GymDbContext _context;

    public DatabaseSeeder(GymDbContext context)
    {
        _context = context;
    }

    public void SeedMuscles()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "muscles.json");
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Seed file not found: {filePath}");
            return;
        }

        var muscles = JsonSerializer.Deserialize<List<Muscle>>(File.ReadAllText(filePath))!;

        // Only insert muscles that don't already exist (by Id)
        var musclesToAdd = muscles.Where(m => !_context.Muscles.Any(db => db.Id == m.Id)).ToList();
        if (!musclesToAdd.Any())
        {
            Console.WriteLine("All muscles already exist. Nothing to seed.");
            return;
        }

        using var transaction = _context.Database.BeginTransaction();
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Muscles ON;");

        _context.Muscles.AddRange(musclesToAdd);
        _context.SaveChanges();

        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Muscles OFF;");
        transaction.Commit();

        Console.WriteLine($"Seeded {musclesToAdd.Count} muscles successfully!");
    }

    public void SeedUsers()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "users.json");
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Seed file not found: {filePath}");
            return;
        }

        var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filePath))!;

        // Only insert users that don't already exist (by Id)
        var usersToAdd = users.Where(u => !_context.Users.Any(db => db.Id == u.Id)).ToList();
        if (!usersToAdd.Any())
        {
            Console.WriteLine("All users already exist. Nothing to seed.");
            return;
        }

        using var transaction = _context.Database.BeginTransaction();
        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users ON;");

        _context.Users.AddRange(usersToAdd);
        _context.SaveChanges();

        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users OFF;");
        transaction.Commit();

        Console.WriteLine($"Seeded {usersToAdd.Count} users successfully!");
    }
}
