using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeKeeping.Areas.Admin.Models
{
    public class DangNhapModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }

        public bool  Remmember { get; set; }
    }
}