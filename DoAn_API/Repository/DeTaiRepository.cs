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
    public interface IDeTaiRepository
    {
        List<DeTaiDTO> getAllDeTai();
        List<DeTaiDTO> GetDeTaiByGiangVienId(string giangVienId);
        List<DeTaiDTO> GetDeTaiBySinhVienId(string sinhVienId);
        List<DeTaiDTO> GetDeTaiById(string id);
        void createDeTai(DeTaiModel dt);
        void updateDeTai(DeTaiModel dt);
        bool deleteDeTai(string id);
        void updateTrangThaiDeTai(string deTaiID, string trangThai);
        void updateFullTrangThaiDeTai(string trangThaiCanCapNhat, string trangThaiMoi);
        List<DeTaiDTO> GetDeTaiByNienKhoa(string nienKhoaId);
        List<DeTaiDTO> GetDeTaiByLoaiDeTai(string loaiDeTaiId);
        List<DeTaiDTO> GetDeTaiByChuyenNganh(string chuyenNganhId);
        string GetLoaiDeTaiByDeTaiId(string id);
        List<DeTaiDTO> GetDeTaiByDeTaiId(string DeTaiID1, string DeTaiID2);
        
        }
    public class DeTaiRepository : IDeTaiRepository
    {
        private readonly MyDbContext _context;
        public DeTaiRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createDeTai(DeTaiModel dt)
        {
            try
            {
                _context.DeTaiModels.Add(dt);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteDeTai(string id)
        {
            try
            {
                var dt = _context.DeTaiModels.FirstOrDefault(q => q.DeTaiID == id);
                if (dt is null)
                {
                    return false;
                }
                _context.DeTaiModels.Remove(dt);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DeTaiDTO> getAllDeTai()
        {
            var detai = _context.DeTaiModels
               .Include(dt => dt.NienKhoa)
               .Include(dt => dt.LoaiDeTai)
               .Include(dt => dt.ChuyenNganh)
               .Include(dt => dt.GiangVien)
               .Include(dt => dt.SinhVien)
               .Select(dt => new DeTaiDTO
               {
                   DeTaiID = dt.DeTaiID,
                   TenDeTai = dt.TenDeTai,
                   MoTa = dt.MoTa,
                   NgayBatDau = dt.NgayBatDau,
                   NgayKetThuc = dt.NgayKetThuc,
                   TrangThai = dt.TrangThai,
                   NienKhoa = dt.NienKhoa,
                   LoaiDeTai = dt.LoaiDeTai,
                   ChuyenNganh = dt.ChuyenNganh,
                   GiangVien = dt.GiangVien,
                   SinhVien = dt.SinhVien,
               }).ToList();
            return detai;
        }

        public void updateDeTai(DeTaiModel dt)
        {
            try
            {
                _context.DeTaiModels.Update(dt);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DeTaiDTO> GetDeTaiByGiangVienId(string giangVienId)
        {
            var detaiByGiangVien = _context.DeTaiModels
                .Include(dt => dt.NienKhoa)
                .Include(dt => dt.LoaiDeTai)
                .Include(dt => dt.ChuyenNganh)
                .Include(dt => dt.GiangVien)
                .Where(dt => dt.GiangVienID == giangVienId)
                .Select(dt => new DeTaiDTO
                {
                    DeTaiID = dt.DeTaiID,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    NgayBatDau = dt.NgayBatDau,
                    NgayKetThuc = dt.NgayKetThuc,
                    TrangThai = dt.TrangThai,
                    NienKhoa = dt.NienKhoa,
                    LoaiDeTai = dt.LoaiDeTai,
                    ChuyenNganh = dt.ChuyenNganh,
                    GiangVien = dt.GiangVien,
                }).ToList();
            return detaiByGiangVien;
        }
        public List<DeTaiDTO> GetDeTaiBySinhVienId(string sinhVienId)
        {
            var detaiByGiangVien = _context.DeTaiModels
                .Include(dt => dt.NienKhoa)
                .Include(dt => dt.LoaiDeTai)
                .Include(dt => dt.ChuyenNganh)
                .Include(dt => dt.GiangVien)
                .Where(dt => dt.SinhVienID == sinhVienId)
                .Select(dt => new DeTaiDTO
                {
                    DeTaiID = dt.DeTaiID,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    NgayBatDau = dt.NgayBatDau,
                    NgayKetThuc = dt.NgayKetThuc,
                    TrangThai = dt.TrangThai,
                    NienKhoa = dt.NienKhoa,
                    LoaiDeTai = dt.LoaiDeTai,
                    ChuyenNganh = dt.ChuyenNganh,
                    GiangVien = dt.GiangVien,
                }).ToList();
            return detaiByGiangVien;
        }
        public List<DeTaiDTO> GetDeTaiById(string id)
        {
            var detaiByGiangVien = _context.DeTaiModels
                .Include(dt => dt.NienKhoa)
                .Include(dt => dt.LoaiDeTai)
                .Include(dt => dt.ChuyenNganh)
                .Include(dt => dt.GiangVien)
                .Where(dt => dt.DeTaiID == id)
                .Select(dt => new DeTaiDTO
                {
                    DeTaiID = dt.DeTaiID,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    NgayBatDau = dt.NgayBatDau,
                    NgayKetThuc = dt.NgayKetThuc,
                    TrangThai = dt.TrangThai,
                    NienKhoa = dt.NienKhoa,
                    LoaiDeTai = dt.LoaiDeTai,
                    ChuyenNganh = dt.ChuyenNganh,
                    GiangVien = dt.GiangVien,
                }).ToList();
            return detaiByGiangVien;
        }
        public void updateTrangThaiDeTai(string deTaiID, string trangThai)
        {
            DeTaiModel deTai = _context.DeTaiModels.FirstOrDefault(d => d.DeTaiID == deTaiID);

            if (deTai != null)
            {
                deTai.TrangThai = trangThai;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy De Tai cần cập nhật");
            }
        }
        public void updateFullTrangThaiDeTai(string trangThaiCanCapNhat, string trangThaiMoi)
        {
            var deTaisCanCapNhat = _context.DeTaiModels.Where(d => d.TrangThai == trangThaiCanCapNhat).ToList();

            if (deTaisCanCapNhat.Any())
            {
                foreach (var deTai in deTaisCanCapNhat)
                {
                    deTai.TrangThai = trangThaiMoi;
                }

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy De Tai cần cập nhật");
            }
        }
        public List<DeTaiDTO> GetDeTaiByNienKhoa(string nienKhoaId)
        {
            var detaiByNienKhoa = _context.DeTaiModels
                .Include(dt => dt.NienKhoa)
                .Include(dt => dt.LoaiDeTai)
                .Include(dt => dt.ChuyenNganh)
                .Include(dt => dt.GiangVien)
                .Where(dt => dt.NienKhoaID == nienKhoaId)
                .Select(dt => new DeTaiDTO
                {
                    DeTaiID = dt.DeTaiID,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    NgayBatDau = dt.NgayBatDau,
                    NgayKetThuc = dt.NgayKetThuc,
                    TrangThai = dt.TrangThai,
                    NienKhoa = dt.NienKhoa,
                    LoaiDeTai = dt.LoaiDeTai,
                    ChuyenNganh = dt.ChuyenNganh,
                    GiangVien = dt.GiangVien,
                }).ToList();
              return detaiByNienKhoa;
        }
        public List<DeTaiDTO> GetDeTaiByLoaiDeTai(string loaiDeTaiId)
        {
            var detaiByLoaiDeTai = _context.DeTaiModels
                .Include(dt => dt.NienKhoa)
                .Include(dt => dt.LoaiDeTai)
                .Include(dt => dt.ChuyenNganh)
                .Include(dt => dt.GiangVien)
                .Where(dt => dt.LoaiDeTaiID == loaiDeTaiId)
                .Select(dt => new DeTaiDTO
                {
                    DeTaiID = dt.DeTaiID,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    NgayBatDau = dt.NgayBatDau,
                    NgayKetThuc = dt.NgayKetThuc,
                    TrangThai = dt.TrangThai,
                    NienKhoa = dt.NienKhoa,
                    LoaiDeTai = dt.LoaiDeTai,
                    ChuyenNganh = dt.ChuyenNganh,
                    GiangVien = dt.GiangVien,
                }).ToList();
            return detaiByLoaiDeTai;
        }
        public List<DeTaiDTO> GetDeTaiByChuyenNganh(string chuyenNganhId)
        {
            var detaiByChuyenNganh = _context.DeTaiModels
                .Include(dt => dt.NienKhoa)
                .Include(dt => dt.LoaiDeTai)
                .Include(dt => dt.ChuyenNganh)
                .Include(dt => dt.GiangVien)
                .Where(dt => dt.ChuyenNganhID == chuyenNganhId)
                .Select(dt => new DeTaiDTO
                {
                    DeTaiID = dt.DeTaiID,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    NgayBatDau = dt.NgayBatDau,
                    NgayKetThuc = dt.NgayKetThuc,
                    TrangThai = dt.TrangThai,
                    NienKhoa = dt.NienKhoa,
                    LoaiDeTai = dt.LoaiDeTai,
                    ChuyenNganh = dt.ChuyenNganh,
                    GiangVien = dt.GiangVien,
                }).ToList();
            return detaiByChuyenNganh;
        }
        public string GetLoaiDeTaiByDeTaiId(string id)
        {
            var loaiDeTai = _context.DeTaiModels
                .Include(dt => dt.LoaiDeTai)
                .Where(dt => dt.DeTaiID == id)
                .Select(dt => dt.LoaiDeTai.LoaiDeTaiID) // Lấy giá trị cụ thể mà mày muốn từ LoaiDeTai
                .FirstOrDefault(); // Sử dụng FirstOrDefault() để trả về null nếu không tìm thấy

            return loaiDeTai;
        }
        public List<DeTaiDTO> GetDeTaiByDeTaiId(string DeTaiID1, string DeTaiID2)
        {
            var detaiByDeTaiId = _context.DeTaiModels
                .Include(dt => dt.NienKhoa)
                .Include(dt => dt.LoaiDeTai)
                .Include(dt => dt.ChuyenNganh)
                .Include(dt => dt.GiangVien)
                .Where(dt => dt.DeTaiID == DeTaiID1 || dt.DeTaiID == DeTaiID2)
                .Select(dt => new DeTaiDTO
                {
                    DeTaiID = dt.DeTaiID,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    NgayBatDau = dt.NgayBatDau,
                    NgayKetThuc = dt.NgayKetThuc,
                    TrangThai = dt.TrangThai,
                    NienKhoa = dt.NienKhoa,
                    LoaiDeTai = dt.LoaiDeTai,
                    ChuyenNganh = dt.ChuyenNganh,
                    GiangVien = dt.GiangVien,
                }).ToList();
            return detaiByDeTaiId;
        }

    }
}
