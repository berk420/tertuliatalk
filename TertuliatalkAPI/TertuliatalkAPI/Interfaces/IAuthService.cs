using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Models;
using TertuliatalkAPI.Models.DTOs;

namespace TertuliatalkAPI.Interfaces;

public interface IAuthService
{
    public Task<UserLoginResponse> LoginUser(UserLoginRequest request);
    public Task<InstructorLoginResponse> LoginInstructor(InstructorLoginRequest request);
    public Task<User?> RegisterUser(UserRegisterRequest request);
    public Task<User> GetLoggedUser();
    public Task<Instructor> GetLoggedInstructor();
    Task<User> UpdateUser(UpdateUserRequest request); // Yeni metod


}
