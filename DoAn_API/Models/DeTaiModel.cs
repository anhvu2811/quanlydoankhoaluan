using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("DeTai")]
    public class DeTaiModel
    {
        [Key]
        [MaxLength(45)]
        public string DeTaiID { get; set; }
        [MaxLength(2555)]
        public string TenDeTai { get; set; }
        [MaxLength(255)]
        public string MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        [MaxLength(255)]
        public string TrangThai { get; set; }
        [ForeignKey("NienKhoaID")]
        [MaxLength(45)]
        public string NienKhoaID { get; set; }
        [ForeignKey("LoaiDeTaiID")]
        [MaxLength(45)]
        public string LoaiDeTaiID { get; set; }
        [ForeignKey("ChuyenNganhID")]
        [MaxLength(45)]
        public string ChuyenNganhID { get; set; }
        [ForeignKey("GiangVienID")]
        [MaxLength(45)]
        public string GiangVienID { get; set; }
        [ForeignKey("SinhVienID")]
        [MaxLength(45)]
        public string SinhVienID { get; set; }
        public NienKhoaModel NienKhoa { get; set; }
        public LoaiDeTaiModel LoaiDeTai { get; set; }
        public ChuyenNganhModel ChuyenNganh { get; set; }
        public GiangVienModel GiangVien { get; set; }
        public SinhVienModel SinhVien { get; set; }
    }
}
