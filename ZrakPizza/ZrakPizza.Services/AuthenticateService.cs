using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZrakPizza.DataAccess;

namespace ZrakPizza.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IPasswordService passwordService;
        private readonly JwtConfig config;

        public AuthenticateService()
        {

        }

        public async Task<string> GenerateToken(string username, string password)
        {
            var user = await userRepository.GetByUsername(username);

            if (user == null)
            {
                return null;
            }

            if (!passwordService.VerifyHashedPassword(password, user.PasswordHash))
            {
                return null;
            }

            var userRoles = (await userRoleRepository.GetRolesForUser(user.Id)).Select(r => r.Name);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("Name", user.Name)
            };

            foreach (var role in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var token = new JwtSecurityToken(
                            config.Issuer,
                            config.Audience,
                            claims,
                            expires: DateTime.Now.AddDays(7),
                            signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
