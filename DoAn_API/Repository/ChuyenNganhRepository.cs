using DoAn_API.Data;
using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Repository
{
    public interface IChuyenNganhRepository
    {
        List<ChuyenNganhModel> getAllChuyenNganh();
        ChuyenNganhModel getChuyenNganhById(string id);
        void createChuyenNganh(ChuyenNganhModel cn);
        void updateChuyenNganh(ChuyenNganhModel cn);
        bool deleteChuyenNganh(string id);
    }
    public class ChuyenNganhRepository : IChuyenNganhRepository
    {
        private readonly MyDbContext _context;
        public ChuyenNganhRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createChuyenNganh(ChuyenNganhModel cn)
        {
            try
            {
                _context.ChuyenNganhModels.Add(cn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteChuyenNganh(string id)
        {
            try
            {
                var cn = _context.ChuyenNganhModels.FirstOrDefault(q => q.ChuyenNganhID == id);
                if (cn is null)
                {
                    return false;
                }
                _context.ChuyenNganhModels.Remove(cn);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChuyenNganhModel> getAllChuyenNganh()
        {
            return _context.ChuyenNganhModels.ToList();
        }
        public ChuyenNganhModel getChuyenNganhById(string id)
        {
            return _context.ChuyenNganhModels.FirstOrDefault(c => c.ChuyenNganhID == id);
        }
        public void updateChuyenNganh(ChuyenNganhModel cn)
        {
            try
            {
                _context.ChuyenNganhModels.Update(cn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
