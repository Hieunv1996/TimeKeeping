namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewNhanVien")]
    public partial class ViewNhanVien
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(50)]
        public string Ho { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public bool? GioiTinh { get; set; }

        public DateTime? NgayVaoLam { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(20)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(500)]
        public string AnhDaiDien { get; set; }

        public int? IDChucVu { get; set; }

        public int? IDPhongBan { get; set; }

        public int? IDHeSoLuong { get; set; }

        [StringLength(50)]
        public string TenChucVu { get; set; }

        [StringLength(50)]
        public string TenPhongBan { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal HeSoLuong { get; set; }
    }
}
