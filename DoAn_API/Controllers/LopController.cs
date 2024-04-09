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
    public class LopController : ControllerBase
    {
        private readonly ILopRepository _lopRepository;
        public LopController(ILopRepository lopRepository)
        {
            _lopRepository = lopRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-lop")]
        public IActionResult getAllLop()
        {
            try
            {
                var lop = _lopRepository.getAllLop();
                if (!lop.Any())
                {
                    return BadRequest("Không tìm thấy lớp.");
                }
                return Ok(lop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-lop")]
        public IActionResult createLop(LopDTO lop)
        {
            try
            {
                var kt = _lopRepository.getAllLop().Where(q => q.LopID == lop.LopID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                LopModel lopModel = new LopModel
                {
                    LopID = lop.LopID,
                    TenLop = lop.TenLop,
                    KhoaID = lop.Khoa.KhoaID,
                };
                _lopRepository.createLop(lopModel);
                return Ok(lopModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-lop")]
        public IActionResult updateLop(LopDTO lop)
        {
            try
            {
                LopModel lopModel = new LopModel
                {
                    LopID = lop.LopID,
                    TenLop = lop.TenLop,
                    KhoaID = lop.Khoa.KhoaID,
                };
                _lopRepository.updateLop(lopModel);
                return Ok(lopModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-lop")]
        public IActionResult deleteLop(string id)
        {
            try
            {
                bool lop = _lopRepository.deleteLop(id);
                if (!lop)
                {
                    return BadRequest("Không tìm thấy lớp để xóa.");
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
