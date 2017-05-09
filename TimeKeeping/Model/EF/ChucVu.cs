namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public partial class ChucVu
    {
        [Display(Name = "ID Chức vụ")]
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên chức vụ")]
        [Required(ErrorMessage = "Vui lòng nhập tên chức vụ")]
        public string TenChucVu { get; set; }
    }
}
