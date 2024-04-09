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
    public interface ILopRepository
    {
        List<LopDTO> getAllLop();
        void createLop(LopModel lop);
        void updateLop(LopModel lop);
        bool deleteLop(string id);
    }
    public class LopRepository : ILopRepository
    {
        private readonly MyDbContext _context;
        public LopRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createLop(LopModel lop)
        {
            try
            {
                _context.LopModels.Add(lop);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteLop(string id)
        {
            try
            {
                var lop = _context.LopModels.FirstOrDefault(q => q.LopID == id);
                if (lop is null)
                {
                    return false;
                }
                _context.LopModels.Remove(lop);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LopDTO> getAllLop()
        {
            var lop = _context.LopModels
                .Include(nd => nd.Khoa)
                .Select(nd => new LopDTO
                {
                    LopID = nd.LopID,
                    TenLop = nd.TenLop,
                    Khoa = nd.Khoa,
                }).ToList();
            return lop;
        }

        public void updateLop(LopModel lop)
        {
            try
            {
                _context.LopModels.Update(lop);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
