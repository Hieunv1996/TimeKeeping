namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenQuyen { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }
    }
}
