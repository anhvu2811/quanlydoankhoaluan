using DoAn_API.Data;
using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Repository
{
    public interface INienKhoaRepository
    {
        List<NienKhoaModel> getAllNienKhoa();
        void createNienKhoa(NienKhoaModel nienKhoa);
        void updateNienKhoa(NienKhoaModel nienKhoa);
        bool deleteNienKhoa(string id);
    }
    public class NienKhoaRepository : INienKhoaRepository
    {
        private readonly MyDbContext _context;
        public NienKhoaRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createNienKhoa(NienKhoaModel nienKhoa)
        {
            try
            {
                _context.NienKhoaModels.Add(nienKhoa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteNienKhoa(string id)
        {
            try
            {
                var nienKhoa = _context.NienKhoaModels.FirstOrDefault(q => q.NienKhoaID == id);
                if (nienKhoa is null)
                {
                    return false;
                }
                _context.NienKhoaModels.Remove(nienKhoa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NienKhoaModel> getAllNienKhoa()
        {
            return _context.NienKhoaModels.ToList();
        }

        public void updateNienKhoa(NienKhoaModel nienKhoa)
        {
            try
            {
                _context.NienKhoaModels.Update(nienKhoa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
