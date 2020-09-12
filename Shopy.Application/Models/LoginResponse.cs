namespace Shopy.Application.Models
{
    public class LoginResponse
    {
        public bool IsAuthenticated { get; set; }

        public string Token { get; set; }
    }
}
