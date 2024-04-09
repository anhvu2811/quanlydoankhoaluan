using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class ThoiGianDangKyDTO
    {
        public string ThoiGianDangKyID { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        public LoaiDeTaiModel LoaiDeTai { get; set; }
    }
}
