using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProductCatalog.Core.Utilities.Security.Encryption;

namespace ProductCatalog.WebAPI.Extensions.JWT
{
    public static class CustomizeAuthenticationExtension
    {
        public static void AddJwtBearerAuthentication(this IServiceCollection services)
        {

            //var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidIssuer = tokenOptions.Issuer,
            //            ValidAudience = tokenOptions.Audience,
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
            //        };
            //    });
        }
    }
}
