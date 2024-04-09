using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("ChuyenNganh")]
    public class ChuyenNganhModel
    {
        [Key]
        [MaxLength(45)]
        public string ChuyenNganhID { get; set; }
        [MaxLength(255)]
        public string TenChuyenNganh { get; set; }
    }
}
