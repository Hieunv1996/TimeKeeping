namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        public int ID { get; set; }

        public decimal HeSoLuong { get; set; }

        public decimal? LuongCoBan { get; set; }
    }
}
