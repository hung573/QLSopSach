namespace ShopSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VIETSACH")]
    public partial class VIETSACH
    {
        [Key]
        public int MaTG { get; set; }

        public int? Masach { get; set; }

        [StringLength(50)]
        public string Vaitro { get; set; }

        [StringLength(50)]
        public string Vitri { get; set; }

        public virtual SACH1 SACH1 { get; set; }

        public virtual TACGIA TACGIA { get; set; }
    }
}
