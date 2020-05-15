using Microsoft.Extensions.Options;
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
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPasswordService _passwordService;
        private readonly JwtConfig _jwtConfig;

        public AuthenticateService(
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IPasswordService passwordService,
            IOptions<JwtConfig> jwtConfigOptions)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _passwordService = passwordService;
            _jwtConfig = jwtConfigOptions.Value;
        }

        public async Task<string> GenerateToken(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);

            if (user == null) return null;

            if (!_passwordService.VerifyHashedPassword(password, user.PasswordHash)) return null;

            var userRoles = (await _userRoleRepository.GetRolesForUser(user.Id)).Select(r => r.Name);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("username", user.UserName),
                new Claim("name", user.Name)
            };

            foreach (var role in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var token = new JwtSecurityToken(
                            _jwtConfig.Issuer,
                            _jwtConfig.Audience,
                            claims,
                            expires: DateTime.Now.AddDays(7),
                            signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
