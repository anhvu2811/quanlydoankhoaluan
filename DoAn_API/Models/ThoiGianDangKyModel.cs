using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("ThoiGianDangKy")]
    public class ThoiGianDangKyModel
    {
        [Key]
        [MaxLength(45)]
        public string ThoiGianDangKyID { get; set; }
        public DateTime BatDau { get; set; }
        public DateTime KetThuc { get; set; }
        [ForeignKey("LoaiDeTaiID")]
        [MaxLength(45)]
        public string LoaiDeTaiID { get; set; }
        public LoaiDeTaiModel LoaiDeTai { get; set; }

    }
}
