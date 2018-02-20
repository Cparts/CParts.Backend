using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CParts.Framework.Options
{
    public class JwtSettings
    {
        public string Audience { get; set; }
        public string Authority { get; set; }
        public string Issuer { get; set; }
        public int ExpireTimeHours { get; set; }
        public string SecurityKeyValue { get; set; }

        public SecurityKey SecurityKey =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKeyValue));

        public SigningCredentials SigningCredentials =>
            new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

        public TimeSpan ExpireTime => TimeSpan.FromDays(ExpireTimeHours);
    }
}