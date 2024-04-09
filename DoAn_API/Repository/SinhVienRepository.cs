using DoAn_API.Data;
using DoAn_API.DTO;
using DoAn_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_API.Repository
{
    public interface ISinhVienRepository
    {
        List<SinhVienDTO> getAllSinhVien();
        SinhVienDTO getSinhVienById(string id);
        void createSinhVien(SinhVienModel nguoidung);
        void updateSinhVien(SinhVienModel nguoidung);
        bool deleteSinhVien(string id);
        SinhVienModel GetSinhVienByUserNameAndPassword(string username, string password);
        void changePassword(string id, string oldPassword, string newPassword);
        string getRoleNameByUserId(string id);

        string GetHoTenSinhVienById(string id);
    }
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly MyDbContext _context;
        public SinhVienRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createSinhVien(SinhVienModel nguoidung)
        {
            try
            {
                nguoidung.Password = HashPassword(nguoidung.Password);
                _context.SinhVienModels.Add(nguoidung);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteSinhVien(string id)
        {
            try
            {
                var nguoidung = _context.SinhVienModels.FirstOrDefault(q => q.SinhVienID == id);
                if (nguoidung is null)
                {
                    return false;
                }
                _context.SinhVienModels.Remove(nguoidung);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SinhVienDTO> getAllSinhVien()
        {
            var nguoidung = _context.SinhVienModels
                .Include(nd => nd.NhomQuyen)
                .Include(nd => nd.Lop)
                .Select(nd => new SinhVienDTO
                {
                    SinhVienID = nd.SinhVienID,
                    HoTen = nd.HoTen,
                    NgaySinh = nd.NgaySinh,
                    GioiTinh = nd.GioiTinh,
                    DiaChi = nd.DiaChi,
                    SDT = nd.SDT,
                    Email = nd.Email,
                    Password = nd.Password,
                    Lop = nd.Lop,
                    NhomQuyen = nd.NhomQuyen,
                }).ToList();
            return nguoidung;
        }

        public SinhVienDTO getSinhVienById(string id)
        {
            var nd = _context.SinhVienModels
                .Include(nd => nd.Lop)
                .Include(nd => nd.NhomQuyen)
                .FirstOrDefault(c => c.SinhVienID == id);
            if (nd != null)
            {
                var nguoidungModel = new SinhVienDTO
                {
                    SinhVienID = nd.SinhVienID,
                    HoTen = nd.HoTen,
                    NgaySinh = nd.NgaySinh,
                    GioiTinh = nd.GioiTinh,
                    DiaChi = nd.DiaChi,
                    SDT = nd.SDT,
                    Email = nd.Email,
                    Password = nd.Password,
                    Lop = nd.Lop,
                    NhomQuyen = nd.NhomQuyen,
                };
                return nguoidungModel;
            }
            return null;
        }

        public SinhVienModel GetSinhVienByUserNameAndPassword(string id, string password)
        {
            return _context.SinhVienModels.SingleOrDefault(p => p.SinhVienID == id && p.Password == password);
        }

        public void updateSinhVien(SinhVienModel nguoidung)
        {
            try
            {
                nguoidung.Password = HashPassword(nguoidung.Password);
                _context.SinhVienModels.Update(nguoidung);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void changePassword(string id, string oldPassword, string newPassword)
        {
            try
            {
                var nguoidung = _context.SinhVienModels.FirstOrDefault(p => p.SinhVienID == id);
                if (nguoidung != null)
                {
                    if (nguoidung.Password == HashPassword(oldPassword))
                    {
                        nguoidung.Password = HashPassword(newPassword);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Mật khẩu cũ không đúng.");
                    }
                }
                else
                {
                    throw new Exception("Người dùng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getRoleNameByUserId(string id)
        {
            var roleName = _context.SinhVienModels.Where(u => u.SinhVienID == id).Select(u => u.NhomQuyen.TenNhomQuyen).FirstOrDefault();
            return roleName;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public string GetHoTenSinhVienById(string id)
        {
            var sinhVien = _context.SinhVienModels
                .FirstOrDefault(c => c.SinhVienID == id);

            if (sinhVien != null)
            {
                return sinhVien.HoTen;
            }

            return null;
        }
    }
}
