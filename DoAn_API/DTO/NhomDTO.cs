using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class NhomDTO
    {
        public string NhomID { get; set; }
        public string TenNhom { get; set; }
        public DeTaiModel DeTai { get; set; }
    }
}
