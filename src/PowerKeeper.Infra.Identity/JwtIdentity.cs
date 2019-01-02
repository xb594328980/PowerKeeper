using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace PowerKeeper.Infra.Identity
{
    public class JwtIdentity : IIdentity
    {
        public Claim[] AppendClaims(DateTime time)
        {
            return new Claim[]
            {
               new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(time).ToUnixTimeSeconds().ToString()),
               new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(time.AddHours(1)).ToUnixTimeSeconds().ToString()),
            };
        }

        public string GenerateToken(string securityKey, params Claim[] paramClaims)
        {
            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(paramClaims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ProcessingAuthorization(string securityKey, string authorization, out SecurityToken validatedToken)
        {

            return new JwtSecurityTokenHandler().ValidateToken(authorization.Replace("Bearer ", ""), GetTokenValidationParameters(securityKey), out validatedToken);
        }


        /// <summary>
        /// 设置参数
        /// </summary>
        public TokenValidationParameters GetTokenValidationParameters(string securityKey)
        {

            return new TokenValidationParameters
            {
                ValidateAudience = false,
                //ValidAudience = "the audience you want to validate",
                ValidateIssuer = false,
                //ValidIssuer = "the isser you want to validate",

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),

                ValidateLifetime = true, //validate the expiration and not before values in the token

                ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
            };

        }

        public void AddIdentitySetup(IServiceCollection services, string securityKey)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";
                options.DefaultChallengeScheme = "Jwt";
            }).AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = GetTokenValidationParameters(securityKey);
            });
        }
    }
}
