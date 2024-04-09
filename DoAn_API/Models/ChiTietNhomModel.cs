using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("ChiTietNhom")]
    public class ChiTietNhomModel
    {
        [Key]
        [MaxLength(45)]
        public string ChiTietNhomID { get; set; }
        [ForeignKey("NhomID")]
        [MaxLength(45)]
        public string NhomID { get; set; }
        [ForeignKey("SinhVienID")]
        [MaxLength(45)]
        public string SinhVienID { get; set; }
        public int SoLuong { get; set; }
        public NhomModel Nhom { get; set; }
        public SinhVienModel SinhVien { get; set; }
    }
}
