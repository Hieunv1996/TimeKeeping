namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaLamViec")]
    public partial class CaLamViec
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenCaLamViec { get; set; }

        public TimeSpan? TGBatDau { get; set; }

        public TimeSpan? TGKetThuc { get; set; }
    }
}
