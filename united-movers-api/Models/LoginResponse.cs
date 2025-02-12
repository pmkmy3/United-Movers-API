namespace united_movers_api.Models
{
    public class LoginResponse
    {
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }

        public bool IsTempPassword { get; set; }
    }
}
