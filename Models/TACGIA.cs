namespace ShopSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TACGIA")]
    public partial class TACGIA
    {
        [Key]
        public int MaTG { get; set; }

        [StringLength(50)]
        public string TenTG { get; set; }

        [Required]
        [StringLength(50)]
        public string Diachi { get; set; }

        [Required]
        [StringLength(50)]
        public string Tieusu { get; set; }

        [Required]
        [StringLength(50)]
        public string Dienthoai { get; set; }

        public virtual VIETSACH VIETSACH { get; set; }
    }
}
