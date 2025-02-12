using united_movers_api.Models;

namespace united_movers_api.Services
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);

    }
}
