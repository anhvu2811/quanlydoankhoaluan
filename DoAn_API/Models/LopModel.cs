using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("Lop")]
    public class LopModel
    {
        [Key]
        [MaxLength(45)]
        public string LopID { get; set; }
        [MaxLength(255)]
        public string TenLop { get; set; }
        [ForeignKey("KhoaID")]
        [MaxLength(45)]
        public string KhoaID { get; set; }
        public KhoaModel Khoa { get; set; }
    }
}
