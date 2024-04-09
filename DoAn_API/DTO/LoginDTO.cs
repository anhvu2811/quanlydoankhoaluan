using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_API.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "UserID is required")]
        public string? UserID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
