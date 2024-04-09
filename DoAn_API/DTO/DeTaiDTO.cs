using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class DeTaiDTO
    {
        public string DeTaiID { get; set; }
        public string TenDeTai { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public NienKhoaModel NienKhoa { get; set; }
        public LoaiDeTaiModel LoaiDeTai { get; set; }
        public ChuyenNganhModel ChuyenNganh { get; set; }
        public GiangVienModel GiangVien { get; set; }
        public SinhVienModel SinhVien { get; set; }
    }
}
