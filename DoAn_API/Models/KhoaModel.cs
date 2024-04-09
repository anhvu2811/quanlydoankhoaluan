using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("Khoa")]
    public class KhoaModel
    {
        [Key]
        [MaxLength(45)]
        public string KhoaID { get; set; }
        [MaxLength(255)]
        public string TenKhoa { get; set; }
    }
}
