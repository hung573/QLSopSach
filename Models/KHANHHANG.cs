namespace ShopSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHANHHANG")]
    public partial class KHANHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHANHHANG()
        {
            DONATHANGs = new HashSet<DONATHANG>();
        }

        [Key]
        public int MaKH { get; set; }

        [StringLength(150)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string DiachiKH { get; set; }

        [Required]
        [StringLength(50)]
        public string DienthoiKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONATHANG> DONATHANGs { get; set; }
    }
}
