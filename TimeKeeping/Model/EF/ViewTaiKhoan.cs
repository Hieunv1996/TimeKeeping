namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewTaiKhoan")]
    public partial class ViewTaiKhoan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public long? IDNhanVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [StringLength(32)]
        public string MatKhau { get; set; }

        public int? IDQuyen { get; set; }

        public DateTime? NgayTao { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool TinhTrang { get; set; }

        [StringLength(50)]
        public string Ho { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string TenQuyen { get; set; }
    }
}
