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
    public interface INhomRepository
    {
        List<NhomDTO> getAllNhom();
        void createNhom(NhomModel nhom);
        void updateNhom(NhomModel nhom);
        bool deleteNhom(string id);
        string GetDeTaiIDByNhomID(string nhomID);
    }
    public class NhomRepository : INhomRepository
    {
        private readonly MyDbContext _context;
        public NhomRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createNhom(NhomModel nhom)
        {
            try
            {
                _context.NhomModels.Add(nhom);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteNhom(string id)
        {
            try
            {
                var nhom = _context.NhomModels.FirstOrDefault(q => q.NhomID == id);
                if (nhom is null)
                {
                    return false;
                }
                _context.NhomModels.Remove(nhom);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NhomDTO> getAllNhom()
        {
            var nhom = _context.NhomModels
               .Include(nh => nh.DeTai)
               .Select(nh => new NhomDTO
               {
                   NhomID = nh.NhomID,
                   TenNhom = nh.TenNhom,
                   DeTai = nh.DeTai,
               }).ToList();
            return nhom;
        }

        public void updateNhom(NhomModel nhom)
        {
            try
            {
                _context.NhomModels.Update(nhom);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetDeTaiIDByNhomID(string nhomID)
        {
            try
            {
                var nhom = _context.NhomModels.FirstOrDefault(q => q.NhomID == nhomID);
                if (nhom != null)
                {
                    return nhom.DeTaiID;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
