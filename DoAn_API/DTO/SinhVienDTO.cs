﻿using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class SinhVienDTO
    {
        public string SinhVienID { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public LopModel Lop { get; set; }
        public NhomQuyenModel NhomQuyen { get; set; }
    }
}
