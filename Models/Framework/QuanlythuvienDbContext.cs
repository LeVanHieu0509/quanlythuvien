namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanlythuvienDbContext : DbContext
    {
        public QuanlythuvienDbContext()
            : base("name=QuanlythuvienDbContext")
        {
        }

        public virtual DbSet<LOAIDOCGIA> LOAIDOCGIAs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<PHIEUMUONSACH> PHIEUMUONSACHes { get; set; }
        public virtual DbSet<PHIEUNHAPSACH> PHIEUNHAPSACHes { get; set; }
        public virtual DbSet<PHIEUTHUTIENPHAT> PHIEUTHUTIENPHATs { get; set; }
        public virtual DbSet<PHIEUTRASACH> PHIEUTRASACHes { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<THEDOCGIA> THEDOCGIAs { get; set; }
        public virtual DbSet<THELOAISACH> THELOAISACHes { get; set; }
        public virtual DbSet<THONGTINSACH> THONGTINSACHes { get; set; }
        public virtual DbSet<CT_PHIEUMUONTRA> CT_PHIEUMUONTRA { get; set; }
        public virtual DbSet<CT_PHIEUNHAPSACH> CT_PHIEUNHAPSACH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LOAIDOCGIA>()
                .HasMany(e => e.THEDOCGIAs)
                .WithRequired(e => e.LOAIDOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .HasMany(e => e.THONGTINSACHes)
                .WithRequired(e => e.nhaxuatban1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUMUONSACH>()
                .HasMany(e => e.CT_PHIEUMUONTRA)
                .WithRequired(e => e.PHIEUMUONSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAPSACH>()
                .HasMany(e => e.CT_PHIEUNHAPSACH)
                .WithRequired(e => e.PHIEUNHAPSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUTHUTIENPHAT>()
                .Property(e => e.SoTienThu)
                .HasPrecision(15, 0);

            modelBuilder.Entity<PHIEUTRASACH>()
                .Property(e => e.TongNo)
                .HasPrecision(15, 0);

            modelBuilder.Entity<PHIEUTRASACH>()
                .Property(e => e.TienPhatKyNay)
                .HasPrecision(15, 0);

            modelBuilder.Entity<PHIEUTRASACH>()
                .HasMany(e => e.PHIEUTHUTIENPHATs)
                .WithRequired(e => e.PHIEUTRASACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUTRASACH>()
                .HasMany(e => e.CT_PHIEUMUONTRA)
                .WithRequired(e => e.PHIEUTRASACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.THONGTINSACHes)
                .WithRequired(e => e.tacgia1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THEDOCGIA>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEDOCGIA>()
                .Property(e => e.SLSachMuonQuaHan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEDOCGIA>()
                .Property(e => e.SLSachDangMuon_)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THEDOCGIA>()
                .HasMany(e => e.PHIEUMUONSACHes)
                .WithRequired(e => e.THEDOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THEDOCGIA>()
                .HasMany(e => e.PHIEUTRASACHes)
                .WithRequired(e => e.THEDOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAISACH>()
                .HasMany(e => e.THONGTINSACHes)
                .WithRequired(e => e.loaisach1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THONGTINSACH>()
                .Property(e => e.TriGia)
                .HasPrecision(15, 0);

            modelBuilder.Entity<THONGTINSACH>()
                .Property(e => e.TinhTrang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THONGTINSACH>()
                .HasMany(e => e.CT_PHIEUMUONTRA)
                .WithRequired(e => e.THONGTINSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THONGTINSACH>()
                .HasMany(e => e.CT_PHIEUNHAPSACH)
                .WithRequired(e => e.THONGTINSACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_PHIEUMUONTRA>()
                .Property(e => e.SoNgayMuon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CT_PHIEUMUONTRA>()
                .Property(e => e.TienPhat)
                .HasPrecision(15, 0);

            modelBuilder.Entity<CT_PHIEUNHAPSACH>()
                .Property(e => e.SoLuongNhap)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
