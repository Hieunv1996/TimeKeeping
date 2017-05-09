namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public long ID { get; set; }

        [Display(Name = "Nhân viên")]
        [Required(ErrorMessage = "Vui lòng nhập nhân viên")]
        public long? IDNhanVien { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Quyền")]
        public int? IDQuyen { get; set; }

        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Vui lòng nhập quyền")]
        public DateTime? NgayTao { get; set; }

        [Display(Name = "Tình trạng")]
        public bool TinhTrang { get; set; }
    }
}
