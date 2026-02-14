using GymPeriodisation.Infrastructure;
using GymPeriodisation.Infrastructure.Persistence;
using GymPeriodisation.Seeder.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddDbContext<GymDbContext>(options =>
        options.UseSqlServer("Server=localhost;Database=GymPeriodisationDb;Trusted_Connection=True;TrustServerCertificate=True;"))
    .BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<GymDbContext>();

var seeder = new DatabaseSeeder(context);
seeder.SeedMuscles();
seeder.SeedUsers();

Console.WriteLine("Seeding complete!");
