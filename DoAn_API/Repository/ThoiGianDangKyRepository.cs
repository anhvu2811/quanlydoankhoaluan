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
    public interface IThoiGianDangKyRepository
    {
        List<ThoiGianDangKyDTO> getAllThoiGianDangKy();
        List<ThoiGianDangKyDTO> getThoiGianDangKyByDoAn();
        List<ThoiGianDangKyDTO> getThoiGianDangKyByKhoaLuan();
        void createThoiGianDangKy(ThoiGianDangKyModel lop);
        void updateThoiGianDangKy(ThoiGianDangKyModel lop);
        bool deleteThoiGianDangKy(string id);
    }
    public class ThoiGianDangKyRepository : IThoiGianDangKyRepository
    {
        private readonly MyDbContext _context;
        public ThoiGianDangKyRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createThoiGianDangKy(ThoiGianDangKyModel thoiGian)
        {
            try
            {
                _context.ThoiGianDangKyModels.Add(thoiGian);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteThoiGianDangKy(string id)
        {
            try
            {
                var thoiGian = _context.ThoiGianDangKyModels.FirstOrDefault(q => q.ThoiGianDangKyID == id);
                if (thoiGian is null)
                {
                    return false;
                }
                _context.ThoiGianDangKyModels.Remove(thoiGian);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ThoiGianDangKyDTO> getAllThoiGianDangKy()
        {
            var thoiGian = _context.ThoiGianDangKyModels
                .Include(tg => tg.LoaiDeTai)
                .Select(tg => new ThoiGianDangKyDTO
                {
                    ThoiGianDangKyID = tg.ThoiGianDangKyID,
                    BatDau = tg.BatDau,
                    KetThuc = tg.KetThuc,
                    LoaiDeTai = tg.LoaiDeTai,
                }).ToList();
            return thoiGian;
        }

        public void updateThoiGianDangKy(ThoiGianDangKyModel thoiGian)
        {
            try
            {
                _context.ThoiGianDangKyModels.Update(thoiGian);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ThoiGianDangKyDTO> getThoiGianDangKyByDoAn()
        {
            var thoiGianByLoaiDeTai = _context.ThoiGianDangKyModels
                .Where(tg => tg.LoaiDeTaiID == "LD001")
                .Include(tg => tg.LoaiDeTai)
                .Select(tg => new ThoiGianDangKyDTO
                {
                    ThoiGianDangKyID = tg.ThoiGianDangKyID,
                    BatDau = tg.BatDau,
                    KetThuc = tg.KetThuc,
                    LoaiDeTai = tg.LoaiDeTai,
                }).ToList();
            return thoiGianByLoaiDeTai;
        }
        public List<ThoiGianDangKyDTO> getThoiGianDangKyByKhoaLuan()
        {
            var thoiGianByLoaiDeTai = _context.ThoiGianDangKyModels
                .Where(tg => tg.LoaiDeTaiID == "LD002")
                .Include(tg => tg.LoaiDeTai)
                .Select(tg => new ThoiGianDangKyDTO
                {
                    ThoiGianDangKyID = tg.ThoiGianDangKyID,
                    BatDau = tg.BatDau,
                    KetThuc = tg.KetThuc,
                    LoaiDeTai = tg.LoaiDeTai,
                }).ToList();
            return thoiGianByLoaiDeTai;
        }
    }
}
