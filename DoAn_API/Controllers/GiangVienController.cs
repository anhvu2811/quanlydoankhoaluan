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
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienRepository _nguoiDungRepository;
        private readonly AuthenticationService _authenticationService;
        public GiangVienController(IGiangVienRepository nguoiDungRepository, AuthenticationService authenticationService)
        {
            _nguoiDungRepository = nguoiDungRepository;
            _authenticationService = authenticationService;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-giang-vien")]
        public IActionResult getAllGiangVien()
        {
            try
            {
                var user = _nguoiDungRepository.getAllGiangVien().ToList();
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
        [Route("/api/[Controller]/get-giang-vien-by-id")]
        public IActionResult getGiangVienById(string id)
        {
            try
            {
                var user = _nguoiDungRepository.getGiangVienById(id);
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
        [Route("/api/[Controller]/create-giang-vien")]
        public IActionResult createGiangVien(GiangVienDTO nguoidung)
        {
            try
            {
                var kt = _nguoiDungRepository.getAllGiangVien().Where(c => c.GiangVienID == nguoidung.GiangVienID);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                GiangVienModel nguoidungModel = new GiangVienModel
                {
                    GiangVienID = nguoidung.GiangVienID,
                    HoTen = nguoidung.HoTen,
                    NgaySinh = nguoidung.NgaySinh,
                    GioiTinh = nguoidung.GioiTinh,
                    DiaChi = nguoidung.DiaChi,
                    SDT = nguoidung.SDT,
                    Email = nguoidung.Email,
                    Password = nguoidung.Password,
                    KhoaID = nguoidung.Khoa.KhoaID,
                    NhomQuyenID = nguoidung.NhomQuyen.NhomQuyenID
                };
                _nguoiDungRepository.createGiangVien(nguoidungModel);
                return Ok(nguoidungModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-giang-vien")]
        public IActionResult updateGiangVien(GiangVienDTO nguoidung)
        {
            try
            {
                GiangVienModel nguoidungModel = new GiangVienModel
                {
                    GiangVienID = nguoidung.GiangVienID,
                    HoTen = nguoidung.HoTen,
                    NgaySinh = nguoidung.NgaySinh,
                    GioiTinh = nguoidung.GioiTinh,
                    DiaChi = nguoidung.DiaChi,
                    SDT = nguoidung.SDT,
                    Email = nguoidung.Email,
                    Password = nguoidung.Password,
                    KhoaID = nguoidung.Khoa.KhoaID,
                    NhomQuyenID = nguoidung.NhomQuyen.NhomQuyenID
                };
                _nguoiDungRepository.updateGiangVien(nguoidungModel);
                return Ok(nguoidungModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-giang-vien")]
        public IActionResult deleteGiangVien(string id)
        {
            try
            {
                var user = _nguoiDungRepository.deleteGiangVien(id);
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
                _nguoiDungRepository.changePassword(userId, oldPassword, newPassword);
                return Ok("Mật khẩu đã được thay đổi thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
