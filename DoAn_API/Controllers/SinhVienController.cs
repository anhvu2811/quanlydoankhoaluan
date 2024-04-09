using DoAn_API.DTO;
using DoAn_API.Models;
using DoAn_API.Repository;
using DoAn_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienRepository _sinhVienRepository;
        private readonly AuthenticationService _authenticationService;
        public SinhVienController(ISinhVienRepository sinhVienRepository, AuthenticationService authenticationService)
        {
            _sinhVienRepository = sinhVienRepository;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-sinh-vien")]
        public IActionResult getAllSinhVien()
        {
            try
            {
                var user = _sinhVienRepository.getAllSinhVien().ToList();
                if (!user.Any())
                {
                    return BadRequest("Không có người dùng nào.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-sinh-vien-by-id")]
        public IActionResult getSinhVienById(string id)
        {
            try
            {
                var user = _sinhVienRepository.getSinhVienById(id);
                if (user is null)
                {
                    return BadRequest("Không tìm thấy người dùng.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-sinh-vien")]
        public IActionResult createSinhVien(SinhVienDTO nguoidung)
        {
            try
            {
                var kt = _sinhVienRepository.getAllSinhVien().Where(c => c.SinhVienID == nguoidung.SinhVienID);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                SinhVienModel nguoidungModel = new SinhVienModel
                {
                    SinhVienID = nguoidung.SinhVienID,
                    HoTen = nguoidung.HoTen,
                    NgaySinh = nguoidung.NgaySinh,
                    GioiTinh = nguoidung.GioiTinh,
                    DiaChi = nguoidung.DiaChi,
                    SDT = nguoidung.SDT,
                    Email = nguoidung.Email,
                    Password = nguoidung.Password,
                    LopID = nguoidung.Lop.LopID,
                    NhomQuyenID = nguoidung.NhomQuyen.NhomQuyenID
                };
                _sinhVienRepository.createSinhVien(nguoidungModel);
                return Ok(nguoidungModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-sinh-vien")]
        public IActionResult updateSinhVien(SinhVienDTO nguoidung)
        {
            try
            {
                SinhVienModel nguoidungModel = new SinhVienModel
                {
                    SinhVienID = nguoidung.SinhVienID,
                    HoTen = nguoidung.HoTen,
                    NgaySinh = nguoidung.NgaySinh,
                    GioiTinh = nguoidung.GioiTinh,
                    DiaChi = nguoidung.DiaChi,
                    SDT = nguoidung.SDT,
                    Email = nguoidung.Email,
                    Password = nguoidung.Password,
                    LopID = nguoidung.Lop.LopID,
                    NhomQuyenID = nguoidung.NhomQuyen.NhomQuyenID
                };
                _sinhVienRepository.updateSinhVien(nguoidungModel);
                return Ok(nguoidungModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-sinh-vien")]
        public IActionResult deleteSinhVien(string id)
        {
            try
            {
                var user = _sinhVienRepository.deleteSinhVien(id);
                if (!user)
                {
                    return BadRequest("Không tìm thấy người dùng để xóa.");
                }
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/change-password")]
        public IActionResult ChangePassword(string userId, string oldPassword, string newPassword)
        {
            try
            {
                _sinhVienRepository.changePassword(userId, oldPassword, newPassword);
                return Ok("Mật khẩu đã được thay đổi thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/check-sinh-vien-exists/{sinhVienId}")]
        public IActionResult CheckSinhVienExists(string sinhVienId)
        {
            try
            {
                var exists = _sinhVienRepository.getAllSinhVien().Any(s => s.SinhVienID == sinhVienId);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-ho-ten-sinh-vien-by-id")]
        public IActionResult GetHoTenSinhVienById(string id)
        {
            try
            {
                var HoTen = _sinhVienRepository.GetHoTenSinhVienById(id);
                if (HoTen is null)
                {
                    return BadRequest("Không tìm thấy người dùng.");
                }
                return Ok(HoTen);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
