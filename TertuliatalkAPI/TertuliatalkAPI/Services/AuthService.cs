using System.Net;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
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
        
        var user = await _userService.GetUserByEmailAndPassword(request.Email, request.Password);
        if (user == null)
            throw new HttpResponseException(HttpStatusCode.Unauthorized, "User not found or invalid credentials.");
        
        var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Email = request.Email });
        
        response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
        response.AuthenticateResult = true;
        response.AuthToken = generatedTokenInformation.Token;
        response.Role = user.role;
        
        return response;
    }
    
    public async Task<User> RegisterUser(UserRegisterRequest request)
    {
        var userEmailExist = await _userService.GetUserByEmail(request.email);
        if (userEmailExist is not null)
            return null;

        User user = new();

        user.name = request.name;
        user.email = request.email;
        user.role = request.role;
        user.password = BCrypt.Net.BCrypt.HashPassword(request.password);
        
        return await _userService.AddUser(user);
    }
}