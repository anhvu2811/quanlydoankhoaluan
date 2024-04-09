using DoAn_API.DTO;
using DoAn_API.Models;
using DoAn_API.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class DeTaiController : ControllerBase
    {
        private readonly IDeTaiRepository _deTaiRepository;
        public DeTaiController(IDeTaiRepository deTaiRepository)
        {
            _deTaiRepository = deTaiRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-de-tai")]
        public IActionResult getAllDeTai()
        {
            try
            {
                var detai = _deTaiRepository.getAllDeTai();
                if (!detai.Any())
                {
                    return BadRequest("Không tìm thấy đề tài.");
                }
                return Ok(detai);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-by-id")]
        public IActionResult getDeTaiById(string id)
        {
            try
            {
                var dt = _deTaiRepository.GetDeTaiById(id);
                if (dt is null)
                {
                    return BadRequest("Không tìm thấy đề tài.");
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-de-tai")]
        public IActionResult createDeTai(DeTaiDTO detai)
        {
            try
            {
                var kt = _deTaiRepository.getAllDeTai().Where(q => q.DeTaiID == detai.DeTaiID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                DeTaiModel deTaiModel = new DeTaiModel
                {
                    DeTaiID = detai.DeTaiID,
                    TenDeTai = detai.TenDeTai,
                    MoTa = detai.MoTa,
                    NgayBatDau = detai.NgayBatDau,
                    NgayKetThuc = detai.NgayKetThuc,
                    TrangThai = detai.TrangThai = "Thành công",
                    NienKhoaID = detai.NienKhoa.NienKhoaID,
                    LoaiDeTaiID = detai.LoaiDeTai.LoaiDeTaiID,
                    ChuyenNganhID = detai.ChuyenNganh.ChuyenNganhID,
                    GiangVienID = detai.GiangVien.GiangVienID,
                    SinhVienID = detai.SinhVien.SinhVienID,
                };
                _deTaiRepository.createDeTai(deTaiModel);
                return Ok(deTaiModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-by-giang-vien-id")]
        public IActionResult GetDeTaiByGiangVienID(string giangVienId)
        {
            try
            {
                var detaiByGiangVien = _deTaiRepository.GetDeTaiByGiangVienId(giangVienId);
                if (!detaiByGiangVien.Any())
                {
                    return BadRequest("Không tìm thấy đề tài cho giảng viên này.");
                }
                return Ok(detaiByGiangVien);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-by-sinh-vien-id")]
        public IActionResult GetDeTaiBySinhVienID(string sinhVienId)
        {
            try
            {
                var detaiBySinhVien = _deTaiRepository.GetDeTaiBySinhVienId(sinhVienId);
                if (!detaiBySinhVien.Any())
                {
                    return BadRequest("Không tìm thấy đề tài cho sinh viên này.");
                }
                return Ok(detaiBySinhVien);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/propose-de-tai")]
        public IActionResult proposeDeTai(DeTaiDTO detai)
        {
            try
            {
                var kt = _deTaiRepository.getAllDeTai().Where(q => q.DeTaiID == detai.DeTaiID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                DeTaiModel deTaiModel = new DeTaiModel
                {
                    DeTaiID = detai.DeTaiID,
                    TenDeTai = detai.TenDeTai,
                    MoTa = detai.MoTa,
                    NgayBatDau = detai.NgayBatDau,
                    NgayKetThuc = detai.NgayKetThuc,
                    TrangThai = detai.TrangThai,
                    NienKhoaID = detai.NienKhoa.NienKhoaID,
                    LoaiDeTaiID = detai.LoaiDeTai.LoaiDeTaiID,
                    ChuyenNganhID = detai.ChuyenNganh.ChuyenNganhID,
                    GiangVienID = detai.GiangVien.GiangVienID,
                    SinhVienID = detai.SinhVien.SinhVienID,
                };
                _deTaiRepository.createDeTai(deTaiModel);
                return Ok(deTaiModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-de-tai")]
        public IActionResult updateDeTai(DeTaiDTO detai)
        {
            try
            {
                DeTaiModel deTaiModel = new DeTaiModel
                {
                    DeTaiID = detai.DeTaiID,
                    TenDeTai = detai.TenDeTai,
                    MoTa = detai.MoTa,
                    NgayBatDau = detai.NgayBatDau,
                    NgayKetThuc = detai.NgayKetThuc,
                    TrangThai = detai.TrangThai,
                    NienKhoaID = detai.NienKhoa.NienKhoaID,
                    LoaiDeTaiID = detai.LoaiDeTai.LoaiDeTaiID,
                    ChuyenNganhID = detai.ChuyenNganh.ChuyenNganhID,
                    GiangVienID = detai.GiangVien.GiangVienID,
                    SinhVienID = detai.SinhVien.SinhVienID,
                };
                _deTaiRepository.updateDeTai(deTaiModel);
                return Ok(deTaiModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-de-tai")]
        public IActionResult deleteDeTai(string id)
        {
            try
            {
                bool detai = _deTaiRepository.deleteDeTai(id);
                if (!detai)
                {
                    return BadRequest("Không tìm thấy đề tài để xóa để xóa.");
                }
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-latest-de-tai-id")]
        public IActionResult getLatestDeTaiId()
        {
            try
            {
                var latestDeTai = _deTaiRepository.getAllDeTai().OrderByDescending(dt => dt.DeTaiID).FirstOrDefault();
                if (latestDeTai == null)
                {
                    return Ok("DT001"); // Hoặc mã mặc định nếu không có đề tài nào trong hệ thống
                }

                // Lấy số từ mã đề tài cuối cùng và tăng lên 1
                var lastDeTaiNumber = int.Parse(latestDeTai.DeTaiID.Replace("DT", ""));
                var newDeTaiNumber = lastDeTaiNumber;

                // Tạo mã mới và trả về
                var newDeTaiId = $"DT{newDeTaiNumber.ToString().PadLeft(3, '0')}";
                return Ok(newDeTaiId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-trang-thai")]
        public IActionResult updateTrangThaiDeTai(string deTaiID, string trangThai)
        {
            try
            {
                _deTaiRepository.updateTrangThaiDeTai(deTaiID, trangThai);
                return Ok("Trang thai duoc cap nhat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-full-trang-thai")]
        public IActionResult updateAllTrangThaiDeTai(string trangThaiCanCapNhat, string trangThaiMoi)
        {
            try
            {
                _deTaiRepository.updateFullTrangThaiDeTai(trangThaiCanCapNhat, trangThaiMoi);
                return Ok("Trang thai duoc cap nhat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-by-nien-khoa")]
        public IActionResult GetDeTaiByNienKhoa(string nienKhoaId)
        {
            var deTaiByNienKhoa = _deTaiRepository.GetDeTaiByNienKhoa(nienKhoaId);
            if (deTaiByNienKhoa == null || deTaiByNienKhoa.Count == 0)
            {
                return NotFound("Không tìm thấy đề tài cho niên khóa này");
            }
            return Ok(deTaiByNienKhoa);
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-by-loai-de-tai")]
        public IActionResult GetDeTaiByLoaiDeTai(string loaiDeTaiId)
        {
            var deTaiByLoaiDeTai = _deTaiRepository.GetDeTaiByLoaiDeTai(loaiDeTaiId);
            if (deTaiByLoaiDeTai == null || deTaiByLoaiDeTai.Count == 0)
            {
                return NotFound("Không tìm thấy đề tài cho niên khóa này");
            }
            return Ok(deTaiByLoaiDeTai);
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-by-chuyen-nganh")]
        public IActionResult GetDeTaiByChuyenNganh(string chuyenNganhId)
        {
            var deTaiByChuyenNganh = _deTaiRepository.GetDeTaiByChuyenNganh(chuyenNganhId);
            if (deTaiByChuyenNganh == null || deTaiByChuyenNganh.Count == 0)
            {
                return NotFound("Không tìm thấy đề tài cho niên khóa này");
            }
            return Ok(deTaiByChuyenNganh);
        }
        [HttpGet]
        [Route("/api/[Controller]/get-loai-de-tai-by-de-tai-id")]
        public IActionResult GetLoaiDeTaiByDeTaiID(string DeTaiId)
        {
            var loaiDeTaiByDeTaiID = _deTaiRepository.GetLoaiDeTaiByDeTaiId(DeTaiId);
            if (loaiDeTaiByDeTaiID == null)
            {
                return NotFound("Không tìm thấy đề tài cho niên khóa này");
            }
            return Ok(loaiDeTaiByDeTaiID);
        }

        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-by-de-tai-id")]
        public IActionResult GetDeTaiByDeTaiId(string DeTaiID1,string DeTaiID2)
        {
            try
            {
                var detaiByDeTaiId = _deTaiRepository.GetDeTaiByDeTaiId(DeTaiID1, DeTaiID2);
                if (!detaiByDeTaiId.Any())
                {
                    return BadRequest("Không tìm thấy đề tài cho đê tài id này.");
                }
                return Ok(detaiByDeTaiId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
