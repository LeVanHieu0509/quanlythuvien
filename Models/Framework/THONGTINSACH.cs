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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã sách")]

        public int MaSach { get; set; }

   
        [StringLength(30)]
        [Display(Name = "Tên sách")]

        public string TenSach { get; set; }

        [StringLength(30)]
        [Display(Name = "Tác giả")]

        public string TacGia { get; set; }
        [Display(Name = "Năm xuất bản")]

        public DateTime? NamXuatBan { get; set; }
        [Display(Name = "Ngày nhập")]

        public DateTime? NgayNhap { get; set; }
        [Display(Name = "Trị giá")]

        public decimal? TriGia { get; set; }

        public int MaNXB { get; set; }

        [Display(Name = "TheLoai")]
        public int MaTheLoaiSach { get; set; }

        public int MaTacGia { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuongTonKho { get; set; }

        [StringLength(10)]
        [Display(Name = "Tình trạng")]

        public string TinhTrang { get; set; }

        public virtual NHAXUATBAN nhaxuatban1 { get; set; }

        public virtual TACGIA tacgia1 { get; set; }

        public virtual THELOAISACH loaisach1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUMUONTRA> CT_PHIEUMUONTRA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPSACH> CT_PHIEUNHAPSACH { get; set; }

        [NotMapped]
        public List<THONGTINSACH> SachCollection { get; set; }

        [NotMapped]
        public int CountSLMuon { get; set; }

    }
}
