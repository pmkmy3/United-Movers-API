using System.Data;
using united_movers_api.Models;

namespace united_movers_api.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly IDbConnection _dbConnection;

        public AuthRepository(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public LoginResponse Authenticate(LoginRequest request)
        {
            using (var command = _dbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Users";
                var response = new LoginResponse();

                _dbConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    response.Message = reader["Username"] == null ? "" : reader["Username"].ToString();
                    response.IsAuthenticated = true;
                    response.IsTempPassword = false;
                }
                _dbConnection.Close();

                return response;
            }
        }

    }
}
