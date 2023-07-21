using System;
using System.ComponentModel.DataAnnotations;

namespace HoiDongYVN.Models.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mời nhập tên password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
