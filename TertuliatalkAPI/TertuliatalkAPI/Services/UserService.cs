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
        var newUser = _context.users.Add(user).Entity;
        await _context.SaveChangesAsync();
        
        return newUser;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.users.ToListAsync();
    }

    public async Task<User> GetUser(Guid id)
    {
        return await _context.users.FindAsync(id);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.users.FirstOrDefaultAsync(u => u.email == email);
    }

    public async Task<User> GetUserByEmailAndPassword(string email, string password)
    { 
        return await _context.users.FirstOrDefaultAsync(u => u.email == email && u.password == password);
    }
}