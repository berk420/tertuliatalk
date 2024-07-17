using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthService(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<UserLoginResponse> LoginUser(UserLoginRequest request)
    {
        UserLoginResponse response = new();

        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request));
        }
        
        Console.WriteLine($"Received email: {request.Email}, password: {request.Password}");
        var user = await _userService.GetUserByEmail(request.Email);
        if (user == null)
        {
            Console.WriteLine("Unauthorized access attempt.");
            throw new ArgumentNullException(nameof(request));
        }
        var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Email = request.Email });
        
        response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
        response.AuthenticateResult = true;
        response.AuthToken = generatedTokenInformation.Token; 
        
        Console.WriteLine("User authenticated successfully.");
        return await Task.FromResult(response);
    }
    
    public async Task<EntityEntry<User>>  RegisterUser(User user)
    {
        return await _userService.AddUser(user);
    }
}