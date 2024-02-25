namespace Application.Core.Configuration
{
    public sealed class ZefixPublicRestApiConfiguration
    {
        public string BaseUrl { get; init; } = null!;
        public Credentials Credential { get; init; } = new Credentials();

       public sealed class Credentials
        {
            public string Username { get; set; } = null!;
            public string Password { get; set; } = null!;
        }
    }
}
