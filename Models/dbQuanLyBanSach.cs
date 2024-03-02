using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopSach.Models
{
    public partial class dbQuanLyBanSach : DbContext
    {
        public dbQuanLyBanSach()
            : base("name=dbQuanLyBanSach2")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CHUDE> CHUDEs { get; set; }
        public virtual DbSet<DONATHANG> DONATHANGs { get; set; }
        public virtual DbSet<KHANHHANG> KHANHHANGs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<SACH1> SACH1 { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<VIETSACH> VIETSACHes { get; set; }
        public virtual DbSet<CTDATHANG> CTDATHANGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.PassAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Hoten)
                .IsUnicode(false);

            modelBuilder.Entity<DONATHANG>()
                .HasMany(e => e.CTDATHANGs)
                .WithRequired(e => e.DONATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHANHHANG>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KHANHHANG>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHANHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHANHHANG>()
                .Property(e => e.DienthoiKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHANHHANG>()
                .HasMany(e => e.DONATHANGs)
                .WithRequired(e => e.KHANHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<SACH1>()
                .HasMany(e => e.CTDATHANGs)
                .WithRequired(e => e.SACH1)
                .HasForeignKey(e => e.Massach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasOptional(e => e.VIETSACH)
                .WithRequired(e => e.TACGIA);

            modelBuilder.Entity<CTDATHANG>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);
        }
    }
}
