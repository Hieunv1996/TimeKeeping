namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraLuong")]
    public partial class TraLuong
    {
        public long ID { get; set; }

        public long? IDNhanVien { get; set; }

        public DateTime? DauThoiGian { get; set; }

        public int? LuongCuaThang { get; set; }

        public int? TongSoCong { get; set; }

        public decimal? ThuongPhat { get; set; }

        public decimal? PhuCap { get; set; }

        public decimal? ThanhTien { get; set; }

        public decimal? DaTra { get; set; }

        public decimal? ConNo { get; set; }

        public long? NguoiTra { get; set; }
    }
}
