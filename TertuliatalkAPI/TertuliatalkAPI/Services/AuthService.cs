using System.Net;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthService(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<UserLoginResponse> LoginUser(UserLoginRequest request)
    {
        UserLoginResponse response = new();

        var user = await _userService.GetUserByEmail(request.Email);
        if (user == null)
            throw new HttpResponseException(HttpStatusCode.Unauthorized, "User not found or invalid credentials.");

        var verified = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if (!verified)
            throw new HttpResponseException(HttpStatusCode.Unauthorized, "Wrong Password or Email.");

        var generatedTokenInformation =
            await _tokenService.GenerateToken(new GenerateTokenRequest { Email = request.Email });

        response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
        response.AuthenticateResult = true;
        response.AuthToken = generatedTokenInformation.Token;
        response.Role = user.Role;

        return response;
    }

    public async Task<User> RegisterUser(UserRegisterRequest request)
    {
        var userEmailExist = await _userService.GetUserByEmail(request.email);
        if (userEmailExist is not null)
            return null;

        User user = new();

        user.Name = request.name;
        user.Email = request.email;
        user.Role = request.role;
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.password);

        return await _userService.AddUser(user);
    }
}