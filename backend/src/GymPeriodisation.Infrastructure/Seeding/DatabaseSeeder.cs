using GymPeriodisation.Domain.Entities;
using GymPeriodisation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GymPeriodisation.Infrastructure.Seeding
{
    public class DatabaseSeeder
    {
        private readonly GymDbContext _context;

        public DatabaseSeeder(GymDbContext context)
        {
            _context = context;
        }

        public void SeedMuscles()
        {
            if (_context.Muscles.Any())
            {
                Console.WriteLine("Muscles already exist in the database.");
                return;
            }

            // Read JSON file
            var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "muscles.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Seed file not found: {filePath}");
                return;
            }

            var json = File.ReadAllText(filePath);
            var muscles = JsonSerializer.Deserialize<List<Muscle>>(json)!;

            _context.Muscles.AddRange(muscles);
            _context.SaveChanges();

            Console.WriteLine("Seeded muscles successfully!");
        }
    }
}
