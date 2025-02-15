using Isopoh.Cryptography.Argon2;
using System.Globalization;
using united_movers_api.Models;
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
            request.Password = Argon2.Hash(request.Password);
            return this._authRepository.Authenticate(request);
        }

        public bool ChangePassword(ChangePasswordRequest request)
        {
            request.NewPassword = Argon2.Hash(request.NewPassword);
            request.OldPassword = Argon2.Hash(request.OldPassword);

            return this._authRepository.ChangePassword(request);
        }

        public bool ForgotPassword(ChangePasswordRequest request)
        {
            request.NewPassword = Argon2.Hash(request.NewPassword);
            return this._authRepository.ForgotPassword(request);
        }
    }
}
