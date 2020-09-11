using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TestAuth.Auth.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; } //those who generate the token
        public string Audience { get; set; }// for who token is generating
        public string Secret { get; set; }// secret string for key generation
        public int TokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
