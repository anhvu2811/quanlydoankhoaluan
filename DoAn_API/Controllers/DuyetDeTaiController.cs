using DoAn_API.DTO;
using DoAn_API.Models;
using DoAn_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyetDeTaiController : ControllerBase
    {
        private readonly IDuyetDeTaiRepository _duyetDeTaiRepository;
        public DuyetDeTaiController(IDuyetDeTaiRepository duyetDeTaiRepository)
        {
            _duyetDeTaiRepository = duyetDeTaiRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-duyet-de-tai")]
        public IActionResult getAllDuyetDeTai()
        {
            try
            {
                var duyet = _duyetDeTaiRepository.getAllDuyetDeTai();
                if (!duyet.Any())
                {
                    return BadRequest("Không tìm thấy duyệt đề tài.");
                }
                return Ok(duyet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-duyet-de-tai")]
        public IActionResult createDuyetDeTai(DuyetDeTaiDTO duyet)
        {
            try
            {
                var kt = _duyetDeTaiRepository.getAllDuyetDeTai().Where(q => q.DuyetID == duyet.DuyetID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                DuyetDeTaiModel duyetDeTaiModel = new DuyetDeTaiModel
                {
                    DuyetID = duyet.DuyetID,
                    NgayDuyet = duyet.NgayDuyet,
                    TrangThai = duyet.TrangThai,
                    NoiDung = duyet.NoiDung,
                    DeTaiID = duyet.DeTai.DeTaiID,
                    GiangVienID = duyet.GiangVien.GiangVienID,
                };
                _duyetDeTaiRepository.createDuyetDeTai(duyetDeTaiModel);
                return Ok(duyetDeTaiModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-duyet-de-tai")]
        public IActionResult updateDuyetDeTai(DuyetDeTaiDTO duyet)
        {
            try
            {
                DuyetDeTaiModel duyetDeTaiModel = new DuyetDeTaiModel
                {
                    DuyetID = duyet.DuyetID,
                    DeTaiID = duyet.DeTai.DeTaiID,
                    GiangVienID = duyet.GiangVien.GiangVienID
                };
                _duyetDeTaiRepository.updateDuyetDeTai(duyetDeTaiModel);
                return Ok(duyetDeTaiModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-trang-thai")]
        public IActionResult updateTrangThaiDeTai(string duyetID, string trangThai)
        {
            try
            {
                _duyetDeTaiRepository.updateTrangThaiDuyet(duyetID, trangThai);
                return Ok("Trang thai duoc cap nhat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-duyet-de-tai")]
        public IActionResult deleteDuyetDeTai(string id)
        {
            try
            {
                bool duyet = _duyetDeTaiRepository.deleteDuyetDeTai(id);
                if (!duyet)
                {
                    return BadRequest("Không tìm thấy duyệt đề tài để xóa để xóa.");
                }
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-latest-duyet-id")]
        public IActionResult getLatestDuyetDeTaiId()
        {
            try
            {
                var latestDuyet = _duyetDeTaiRepository.getAllDuyetDeTai().OrderByDescending(dt => dt.DuyetID).FirstOrDefault();
                if (latestDuyet == null)
                {
                    return Ok("DDT001");
                }

                var lastDuyetNumber = int.Parse(latestDuyet.DuyetID.Replace("DDT", ""));
                var newDuyetNumber = lastDuyetNumber;

                var newDuyetId = $"DDT{newDuyetNumber.ToString().PadLeft(3, '0')}";
                return Ok(newDuyetId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-last-duyet-de-tai")]
        public IActionResult GetLatestDuyetDeTaiId()
        {
            try
            {
                var latestDuyet = _duyetDeTaiRepository.getAllDuyetDeTai().OrderByDescending(dt => dt.DuyetID).FirstOrDefault();
                if (latestDuyet == null)
                {
                    return Ok("DT001"); 
                }

                return Ok(latestDuyet.DuyetID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-de-tai-fail-by-sinh-vien")]
        public ActionResult<List<DuyetDeTaiDTO>> GetDuyetDeTaiBySinhVienIDAndStatus(string sinhVienID, string trangThai)
        {
            try
            {
                var duyetDeTaiList = _duyetDeTaiRepository.GetDuyetDeTaiBySinhVienIDAndStatus(sinhVienID, trangThai);
                return Ok(duyetDeTaiList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-de-tai-fail-by-giang-vien")]
        public ActionResult<List<DuyetDeTaiDTO>> GetDuyetDeTaiByGiangVienIDAndStatus(string giangVienID, string trangThai)
        {
            try
            {
                var duyetDeTaiList = _duyetDeTaiRepository.GetDuyetDeTaiByGiangVienIDAndStatus(giangVienID, trangThai);
                return Ok(duyetDeTaiList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-duyet-de-tai-thanh-cong")]
        public ActionResult<List<DuyetDeTaiDTO>> GetDuyetDeTaiThanhCong(string giangVienID, string trangThai)
        {
            try
            {
                var duyetDeTaiList = _duyetDeTaiRepository.GetDuyetDeTaiThanhCong(giangVienID, trangThai);
                return Ok(duyetDeTaiList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
