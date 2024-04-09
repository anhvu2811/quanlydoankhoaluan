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
    public class NienKhoaController : ControllerBase
    {
        private readonly INienKhoaRepository _nienKhoaRepository;
        public NienKhoaController(INienKhoaRepository nienKhoaRepository)
        {
            _nienKhoaRepository = nienKhoaRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-nien-khoa")]
        public IActionResult getAllNienKhoa()
        {
            try
            {
                var nienKhoa = _nienKhoaRepository.getAllNienKhoa();
                if (!nienKhoa.Any())
                {
                    return BadRequest("Không tìm thấy niên khóa.");
                }
                return Ok(nienKhoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-nien-khoa")]
        public IActionResult createNienKhoa(NienKhoaDTO nienKhoa)
        {
            try
            {
                var kt = _nienKhoaRepository.getAllNienKhoa().Where(q => q.NienKhoaID == nienKhoa.NienKhoaID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                NienKhoaModel nienKhoaModel = new NienKhoaModel
                {
                    NienKhoaID = nienKhoa.NienKhoaID,
                    TenNienKhoa = nienKhoa.TenNienKhoa
                };
                _nienKhoaRepository.createNienKhoa(nienKhoaModel);
                return Ok(nienKhoaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-nien-khoa")]
        public IActionResult updateNienKhoa(NienKhoaDTO nienKhoa)
        {
            try
            {
                NienKhoaModel nienKhoaModel = new NienKhoaModel
                {
                    NienKhoaID = nienKhoa.NienKhoaID,
                    TenNienKhoa = nienKhoa.TenNienKhoa
                };
                _nienKhoaRepository.updateNienKhoa(nienKhoaModel);
                return Ok(nienKhoaModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-nien-khoa")]
        public IActionResult deleteNienKhoa(string id)
        {
            try
            {
                bool nienKhoa = _nienKhoaRepository.deleteNienKhoa(id);
                if (!nienKhoa)
                {
                    return BadRequest("Không tìm thấy niên khoá để xóa.");
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
