using DoAn_API.Data;
using DoAn_API.DTO;
using DoAn_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Repository
{
    public interface IDuyetDeTaiRepository
    {
        List<DuyetDeTaiDTO> getAllDuyetDeTai();
        void createDuyetDeTai(DuyetDeTaiModel dt);
        void updateDuyetDeTai(DuyetDeTaiModel dt);
        void updateTrangThaiDuyet(string duyetID, string trangThai);
        bool deleteDuyetDeTai(string id);
        List<DuyetDeTaiDTO> GetDuyetDeTaiBySinhVienIDAndStatus(string sinhVienID, string trangThai);
        List<DuyetDeTaiDTO> GetDuyetDeTaiByGiangVienIDAndStatus(string giangVienID, string trangThai);
        List<DuyetDeTaiDTO> GetDuyetDeTaiThanhCong(string giangVienID, string trangThai);
    }
    public class DuyetDeTaiRepository : IDuyetDeTaiRepository
    {
        private readonly MyDbContext _context;
        public DuyetDeTaiRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createDuyetDeTai(DuyetDeTaiModel dt)
        {
            try
            {
                _context.DuyetDeTaiModels.Add(dt);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteDuyetDeTai(string id)
        {
            try
            {
                var dt = _context.DuyetDeTaiModels.FirstOrDefault(q => q.DuyetID == id);
                if (dt is null)
                {
                    return false;
                }
                _context.DuyetDeTaiModels.Remove(dt);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DuyetDeTaiDTO> getAllDuyetDeTai()
        {
            var duyet = _context.DuyetDeTaiModels
               .Include(dt => dt.DeTai)
               .Include(dt => dt.GiangVien)
               .Select(dt => new DuyetDeTaiDTO
               {
                   DuyetID = dt.DuyetID,
                   NgayDuyet = dt.NgayDuyet,
                   TrangThai = dt.TrangThai,
                   DeTai = dt.DeTai,
                   GiangVien = dt.GiangVien,
                   NoiDung = dt.NoiDung,
               }).ToList();
            return duyet;
        }

        public void updateDuyetDeTai(DuyetDeTaiModel dt)
        {
            try
            {
                _context.DuyetDeTaiModels.Update(dt);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateTrangThaiDuyet(string duyetID, string trangThai)
        {
            DuyetDeTaiModel dt = _context.DuyetDeTaiModels.FirstOrDefault(d => d.DuyetID == duyetID);
            if (dt != null)
            {
                dt.TrangThai = trangThai;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy duyet cần cập nhật");
            }
        }
        public List<DuyetDeTaiDTO> GetDuyetDeTaiBySinhVienIDAndStatus(string sinhVienID, string trangThai)
        {
            var duyetDeTai = _context.DuyetDeTaiModels
                .Where(dt => dt.DeTai.SinhVienID == sinhVienID && dt.TrangThai == trangThai)
                .Include(dt => dt.DeTai) 
                    .ThenInclude(d => d.NienKhoa) 
                .Include(dt => dt.DeTai) 
                    .ThenInclude(d => d.LoaiDeTai) 
                .Include(dt => dt.DeTai) 
                    .ThenInclude(d => d.ChuyenNganh)
                 .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.GiangVien)
                .Select(dt => new DuyetDeTaiDTO
                {
                    DuyetID = dt.DuyetID,
                    NgayDuyet = dt.NgayDuyet,
                    TrangThai = dt.TrangThai,
                    DeTai = dt.DeTai,
                    GiangVien = dt.GiangVien,
                    NoiDung = dt.NoiDung,
                })
                .OrderByDescending(dt => dt.DeTai.DeTaiID)
                .ToList();

            return duyetDeTai;
        }

        public List<DuyetDeTaiDTO> GetDuyetDeTaiByGiangVienIDAndStatus(string giangVienID, string trangThai)
        {
            var duyetDeTai = _context.DuyetDeTaiModels
                .Where(dt => dt.DeTai.GiangVienID == giangVienID && dt.DeTai.SinhVienID == null && dt.TrangThai == trangThai)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.NienKhoa)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.LoaiDeTai)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.ChuyenNganh)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.GiangVien)
                .Include(dt => dt.GiangVien)
                .Select(dt => new DuyetDeTaiDTO
                {
                    DuyetID = dt.DuyetID,
                    NgayDuyet = dt.NgayDuyet,
                    TrangThai = dt.TrangThai,
                    DeTai = dt.DeTai,
                    GiangVien = dt.GiangVien,
                    NoiDung = dt.NoiDung,
                })
                .OrderByDescending(dt => dt.DeTai.DeTaiID)
                .ToList();

            return duyetDeTai;
        }
        public List<DuyetDeTaiDTO> GetDuyetDeTaiThanhCong(string giangVienID, string trangThai)
        {
            var duyetDeTai = _context.DuyetDeTaiModels
                .Where(dt => dt.GiangVienID == giangVienID && dt.TrangThai == trangThai)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.NienKhoa)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.LoaiDeTai)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.ChuyenNganh)
                .Include(dt => dt.DeTai)
                    .ThenInclude(d => d.GiangVien)
                .Include(dt => dt.GiangVien)
                .Select(dt => new DuyetDeTaiDTO
                {
                    DuyetID = dt.DuyetID,
                    NgayDuyet = dt.NgayDuyet,
                    TrangThai = dt.TrangThai,
                    DeTai = dt.DeTai,
                    GiangVien = dt.GiangVien,
                    NoiDung = dt.NoiDung,
                })
                .OrderByDescending(dt => dt.DeTai.DeTaiID)
                .ToList();

            return duyetDeTai;
        }

    }
}
