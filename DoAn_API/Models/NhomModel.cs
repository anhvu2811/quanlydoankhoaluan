using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("Nhom")]
    public class NhomModel
    {
        [Key]
        [MaxLength(45)]
        public string NhomID { get; set; }
        [MaxLength(255)]
        public string TenNhom { get; set; }
        [ForeignKey("DeTaiID")]
        [MaxLength(45)]
        public string DeTaiID { get; set; }
        public DeTaiModel DeTai { get; set; }
    }
}
