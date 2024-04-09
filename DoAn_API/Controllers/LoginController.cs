using DoAn_API.DTO;
using DoAn_API.Repository;
using DoAn_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IGiangVienRepository _giangVienRepository;
        private readonly ISinhVienRepository _sinhVienRepository;
        private readonly AuthenticationService _authenticationService;
        public LoginController(IGiangVienRepository giangVienRepository, ISinhVienRepository sinhVienRepository, AuthenticationService authenticationService)
        {
            _giangVienRepository = giangVienRepository;
            _sinhVienRepository = sinhVienRepository;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/api/[Controller]/login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            var giangVien = _giangVienRepository.GetGiangVienByUserNameAndPassword(model.UserID, HashPassword(model.Password));
            var sinhVien = _sinhVienRepository.GetSinhVienByUserNameAndPassword(model.UserID, HashPassword(model.Password));

            if (giangVien != null)
            {
                var userId = giangVien.GiangVienID;
                var roleName = _giangVienRepository.getRoleNameByUserId(userId);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Authenticate success",
                    Token = _authenticationService.GenerateToken_GiangVien(giangVien, roleName),
                });
            }
            else if (sinhVien != null)
            {
                var userId = sinhVien.SinhVienID;
                var roleName = _sinhVienRepository.getRoleNameByUserId(userId);
                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Authenticate success",
                    Token = _authenticationService.GenerateToken_SinhVien(sinhVien, roleName),
                });
            }
            else
            {
                return BadRequest("Invalid username/password");
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/change-giangvien-password")]
        public IActionResult ChangeGiangVienPassword(string userId, string oldPassword, string newPassword)
        {
            try
            {
                _giangVienRepository.changePassword(userId, oldPassword, newPassword);
                return Ok("Mật khẩu giảng viên đã được thay đổi thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/[Controller]/change-sinhvien-password")]
        public IActionResult ChangeSinhVienPassword(string userId, string oldPassword, string newPassword)
        {
            try
            {
                _sinhVienRepository.changePassword(userId, oldPassword, newPassword);
                return Ok("Mật khẩu sinh viên đã được thay đổi thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
