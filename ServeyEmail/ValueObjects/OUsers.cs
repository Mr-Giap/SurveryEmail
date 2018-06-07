using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects
{
    public class OUsers
    {
        [Display(Name = "ID người dùng")]
        public Guid IdUser { get; set; }

        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mật khẩu")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ và Tên")]
        public string FullName { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Mã quyền")]
        public int IdRole { get; set; }

        [Required]
        [Display(Name = "Mã nhóm")]
        public Guid IdGroup { get; set; }

        [Display(Name = "Nhớ tài khoản")]
        public bool RememberMe { get; set; }
    }
}
