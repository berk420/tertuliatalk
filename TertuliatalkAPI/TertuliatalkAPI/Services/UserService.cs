using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;

namespace TertuliatalkAPI.Services;

public class UserService : IUserService
{
    private readonly TertuliatalksDbContext _context;

    public UserService(TertuliatalksDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AddUser(User? user)
    {
        var newUser = _context.Users.Add(user).Entity;
        await _context.SaveChangesAsync();

        return newUser;
    }

    public async Task<List<User?>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            throw new NotFoundException($"User with ID {id} not found");

        return user;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
            throw new NotFoundException($"User with Email {email} not found");

        return user;
    }
}