namespace Shopy.Application.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }

        public bool IsAuthorized { get; set; }
    }
}
