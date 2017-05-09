namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuCap")]
    public partial class PhuCap
    {
        public long ID { get; set; }

        public long? IDNhanVien { get; set; }

        [StringLength(200)]
        public string MoTaPhuCap { get; set; }

        public decimal? SoTien { get; set; }

        public DateTime? TuNgay { get; set; }

        public DateTime? DenNgay { get; set; }

        public bool? TinhTrang { get; set; }
    }
}
