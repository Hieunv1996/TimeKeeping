namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewTraLuong")]
    public partial class ViewTraLuong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public long? IDNhanVien { get; set; }

        public DateTime? DauThoiGian { get; set; }

        public DateTime? LuongCuaThang { get; set; }

        public int? TongSoCong { get; set; }

        public decimal? ThuongPhat { get; set; }

        public decimal? PhuCap { get; set; }

        public decimal? ThanhTien { get; set; }

        public decimal? DaTra { get; set; }

        public decimal? ConNo { get; set; }

        public long? NguoiTra { get; set; }

        [StringLength(50)]
        public string HoNV { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [StringLength(50)]
        public string HoNT { get; set; }

        [StringLength(50)]
        public string TenNT { get; set; }
    }
}
