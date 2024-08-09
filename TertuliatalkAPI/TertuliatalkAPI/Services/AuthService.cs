using System.Net;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class AuthService : IAuthService
{
    private readonly IInstructorService _instructorService;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthService(IUserService userService, ITokenService tokenService, IInstructorService instructorService)
    {
        _userService = userService;
        _tokenService = tokenService;
        _instructorService = instructorService;
    }

    public async Task<UserLoginResponse> LoginUser(UserLoginRequest request)
    {
        var user = await _userService.GetUserByEmail(request.Email);

        var verified = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if (!verified)
            throw new HttpResponseException(HttpStatusCode.Unauthorized, "Wrong Password or Email.");

        var generatedTokenInformation =
            await _tokenService.GenerateToken(new GenerateTokenRequest { Email = request.Email });

        UserLoginResponse response = new()
        {
            AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate,
            AuthenticateResult = true,
            AuthToken = generatedTokenInformation.Token,
            Role = user.Role
        };

        return response;
    }

    public async Task<InstructorLoginResponse> LoginInstructor(InstructorLoginRequest request)
    {
        var instructor = await _instructorService.GetInstructorByEmail(request.Email);

        var verified = BCrypt.Net.BCrypt.Verify(request.Password, instructor.Password);
        if (!verified)
            throw new HttpResponseException(HttpStatusCode.Unauthorized, "Wrong Password or Email.");

        var generatedTokenInformation =
            await _tokenService.GenerateToken(new GenerateTokenRequest { Email = instructor.Email, Role = instructor.Role });

        InstructorLoginResponse response = new()
        {
            AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate,
            AuthenticateResult = true,
            AuthToken = generatedTokenInformation.Token,
            Role = instructor.Role
        };

        return response;
    }

    public async Task<User?> RegisterUser(UserRegisterRequest request)
    {
        var userEmailExist = await _userService.GetUserByEmail(request.Email);
        if (userEmailExist != null)
            throw new BadRequestException("User email must be unique!");

        User? user = new()
        {
            Name = request.Name,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        return await _userService.AddUser(user);
    }
}