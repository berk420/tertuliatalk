using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;

    public AuthService(ITokenService tokenService)
    {
        this._tokenService = tokenService;
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
    {
        UserLoginResponse response = new();

        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.Email == "example" && request.Password == "123")  // this basic example
        {
            var generatedTokenInformation =
                await _tokenService.GenerateToken(new GenerateTokenRequest { Email = request.Email });
            
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;            
        }

        return response;
    }
}