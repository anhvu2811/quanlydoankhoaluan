using DoAn_API.Data;
using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Repository
{
    public interface IKhoaRepository
    {
        List<KhoaModel> getAllKhoa();
        void createKhoa(KhoaModel khoa);
        void updateKhoa(KhoaModel khoa);
        bool deleteKhoa(string id);
    }
    public class KhoaRepository : IKhoaRepository
    {
        private readonly MyDbContext _context;
        public KhoaRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createKhoa(KhoaModel khoa)
        {
            try
            {
                _context.KhoaModels.Add(khoa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteKhoa(string id)
        {
            try
            {
                var khoa = _context.KhoaModels.FirstOrDefault(q => q.KhoaID == id);
                if (khoa is null)
                {
                    return false;
                }
                _context.KhoaModels.Remove(khoa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<KhoaModel> getAllKhoa()
        {
            return _context.KhoaModels.ToList();
        }

        public void updateKhoa(KhoaModel khoa)
        {
            try
            {
                _context.KhoaModels.Update(khoa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
