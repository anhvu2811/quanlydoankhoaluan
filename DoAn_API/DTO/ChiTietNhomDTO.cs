using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class ChiTietNhomDTO
    {
        public string ChiTietNhomID { get; set; }
        public int SoLuong { get; set; }
        public NhomModel Nhom { get; set; }
        public SinhVienModel SinhVien { get; set; }
    }
}
