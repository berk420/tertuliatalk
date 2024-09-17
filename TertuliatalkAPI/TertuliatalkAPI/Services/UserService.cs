using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Infrastructure.Repositories.Interfaces;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AddUser(User user)
    {
        return await _userRepository.AddUserAsync(user);
    }

    public async Task<List<User>> GetUsers()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User?> GetUser(Guid id)
    {
        var user =  await _userRepository.GetUserByIdAsync(id);
        if (user == null)
            throw new NotFoundException($"User with ID {id} not found");

        return user;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user == null)
            throw new NotFoundException($"User with Email {email} not found");
        
        return user;
    }
    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }

}