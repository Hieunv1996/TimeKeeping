namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewChamCong")]
    public partial class ViewChamCong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public long? IDNhanVien { get; set; }

        public DateTime? DauThoiGian { get; set; }

        public int? IDCaLamViec { get; set; }

        public bool? XinNghiPhep { get; set; }

        public int? IDTinhTrang { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }

        public DateTime? Ngay { get; set; }

        public bool? PheDuyet { get; set; }

        public long? NguoiDuyet { get; set; }

        [StringLength(50)]
        public string TenCaLamViec { get; set; }

        [StringLength(10)]
        public string KiHieu { get; set; }

        [StringLength(50)]
        public string HoNV { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [StringLength(50)]
        public string HoND { get; set; }

        [StringLength(50)]
        public string TenND { get; set; }
    }
}
