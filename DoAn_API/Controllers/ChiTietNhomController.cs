using DoAn_API.DTO;
using DoAn_API.Models;
using DoAn_API.Repository;
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
    public class ChiTietNhomController : ControllerBase
    {
        private readonly IChiTietNhomRepository _chiTietNhomRepository;
        public ChiTietNhomController(IChiTietNhomRepository chiTietNhomRepository)
        {
            _chiTietNhomRepository = chiTietNhomRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-chi-tiet-nhom")]
        public IActionResult getAllChiTietNhom()
        {
            try
            {
                var chitiet = _chiTietNhomRepository.getAllChiTietNhom();
                if (!chitiet.Any())
                {
                    return BadRequest("Không tìm thấy chi tiết nhóm.");
                }
                return Ok(chitiet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-chi-tiet-nhom")]
        public IActionResult createChiTietNhom(ChiTietNhomDTO chitiet)
        {
            try
            {
                var kt = _chiTietNhomRepository.getAllChiTietNhom().Where(q => q.ChiTietNhomID == chitiet.ChiTietNhomID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                ChiTietNhomModel chiTietNhomModel = new ChiTietNhomModel
                {
                    ChiTietNhomID = chitiet.ChiTietNhomID,
                    NhomID = chitiet.Nhom.NhomID,
                    SinhVienID = chitiet.SinhVien.SinhVienID,
                    SoLuong = chitiet.SoLuong,
                };
                _chiTietNhomRepository.createChiTietNhom(chiTietNhomModel);
                return Ok(chiTietNhomModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-chi-tiet-nhom")]
        public IActionResult updateChiTietNhom(ChiTietNhomDTO chitiet)
        {
            try
            {
                ChiTietNhomModel chiTietNhomModel = new ChiTietNhomModel
                {
                    ChiTietNhomID = chitiet.ChiTietNhomID,
                    NhomID = chitiet.Nhom.NhomID,
                    SinhVienID = chitiet.SinhVien.SinhVienID,
                    SoLuong = chitiet.SoLuong,
                };
                _chiTietNhomRepository.updateChiTietNhom(chiTietNhomModel);
                return Ok(chiTietNhomModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-chi-tiet-nhom")]
        public IActionResult deleteChiTietNhom(string id)
        {
            try
            {
                bool chitiet = _chiTietNhomRepository.deleteChiTietNhom(id);
                if (!chitiet)
                {
                    return BadRequest("Không tìm thấy chi tiết nhóm để xóa.");
                }
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-chi-tiet-nhom-by-nhom-id/{nhomId}")]
        public IActionResult getChiTietNhomTheoNhomID(string nhomId)
        {
            try
            {
                var chitiet = _chiTietNhomRepository.getChiTietNhomByNhomID(nhomId);
                if (chitiet == null || !chitiet.Any())
                {
                    return BadRequest($"Không tìm thấy chi tiết nhóm cho Nhóm ID {nhomId}.");
                }
                return Ok(chitiet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-latest-chi-tiet-nhom-id")]
        public IActionResult getLatestDeTaiId()
        {
            try
            {
                var latestCTNhom = _chiTietNhomRepository.getAllChiTietNhom().OrderByDescending(n => n.ChiTietNhomID).FirstOrDefault();
                if (latestCTNhom == null)
                {
                    return Ok("CT001"); // Hoặc mã mặc định nếu không có đề tài nào trong hệ thống
                }

                // Lấy số từ mã đề tài cuối cùng và tăng lên 1
                var lastCTNhomNumber = int.Parse(latestCTNhom.ChiTietNhomID.Replace("CT", ""));
                var newCTNhomNumber = lastCTNhomNumber;

                // Tạo mã mới và trả về
                var newCTNhomId = $"CT{newCTNhomNumber.ToString().PadLeft(3, '0')}";
                return Ok(newCTNhomId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("/api/[Controller]/check-sinh-vien-da-dang-ky/{sinhVienId}")]
        public IActionResult CheckSinhVienDaDangKy(string sinhVienId)
        {
            try
            {
                var exists = _chiTietNhomRepository.getAllChiTietNhom().Any(s => s.SinhVien.SinhVienID == sinhVienId);
                return Ok(new { exists });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-id-by-sinh-vien-id/{sinhVienId}")]
        public IActionResult GetDeTaiIDsBySinhVienID(string sinhVienId)
        {
            try
            {
                var deTaiIds = _chiTietNhomRepository.GetDeTaiIdsBySinhVienId(sinhVienId);
                if (deTaiIds == null || deTaiIds.Count == 0)
                {
                    return BadRequest($"Không tìm thấy đề tài cho Sinh Viên ID {sinhVienId}.");
                }
                return Ok(deTaiIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
