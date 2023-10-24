namespace Picture.Infrastructure.Service.Interface
{

    public interface ITokenService
    {
        public ValueTask<string> GetTokenAsync(string email, string password);
    }
}