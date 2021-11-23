namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THONGTINSACH")]
    public partial class THONGTINSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THONGTINSACH()
        {
            CT_PHIEUMUONTRA = new HashSet<CT_PHIEUMUONTRA>();
            CT_PHIEUNHAPSACH = new HashSet<CT_PHIEUNHAPSACH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [StringLength(30)]
        public string TenSach { get; set; }

        [StringLength(30)]
        public string TacGia { get; set; }

        public DateTime? NamXuatBan { get; set; }

        public DateTime? NgayNhap { get; set; }

        public decimal? TriGia { get; set; }

        public int MaNXB { get; set; }

        public int MaTheLoaiSach { get; set; }

        public int MaTacGia { get; set; }

        public int? SoLuongTonKho { get; set; }

        [StringLength(10)]
        public string TinhTrang { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        public virtual TACGIA TACGIA1 { get; set; }

        public virtual THELOAISACH THELOAISACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUMUONTRA> CT_PHIEUMUONTRA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPSACH> CT_PHIEUNHAPSACH { get; set; }
    }
}
