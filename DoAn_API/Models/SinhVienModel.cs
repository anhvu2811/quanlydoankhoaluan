using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("SinhVien")]
    public class SinhVienModel
    {
        [Key]
        [MaxLength(45)]
        public string SinhVienID { get; set; }
        [MaxLength(100)]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        [MaxLength(100)]
        public string GioiTinh { get; set; }
        [MaxLength(255)]
        public string DiaChi { get; set; }
        [MaxLength(100)]
        public string SDT { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        [ForeignKey("LopID")]
        [MaxLength(45)]
        public string LopID { get; set; }
        [ForeignKey("NhomQuyenID")]
        [MaxLength(45)]
        public string NhomQuyenID { get; set; }
        public LopModel Lop { get; set; }
        public NhomQuyenModel NhomQuyen { get; set; }
    }
}
