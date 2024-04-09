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
    public class ChuyenNganhController : ControllerBase
    {
        private readonly IChuyenNganhRepository _chuyenNganhRepository;
        public ChuyenNganhController(IChuyenNganhRepository chuyenNganhRepository)
        {
            _chuyenNganhRepository = chuyenNganhRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-chuyen-nganh")]
        public IActionResult getAllChuyenNganh()
        {
            try
            {
                var cn = _chuyenNganhRepository.getAllChuyenNganh();
                if (!cn.Any())
                {
                    return BadRequest("Không tìm thấy chuyên ngành.");
                }
                return Ok(cn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-chuyen-nganh-id")]
        public IActionResult getChuyenNganhById(string id)
        {
            try
            {
                var chuyenNganh = _chuyenNganhRepository.getChuyenNganhById(id);
                if (chuyenNganh is null)
                {
                    return BadRequest("Không tìm thấy chuyên ngành.");
                }
                return Ok(chuyenNganh);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-chuyen-nganh")]
        public IActionResult createChuyenNganh(ChuyenNganhDTO cn)
        {
            try
            {
                var kt = _chuyenNganhRepository.getAllChuyenNganh().Where(q => q.ChuyenNganhID == cn.ChuyenNganhID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                ChuyenNganhModel chuyenNganhModel = new ChuyenNganhModel
                {
                    ChuyenNganhID = cn.ChuyenNganhID,
                    TenChuyenNganh = cn.TenChuyenNganh
                };
                _chuyenNganhRepository.createChuyenNganh(chuyenNganhModel);
                return Ok(chuyenNganhModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-chuyen-nganh")]
        public IActionResult updateChuyenNganh(ChuyenNganhDTO cn)
        {
            try
            {
                ChuyenNganhModel chuyenNganhModel = new ChuyenNganhModel
                {
                    ChuyenNganhID = cn.ChuyenNganhID,
                    TenChuyenNganh = cn.TenChuyenNganh
                };
                _chuyenNganhRepository.updateChuyenNganh(chuyenNganhModel);
                return Ok(chuyenNganhModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-chuyen-nganh")]
        public IActionResult deleteChuyenNganh(string id)
        {
            try
            {
                bool cn = _chuyenNganhRepository.deleteChuyenNganh(id);
                if (!cn)
                {
                    return BadRequest("Không tìm thấy chuyên ngành để xóa.");
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
