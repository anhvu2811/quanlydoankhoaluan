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
    public class ThoiGianDangKyController : ControllerBase
    {
        private readonly IThoiGianDangKyRepository _thoiGianDangKyRepository;
        public ThoiGianDangKyController(IThoiGianDangKyRepository thoiGianDangKyRepository)
        {
            _thoiGianDangKyRepository = thoiGianDangKyRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-thoi-gian-dang-ky")]
        public IActionResult getAllSinhVien()
        {
            try
            {
                var thoiGian = _thoiGianDangKyRepository.getAllThoiGianDangKy().ToList();
                if (!thoiGian.Any())
                {
                    return BadRequest("Không có.");
                }
                return Ok(thoiGian);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-thoi-gian-dang-ky")]
        public IActionResult createThoiGianDangKy(ThoiGianDangKyDTO thoiGian)
        {
            try
            {
                var kt = _thoiGianDangKyRepository.getAllThoiGianDangKy().Where(c => c.ThoiGianDangKyID == thoiGian.ThoiGianDangKyID);
                if (kt.Any())
                {
                    return BadRequest("Id này đã tồn tại ! Hãy nhập mã khác.");
                }
                ThoiGianDangKyModel thoiGianModel = new ThoiGianDangKyModel
                {
                    ThoiGianDangKyID = thoiGian.ThoiGianDangKyID,
                    BatDau = thoiGian.BatDau,
                    KetThuc = thoiGian.KetThuc,
                    LoaiDeTaiID = thoiGian.LoaiDeTai.LoaiDeTaiID
                };
                _thoiGianDangKyRepository.createThoiGianDangKy(thoiGianModel);
                return Ok(thoiGianModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-thoi-gian-dang-ky")]
        public IActionResult updateThoiGianDangKy(ThoiGianDangKyDTO thoiGian)
        {
            try
            {
                ThoiGianDangKyModel thoiGianModel = new ThoiGianDangKyModel
                {
                    ThoiGianDangKyID = thoiGian.ThoiGianDangKyID,
                    BatDau = thoiGian.BatDau,
                    KetThuc = thoiGian.KetThuc,
                    LoaiDeTaiID = thoiGian.LoaiDeTai.LoaiDeTaiID
                };
                _thoiGianDangKyRepository.updateThoiGianDangKy(thoiGianModel);
                return Ok(thoiGianModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-thoi-gian-dang-ky")]
        public IActionResult deleteDangKyDeTai(string id)
        {
            try
            {
                var user = _thoiGianDangKyRepository.deleteThoiGianDangKy(id);
                if (!user)
                {
                    return BadRequest("Không tìm thấy để xóa.");
                }
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-thoi-gian-dang-ky-do-an")]
        public IActionResult GetThoiGianDangKyByDoAn()

        {
            try
            {
                var thoiGian = _thoiGianDangKyRepository.getThoiGianDangKyByDoAn().ToList();
                if (!thoiGian.Any())
                {
                    return BadRequest("Không có.");
                }
                return Ok(thoiGian);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-thoi-gian-dang-ky-khoa-luan")]
        public IActionResult GetThoiGianDangKyByKhoaLuan()

        {
            try
            {
                var thoiGian = _thoiGianDangKyRepository.getThoiGianDangKyByKhoaLuan().ToList();
                if (!thoiGian.Any())
                {
                    return BadRequest("Không có.");
                }
                return Ok(thoiGian);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
