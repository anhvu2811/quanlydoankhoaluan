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
    public interface IGiangVienRepository
    {
        List<GiangVienDTO> getAllGiangVien();
        GiangVienDTO getGiangVienById(string id);
        void createGiangVien(GiangVienModel nguoidung);
        void updateGiangVien(GiangVienModel nguoidung);
        bool deleteGiangVien(string id);
        GiangVienModel GetGiangVienByUserNameAndPassword(string username, string password);
        void changePassword(string id, string oldPassword, string newPassword);
        string getRoleNameByUserId(string id);
    }
    public class GiangVienRepository : IGiangVienRepository
    {
        private readonly MyDbContext _context;
        public GiangVienRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createGiangVien(GiangVienModel nguoidung)
        {
            try
            {
                nguoidung.Password = HashPassword(nguoidung.Password);
                _context.GiangVienModels.Add(nguoidung);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteGiangVien(string id)
        {
            try
            {
                var nguoidung = _context.GiangVienModels.FirstOrDefault(q => q.GiangVienID == id);
                if (nguoidung is null)
                {
                    return false;
                }
                _context.GiangVienModels.Remove(nguoidung);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GiangVienDTO> getAllGiangVien()
        {
            var nguoidung = _context.GiangVienModels
                .Include(nd => nd.NhomQuyen)
                .Include(nd => nd.Khoa)
                .Select(nd => new GiangVienDTO
                {
                    GiangVienID = nd.GiangVienID,
                    HoTen = nd.HoTen,
                    NgaySinh = nd.NgaySinh,
                    GioiTinh = nd.GioiTinh,
                    DiaChi = nd.DiaChi,
                    SDT = nd.SDT,
                    Email = nd.Email,
                    Password = nd.Password,
                    Khoa = nd.Khoa,
                    NhomQuyen = nd.NhomQuyen,
                }).ToList();
            return nguoidung;
        }

        public GiangVienDTO getGiangVienById(string id)
        {
            var nd = _context.GiangVienModels.Include(nd => nd.NhomQuyen)
                                                    .Include(nd => nd.Khoa)
                                                    .FirstOrDefault(c => c.GiangVienID == id);
            if(nd != null)
            {
                var nguoidungModel = new GiangVienDTO
                {
                    GiangVienID = nd.GiangVienID,
                    HoTen = nd.HoTen,
                    NgaySinh = nd.NgaySinh,
                    GioiTinh = nd.GioiTinh,
                    DiaChi = nd.DiaChi,
                    SDT = nd.SDT,
                    Email = nd.Email,
                    Password = nd.Password,
                    Khoa = nd.Khoa,
                    NhomQuyen = nd.NhomQuyen,
                };
                return nguoidungModel;
            }
            return null;
        }

        public GiangVienModel GetGiangVienByUserNameAndPassword(string id, string password)
        {
            return _context.GiangVienModels.SingleOrDefault(p => p.GiangVienID == id && p.Password == password);
        }

        public void updateGiangVien(GiangVienModel nguoidung)
        {
            try
            {
                nguoidung.Password = HashPassword(nguoidung.Password);
                _context.GiangVienModels.Update(nguoidung);
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
                var nguoidung = _context.GiangVienModels.FirstOrDefault(p => p.GiangVienID == id);
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
            var roleName = _context.GiangVienModels.Where(u => u.GiangVienID == id).Select(u => u.NhomQuyen.TenNhomQuyen).FirstOrDefault();
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
    }
}
