using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class DuyetDeTaiDTO
    {
        public string DuyetID { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string TrangThai { get; set; }
        public string NoiDung { get; set; }
        public DeTaiModel DeTai { get; set; }
        public GiangVienModel GiangVien { get; set; }
    }
}
