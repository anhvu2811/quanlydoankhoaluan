using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("NhomQuyen")]
    public class NhomQuyenModel
    {
        [Key]
        [MaxLength(45)]
        public string NhomQuyenID { get; set; }
        [MaxLength(255)]
        public string TenNhomQuyen { get; set; }
        [MaxLength(255)]
        public string MoTa { get; set; }
    }
}
