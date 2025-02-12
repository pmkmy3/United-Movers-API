using united_movers_api.Models;

namespace united_movers_api.Repositories
{
    public interface IAuthRepository
    {
        LoginResponse Authenticate(LoginRequest request);
    }
}
