namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewPhuCap")]
    public partial class ViewPhuCap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public int? IDChucVu { get; set; }

        [StringLength(200)]
        public string MoTaPhuCap { get; set; }

        public decimal? SoTien { get; set; }

        public bool? TinhTrang { get; set; }

        public string TenChucVu { get; set; }

    }
}
