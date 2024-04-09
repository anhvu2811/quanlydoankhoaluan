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
    public class NhomController : ControllerBase
    {
        private readonly INhomRepository _nhomRepository;
        public NhomController(INhomRepository nhomRepository)
        {
            _nhomRepository = nhomRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-nhom")]
        public IActionResult getAllNhom()
        {
            try
            {
                var nhom = _nhomRepository.getAllNhom();
                if (!nhom.Any())
                {
                    return BadRequest("Không tìm thấy nhóm.");
                }
                return Ok(nhom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-nhom")]
        public IActionResult createNhom(NhomDTO nhom)
        {
            try
            {
                var kt = _nhomRepository.getAllNhom().Where(q => q.NhomID == nhom.NhomID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                NhomModel nhomModel = new NhomModel
                {
                    NhomID = nhom.NhomID,
                    TenNhom = nhom.TenNhom,
                    DeTaiID = nhom.DeTai.DeTaiID,
                };
                _nhomRepository.createNhom(nhomModel);
                return Ok(nhomModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-nhom")]
        public IActionResult updateNhom(NhomDTO nhom)
        {
            try
            {
                NhomModel nhomModel = new NhomModel
                {
                    NhomID = nhom.NhomID,
                    TenNhom = nhom.TenNhom,
                    DeTaiID = nhom.DeTai.DeTaiID,
                };
                _nhomRepository.updateNhom(nhomModel);
                return Ok(nhomModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-nhom")]
        public IActionResult deleteNhom(string id)
        {
            try
            {
                bool nhom = _nhomRepository.deleteNhom(id);
                if (!nhom)
                {
                    return BadRequest("Không tìm thấy nhóm để xóa.");
                }
                return Ok("Xóa thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-latest-nhom-id")]
        public IActionResult getLatestDeTaiId()
        {
            try
            {
                var latestNhom = _nhomRepository.getAllNhom().OrderByDescending(n => n.NhomID).FirstOrDefault();
                if (latestNhom == null)
                {
                    return Ok("NH001"); 
                }

                var lastNhomNumber = int.Parse(latestNhom.NhomID.Replace("NH", ""));
                var newNhomNumber = lastNhomNumber;

                // Tạo mã mới và trả về
                var newNhomId = $"NH{newNhomNumber.ToString().PadLeft(3, '0')}";
                return Ok(newNhomId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-de-tai-id-by-nhom-id")]
        public IActionResult getDeTaiID(string NhomID)
        {
            try
            {
                var nhom = _nhomRepository.GetDeTaiIDByNhomID(NhomID);
                if (!nhom.Any())
                {
                    return BadRequest("Không tìm thấy đề tài.");
                }
                return Ok(nhom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
