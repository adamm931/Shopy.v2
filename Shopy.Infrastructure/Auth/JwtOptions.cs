namespace Shopy.Infrastructure.Auth
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Key { get; set; }

        public int TokenLifetimeInMinutes { get; set; }

    }
}
