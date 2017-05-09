namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewThuongPhat")]
    public partial class ViewThuongPhat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public long? IDNhanVien { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public decimal? SoTien { get; set; }

        public DateTime? DauThoiGian { get; set; }

        [StringLength(50)]
        public string Ho { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }
    }
}
