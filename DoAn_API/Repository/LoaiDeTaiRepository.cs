using DoAn_API.Data;
using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Repository
{
    public interface ILoaiDeTaiRepository
    {
        List<LoaiDeTaiModel> getAllLoaiDeTai();
        void createLoaiDeTai(LoaiDeTaiModel loai);
        void updateLoaiDeTai(LoaiDeTaiModel loai);
        bool deleteLoaiDeTai(string id);
    }
    public class LoaiDeTaiRepository : ILoaiDeTaiRepository
    {
        private readonly MyDbContext _context;
        public LoaiDeTaiRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createLoaiDeTai(LoaiDeTaiModel loai)
        {
            try
            {
                _context.LoaiDeTaiModels.Add(loai);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteLoaiDeTai(string id)
        {
            try
            {
                var loai = _context.LoaiDeTaiModels.FirstOrDefault(q => q.LoaiDeTaiID == id);
                if (loai is null)
                {
                    return false;
                }
                _context.LoaiDeTaiModels.Remove(loai);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LoaiDeTaiModel> getAllLoaiDeTai()
        {
            return _context.LoaiDeTaiModels.ToList();
        }

        public void updateLoaiDeTai(LoaiDeTaiModel loai)
        {
            try
            {
                _context.LoaiDeTaiModels.Update(loai);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
