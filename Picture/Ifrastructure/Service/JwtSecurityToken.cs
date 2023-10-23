using System.Security.Claims;

namespace Ifrastructure.Service
{
    internal class JwtSecurityToken
    {
        private List<Claim> claims;
        private SigningCredentials signingCredentials;
        private string? issuer;
        private string? audience;
        private DateTime expires;

        public JwtSecurityToken(List<Claim> claims, SigningCredentials signingCredentials, string? issuer, string? audience, DateTime expires)
        {
            this.claims = claims;
            this.signingCredentials = signingCredentials;
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
        }
    }
}