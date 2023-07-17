using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoiDongYVN.Models
{
    public partial class Creator
    {
        public Creator()
        {
            TblPosts = new HashSet<Post>();
        }

        public int PkICreatorId { get; set; }
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Cần nhập tên đăng nhập")]
        public string SUsername { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Cần nhập mật khẩu")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Phải dài 8 đến 20 ký tự")]
        public string SPassword { get; set; }

        [DisplayName("Nhập lại mật khẩu")]
        [Compare("SPassword", ErrorMessage = "Mật khẩu nhập lại không khớp!")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [DisplayName("Họ và tên")]
        public string SFullname { get; set; }
        [DisplayName("Địa chỉ Email")]
        public string SEmail { get; set; }
        [DisplayName("Số điện thoại")]
        public string SPhone { get; set; }
        [DisplayName("Trạng thái")]
        [Range(0,5)]
        public int? IStatus { get; set; }

        [DisplayName("Quyền")]
        public string IRole { get; set; }

        public virtual ICollection<Post> TblPosts { get; set; }
    }
}
