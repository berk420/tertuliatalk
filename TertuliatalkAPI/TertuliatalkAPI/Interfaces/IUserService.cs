using TertuliatalkAPI.Entities;

namespace TertuliatalkAPI.Interfaces;

public interface IUserService
{
    Task<User> AddUser(User user);
    Task<List<User>> GetUsers();
    Task<User?> GetUser(Guid id);
    Task<User?> GetUserByEmail(string email);
}