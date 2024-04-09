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
    public class LoaiDeTaiController : ControllerBase
    {
        private readonly ILoaiDeTaiRepository _loaiDeTaiRepository;
        public LoaiDeTaiController(ILoaiDeTaiRepository loaiDeTaiRepository)
        {
            _loaiDeTaiRepository = loaiDeTaiRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-loai-de-tai")]
        public IActionResult getAllKhoa()
        {
            try
            {
                var khoa = _loaiDeTaiRepository.getAllLoaiDeTai();
                if (!khoa.Any())
                {
                    return BadRequest("Không tìm thấy loại đề tài.");
                }
                return Ok(khoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-loai-de-tai")]
        public IActionResult createLoaiDeTai(LoaiDeTaiDTO loai)
        {
            try
            {
                var kt = _loaiDeTaiRepository.getAllLoaiDeTai().Where(q => q.LoaiDeTaiID == loai.LoaiDeTaiID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                LoaiDeTaiModel loaiDeTaiModel = new LoaiDeTaiModel
                {
                    LoaiDeTaiID = loai.LoaiDeTaiID,
                    TenLoaiDeTai = loai.TenLoaiDeTai
                };
                _loaiDeTaiRepository.createLoaiDeTai(loaiDeTaiModel);
                return Ok(loaiDeTaiModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-loai-de-tai")]
        public IActionResult updateLoaiDeTai(LoaiDeTaiDTO loai)
        {
            try
            {
                LoaiDeTaiModel loaiDeTaiModel = new LoaiDeTaiModel
                {
                    LoaiDeTaiID = loai.LoaiDeTaiID,
                    TenLoaiDeTai = loai.TenLoaiDeTai
                };
                _loaiDeTaiRepository.updateLoaiDeTai(loaiDeTaiModel);
                return Ok(loaiDeTaiModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-loai-de-tai")]
        public IActionResult deleteLoaiDeTai(string id)
        {
            try
            {
                bool loai = _loaiDeTaiRepository.deleteLoaiDeTai(id);
                if (!loai)
                {
                    return BadRequest("Không tìm thấy loại đề tài để xóa.");
                }
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
