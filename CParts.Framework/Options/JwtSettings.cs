using System;

namespace CParts.Framework.Options
{
    public class JwtSettings
    {
        public string Audience { get; set; }
        public string Authority { get; set; }
        public string Issuer { get; set; }
        public int ExpireTimeDays { get; set; }
        
        public TimeSpan ExpireTime => TimeSpan.FromDays(ExpireTimeDays);
    }
}