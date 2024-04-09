using DoAn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class LopDTO
    {
        public string LopID { get; set; }
        public string TenLop { get; set; }
        public KhoaModel Khoa { get; set; }
    }
}
