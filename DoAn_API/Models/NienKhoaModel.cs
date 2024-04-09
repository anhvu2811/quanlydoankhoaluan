using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("NienKhoa")]
    public class NienKhoaModel
    {
        [Key]
        [MaxLength(45)]
        public string NienKhoaID { get; set; }
        [MaxLength(255)]
        public string TenNienKhoa { get; set; }
    }
}
