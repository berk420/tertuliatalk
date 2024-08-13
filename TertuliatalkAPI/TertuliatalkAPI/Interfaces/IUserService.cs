using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Interfaces;

public interface IUserService
{
    Task<User> AddUser(User user);
    Task<List<User>> GetUsers();
    Task<User> GetUser(Guid id);
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserByEmailAndPassword(string email, string password);
}