namespace HRMS.Api.AppSettings
{
    public class HRMSAppSettings
    {
        public string AllowedOrigins { get; set; }
        public string AppName { get; set; }
        public JwtTokenConfig AuthSettings { get; set; }

        public class JwtTokenConfig
        {
            public bool ValidateLifetime { get; set; }
            public bool ValidateIssuer { get; set; }
            public bool ValidateAudience { get; set; }
            public string ValidIssuer { get; set; }
            public string ValidAudience { get; set; }
            public int AccessTokenExpiration { get; set; }
            public int RefreshTokenExpiration { get; set; }
            public string Secret { get; set; }
        }

    }
}
