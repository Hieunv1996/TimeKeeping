namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinhTrang")]
    public partial class TinhTrang
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string KiHieu { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }
    }
}
