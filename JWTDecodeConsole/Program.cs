using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace JWTDecodeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type JWT:");
                
                // No Need Brear First Line
                var jwt = Console.ReadLine();

                var secretkey = Encoding.UTF8.GetBytes("");
                var encryptionkey = Encoding.UTF8.GetBytes("");

                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkey),
                    TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime=false,
                    ValidateLifetime=false,
                    ValidAudience = "",
                    ValidIssuer = ""
                };

                var claims = handler.ValidateToken(jwt, validations, out var tokenSecure);

                var RoleName = claims.Claims.Where(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role" && a.Value == "Admin").Any();

                Console.WriteLine($"Is Role Admin: {RoleName}");
                Console.ReadKey();
                
                Console.Clear();
            }
        }
    }
}
