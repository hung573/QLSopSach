namespace ShopSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(100)]
        public string UserAdmin { get; set; }

        [Required]
        [StringLength(50)]
        public string PassAdmin { get; set; }

        [Required]
        [StringLength(50)]
        public string Hoten { get; set; }
    }
}
