namespace ShopSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONATHANG")]
    public partial class DONATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONATHANG()
        {
            CTDATHANGs = new HashSet<CTDATHANG>();
        }

        [Key]
        public int SoDH { get; set; }

        public int MaKH { get; set; }

        public DateTime NgayDH { get; set; }

        public DateTime Ngaygiao { get; set; }

        public bool? Dathanhtoan { get; set; }

        public bool? Tinhtranggiaohang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }

        public virtual KHANHHANG KHANHHANG { get; set; }
    }
}
