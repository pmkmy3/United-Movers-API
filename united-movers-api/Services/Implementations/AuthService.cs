using united_movers_api.Services;
using Isopoh.Cryptography.Argon2;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using united_movers_api.Models;
using System.Data;
using united_movers_api.Repositories;

namespace united_movers_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _authRepository;
        public AuthService(IConfiguration configuration, IAuthRepository authRepository)
        {
            _configuration = configuration;
            this._authRepository = authRepository;
        }

        public LoginResponse Login(LoginRequest request)
        {
            this._authRepository.Authenticate(request);
            return new LoginResponse();
            
        }


    }
}
