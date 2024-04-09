using DoAn_API.Data;
using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Repository
{
    public interface INhomQuyenRepository
    {
        List<NhomQuyenModel> getAllNhomQuyen();
        NhomQuyenModel getNhomQuyenById(string id);
        void createNhomQuyen(NhomQuyenModel nhomquyen);
        void updateNhomQuyen(NhomQuyenModel nhomquyen);
        bool deleteNhomQuyen(string id);
    }
    public class NhomQuyenRepository : INhomQuyenRepository
    {
        private readonly MyDbContext _context;
        public NhomQuyenRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createNhomQuyen(NhomQuyenModel nhomquyen)
        {
            try
            {
                _context.NhomQuyenModels.Add(nhomquyen);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteNhomQuyen(string id)
        {
            try
            {
                var nhomquyen = _context.NhomQuyenModels.FirstOrDefault(q => q.NhomQuyenID == id);
                if(nhomquyen is null)
                {
                    return false;
                }
                _context.NhomQuyenModels.Remove(nhomquyen);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NhomQuyenModel> getAllNhomQuyen()
        {
            return _context.NhomQuyenModels.ToList();
        }
        public NhomQuyenModel getNhomQuyenById(string id)
        {
            return _context.NhomQuyenModels.FirstOrDefault(c => c.NhomQuyenID == id);
        }
        public void updateNhomQuyen(NhomQuyenModel nhomquyen)
        {
            try
            {
                _context.NhomQuyenModels.Update(nhomquyen);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
