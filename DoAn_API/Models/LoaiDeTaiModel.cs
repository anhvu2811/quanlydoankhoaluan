using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.Models
{
    [Table("LoaiDeTai")]
    public class LoaiDeTaiModel
    {
        [Key]
        [MaxLength(45)]
        public string LoaiDeTaiID { get; set; }
        [MaxLength(255)]
        public string TenLoaiDeTai { get; set; }
    }
}
