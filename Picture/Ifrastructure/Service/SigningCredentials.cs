using Microsoft.IdentityModel.Tokens;

namespace Ifrastructure.Service
{
    internal class SigningCredentials
    {
        private SymmetricSecurityKey symmetricSecurityKey;
        private object hmacSha256;
        private SymmetricSecurityKey symmetricSecurityKey1;

        public SigningCredentials(SymmetricSecurityKey symmetricSecurityKey, object hmacSha256)
        {
            this.symmetricSecurityKey = symmetricSecurityKey;
            this.hmacSha256 = hmacSha256;
        }

        public SigningCredentials(SymmetricSecurityKey symmetricSecurityKey1, string hmacSha256)
        {
            this.symmetricSecurityKey1 = symmetricSecurityKey1;
            this.hmacSha256 = hmacSha256;
        }
    }
}