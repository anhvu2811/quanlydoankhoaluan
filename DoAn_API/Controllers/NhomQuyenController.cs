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
    public class NhomQuyenController : ControllerBase
    {
        private readonly INhomQuyenRepository _nhomQuyenRepository;
        public NhomQuyenController(INhomQuyenRepository nhomQuyenRepository)
        {
            _nhomQuyenRepository = nhomQuyenRepository;
        }
        [HttpGet]
        [Route("/api/[Controller]/get-all-nhom-quyen")]
        public IActionResult getAllNhomQuyen()
        {
            try
            {
                var nhomquyen = _nhomQuyenRepository.getAllNhomQuyen();
                if (!nhomquyen.Any())
                {
                    return BadRequest("Không tìm thấy nhóm quyền.");
                }
                return Ok(nhomquyen);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[Controller]/get-nhom-quyen-by-id")]
        public IActionResult getNhomQuyenById(string id)
        {
            try
            {
                var nhomquyen = _nhomQuyenRepository.getNhomQuyenById(id);
                if (nhomquyen is null)
                {
                    return BadRequest("Không tìm thấy nhóm quyền.");
                }
                return Ok(nhomquyen);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[Controller]/create-nhom-quyen")]
        public IActionResult createNhomQuyen(NhomQuyenDTO nhomquyen)
        {
            try
            {
                var kt = _nhomQuyenRepository.getAllNhomQuyen().Where(q=>q.NhomQuyenID == nhomquyen.NhomQuyenID);
                if (kt.Any())
                {
                    return BadRequest("Id đã tồn tại. Hãy nhập mã khác");
                }
                NhomQuyenModel nhomQuyenModel = new NhomQuyenModel
                {
                    NhomQuyenID = nhomquyen.NhomQuyenID,
                    TenNhomQuyen = nhomquyen.TenNhomQuyen,
                    MoTa = nhomquyen.MoTa
                };
                _nhomQuyenRepository.createNhomQuyen(nhomQuyenModel);
                return Ok(nhomQuyenModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[Controller]/update-nhom-quyen")]
        public IActionResult updateNhomQuyen(NhomQuyenDTO nhomquyen)
        {
            try
            {
                NhomQuyenModel nhomQuyenModel = new NhomQuyenModel
                {
                    NhomQuyenID = nhomquyen.NhomQuyenID,
                    TenNhomQuyen = nhomquyen.TenNhomQuyen,
                    MoTa = nhomquyen.MoTa
                };
                _nhomQuyenRepository.updateNhomQuyen(nhomQuyenModel);
                return Ok(nhomQuyenModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[Controller]/delete-nhom-quyen")]
        public IActionResult deleteNhomQuyen(string id)
        {
            try
            {
                bool nhomquyen = _nhomQuyenRepository.deleteNhomQuyen(id);
                if (!nhomquyen)
                {
                    return BadRequest("Không tìm thấy nhóm quyền để xóa.");
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
