namespace ShopSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAXUATBAN")]
    public partial class NHAXUATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAXUATBAN()
        {
            SACH1 = new HashSet<SACH1>();
        }

        [Key]
        public int MaNXB { get; set; }

        [StringLength(100)]
        public string TenNXB { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(50)]
        public string Dienthoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH1> SACH1 { get; set; }
    }
}
