using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Interfaces;

public interface IAuthService
{
    public Task<UserLoginResponse> LoginUser(UserLoginRequest request);
    public Task<EntityEntry<User>> RegisterUser(User user);

}