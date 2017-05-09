using System.Runtime.Serialization;

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Vui lòng nhập họ")]
        public string Ho { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string Ten { get; set; }

        [Display(Name = "Giới tính")]
        public bool? GioiTinh { get; set; }

        [Display(Name = "Ngày vào làm")]
        [Required(ErrorMessage = "Vui lòng nhập ngày vào làm")]
        public DateTime? NgayVaoLam { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        public DateTime? NgaySinh { get; set; }
        
        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập số CMND")]
        public string CMND { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email sai định dạng")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string DienThoai { get; set; }

        [StringLength(500)]
        [Display(Name = "Avatar")]
        public string AnhDaiDien { get; set; }

        [Display(Name = "Chức vụ")]
        public int? IDChucVu { get; set; }

        [Display(Name = "Phòng ban")]
        public int? IDPhongBan { get; set; }

        [Display(Name = "Hệ số lương")]
        [Required(ErrorMessage = "Vui lòng nhập hệ số lương")]
        public int? IDHeSoLuong { get; set; }
    }
}
