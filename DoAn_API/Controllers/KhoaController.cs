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
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaRepository _khoaRepository;
        public KhoaController(IKhoaRepository khoaRepository)
        {
            _khoaRepository = khoaRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-khoa")]
        public IActionResult getAllKhoa()
        {
            try
            {
                var khoa = _khoaRepository.getAllKhoa();
                if (!khoa.Any())
                {
                    return BadRequest("Không tìm thấy khoa.");
                }
                return Ok(khoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-khoa")]
        public IActionResult createKhoa(KhoaDTO khoa)
        {
            try
            {
                var kt = _khoaRepository.getAllKhoa().Where(q => q.KhoaID == khoa.KhoaID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                KhoaModel khoaModel = new KhoaModel
                {
                    KhoaID = khoa.KhoaID,
                    TenKhoa = khoa.TenKhoa
                };
                _khoaRepository.createKhoa(khoaModel);
                return Ok(khoaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-khoa")]
        public IActionResult updateKhoa(KhoaDTO khoa)
        {
            try
            {
                KhoaModel khoaModel = new KhoaModel
                {
                    KhoaID = khoa.KhoaID,
                    TenKhoa = khoa.TenKhoa
                };
                _khoaRepository.updateKhoa(khoaModel);
                return Ok(khoaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-khoa")]
        public IActionResult deleteKhoa(string id)
        {
            try
            {
                bool khoa = _khoaRepository.deleteKhoa(id);
                if (!khoa)
                {
                    return BadRequest("Không tìm thấy khoa để xóa.");
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
