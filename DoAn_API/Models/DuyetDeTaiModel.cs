using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("DuyetDeTai")]
    public class DuyetDeTaiModel
    {
        [Key]
        [MaxLength(45)]
        public string DuyetID { get; set; }
        public DateTime NgayDuyet { get; set; }
        [MaxLength(255)]
        public string TrangThai { get; set; }
        [ForeignKey("DeTaiID")]
        [MaxLength(45)]
        public string DeTaiID { get; set; }
        [ForeignKey("GiangVienID")]
        [MaxLength(45)]
        public string GiangVienID { get; set; }
        [MaxLength(255)]
        public string NoiDung { get; set; }
        public DeTaiModel DeTai { get; set; }
        public GiangVienModel GiangVien { get; set; }
    }
}
