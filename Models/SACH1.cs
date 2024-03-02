namespace ShopSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SACH1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH1()
        {
            CTDATHANGs = new HashSet<CTDATHANG>();
            VIETSACHes = new HashSet<VIETSACH>();
        }

        [Key]
        public int Masach { get; set; }

        [Required]
        [StringLength(100)]
        public string Tensach { get; set; }

        public double Giaban { get; set; }

        [Required]
        [StringLength(50)]
        public string Mota { get; set; }

        [Required]
        [StringLength(50)]
        public string Anhbia { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngaycapnhat { get; set; }

        public int? Soluongton { get; set; }

        public int? MaCD { get; set; }

        public int? MaNXB { get; set; }

        public virtual CHUDE CHUDE { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIETSACH> VIETSACHes { get; set; }
    }
}
