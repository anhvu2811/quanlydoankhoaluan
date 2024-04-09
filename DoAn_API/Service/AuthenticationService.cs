using DoAn_API.DTO;
using DoAn_API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_API.Service
{
    public interface IAuthenticationService
    {
        string GenerateToken_GiangVien(GiangVienModel user, string roleName);
        string GenerateToken_SinhVien(SinhVienModel user, string roleName);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSetting _appSettings;

        public AuthenticationService(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken_GiangVien(GiangVienModel user, string roleName)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.HoTen),
                new Claim(ClaimTypes.Role, roleName),
                new Claim("GiangVienID", user.GiangVienID),

                new Claim("TokenId", Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }
        public string GenerateToken_SinhVien(SinhVienModel user, string roleName)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.HoTen),
                new Claim(ClaimTypes.Role, roleName),
                new Claim("SinhVienID", user.SinhVienID),

                new Claim("TokenId", Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
