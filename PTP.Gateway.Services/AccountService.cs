using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.IdentityModel.Tokens;
using PTP.Gateway.Business.Exceptions;
using PTP.Gateway.Business.Models;
using PTP.Gateway.Business.Validators;
using PTP.Gateway.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PTP.Gateway.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;

        public AccountService(ILogger<AccountService> logger)
        {
            _logger = logger;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var validator = new LoginRequestValidator();

            var validationResult = validator.Validate(request);

            var loggingData = new Dictionary<string, string>
            {
                { "EmailAddress", request.EmailAddress }
            };

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            if (request.EmailAddress != "test@test.test" || request.Password != "password")
            {
                throw new GatewayException(GatewayExceptionTypes.InvalidCredentials, loggingData);
            }

            _logger.LogInformation("Valid Login", loggingData);

            return new LoginResponse
            {
                Token = GenerateToken(Guid.NewGuid())
            };
        }

        private static string GenerateToken(Guid userId)
        {
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "plot-the-plot";
            var myAudience = "http://myaudience.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}