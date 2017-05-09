namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
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
    }
}
