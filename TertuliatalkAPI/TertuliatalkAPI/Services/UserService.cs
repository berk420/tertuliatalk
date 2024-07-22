using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddUser(User user)
    {
        var newUser = _context.Users.Add(user).Entity;
        await _context.SaveChangesAsync();
        
        return newUser;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUser(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByEmailAndPassword(string email, string password)
    { 
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}