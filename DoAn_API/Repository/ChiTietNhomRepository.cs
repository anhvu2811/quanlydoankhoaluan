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
    public interface IChiTietNhomRepository
    {
        List<ChiTietNhomDTO> getAllChiTietNhom();
        void createChiTietNhom(ChiTietNhomModel chitiet);
        void updateChiTietNhom(ChiTietNhomModel chitiet);
        bool deleteChiTietNhom(string id);
        List<ChiTietNhomDTO> getChiTietNhomByNhomID(string nhomId);
        List<string> GetDeTaiIdsBySinhVienId(string SVid);
    }
    public class ChiTietNhomRepository : IChiTietNhomRepository
    {
        private readonly MyDbContext _context;
        public ChiTietNhomRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createChiTietNhom(ChiTietNhomModel chitiet)
        {
            try
            {
                _context.ChiTietNhomModels.Add(chitiet);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteChiTietNhom(string id)
        {
            try
            {
                var ct = _context.ChiTietNhomModels.FirstOrDefault(q => q.ChiTietNhomID == id);
                if (ct is null)
                {
                    return false;
                }
                _context.ChiTietNhomModels.Remove(ct);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChiTietNhomDTO> getAllChiTietNhom()
        {
            var chitiet = _context.ChiTietNhomModels
               .Include(ct => ct.Nhom)
               .Include(ct => ct.SinhVien)
               .Select(ct => new ChiTietNhomDTO
               {
                   ChiTietNhomID = ct.ChiTietNhomID,
                   Nhom = ct.Nhom,
                   SinhVien = ct.SinhVien,
               }).ToList();
            return chitiet;
        }

        public void updateChiTietNhom(ChiTietNhomModel chitiet)
        {
            try
            {
                _context.ChiTietNhomModels.Update(chitiet);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChiTietNhomDTO> getChiTietNhomByNhomID(string nhomId)
        {
            var chitiet = _context.ChiTietNhomModels
                .Include(ct => ct.Nhom)
                .Include(ct => ct.SinhVien)
                .Where(ct => ct.NhomID == nhomId)
                .Select(ct => new ChiTietNhomDTO
                {
                    ChiTietNhomID = ct.ChiTietNhomID,
                    Nhom = ct.Nhom,
                    SinhVien = ct.SinhVien,
                }).ToList();
            return chitiet;
        }
        public List<string> GetDeTaiIdsBySinhVienId(string SVid)
        {
            var deTaiIDs = _context.ChiTietNhomModels
                .Include(ctn => ctn.Nhom)
                .Include(ctn => ctn.SinhVien)
                .Where(ctn => ctn.SinhVienID == SVid)
                .Select(ctn => ctn.Nhom.DeTaiID)
                .ToList();

            return deTaiIDs;
        }
        
    }
}
