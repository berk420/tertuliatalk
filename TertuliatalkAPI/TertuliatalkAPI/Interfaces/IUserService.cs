using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Entities;

namespace TertuliatalkAPI.Interfaces;

public interface IUserService
{
    Task<EntityEntry<User>> AddUser(User user);
    Task<List<User>> GetUsers();
    Task<User> GetUser(Guid id);
    Task<User> GetUserByEmailAndPassword(string email, string password);
}