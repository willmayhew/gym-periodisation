using GymPeriodisation.Application.Interfaces;
using GymPeriodisation.Domain.Entities;
using GymPeriodisation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymPeriodisation.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GymDbContext _context;

    public UserRepository(GymDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.Workouts)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
