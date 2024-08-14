using System.Net;
using System.Security.Claims;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class AuthService : IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IInstructorService _instructorService;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthService(IUserService userService, ITokenService tokenService, IInstructorService instructorService,
        IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _tokenService = tokenService;
        _instructorService = instructorService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<UserLoginResponse> LoginUser(UserLoginRequest request)
    {
        var user = await _userService.GetUserByEmail(request.Email);
        if (user == null)
            throw new NotFoundException($"User with Email {request.Email} not found");

        var verified = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if (!verified)
            throw new HttpResponseException(HttpStatusCode.Unauthorized, "Wrong Password or Email.");

        var generatedTokenInformation =
            await _tokenService.GenerateToken(new GenerateTokenRequest { Email = user.Email, Role = user.Role });

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
        if (instructor == null)
            throw new NotFoundException($"Instructor with Email {request.Email} not found");

        var verified = BCrypt.Net.BCrypt.Verify(request.Password, instructor.Password);
        if (!verified)
            throw new HttpResponseException(HttpStatusCode.Unauthorized, "Wrong Password or Email.");

        var generatedTokenInformation =
            await _tokenService.GenerateToken(new GenerateTokenRequest
                { Email = instructor.Email, Role = instructor.Role });

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

    public async Task<Instructor> GetLoggedUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        var email = user?.FindFirst(ClaimTypes.Email)?.Value;
        if (email == null) throw new UnauthorizedAccessException("User email is not available in token");

        var instructor = await _instructorService.GetInstructorByEmail(email);
        if (instructor == null) throw new NotFoundException("User not found");

        return instructor;
    }

    public async Task<Instructor> GetLoggedInstructor()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        var email = user?.FindFirst(ClaimTypes.Email)?.Value;
        if (email == null) throw new UnauthorizedAccessException("User email is not available in token");

        var instructor = await _instructorService.GetInstructorByEmail(email);
        if (instructor == null) throw new NotFoundException("Instructor not found");

        return instructor;
    }
}