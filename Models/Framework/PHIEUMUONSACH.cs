namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUONSACH")]
    public partial class PHIEUMUONSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUONSACH()
        {
            CT_PHIEUMUONTRA = new HashSet<CT_PHIEUMUONTRA>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Display(Name = "Tên Phiếu Mượn")]
        public int MaPhieuMuon { get; set; }

        [Display(Name = "Ten Doc Gia")]
        public int MaTheDocGia { get; set; }
        [Display(Name = "Ngày mượn")]

        public DateTime? NgayMuon { get; set; }

        [StringLength(20)]
        [Display(Name = "Tình trạng sách")]
        public string TinhTrangMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUMUONTRA> CT_PHIEUMUONTRA { get; set; }

        public virtual THEDOCGIA THEDOCGIA { get; set; }
        [NotMapped]
        public List<PHIEUMUONSACH> PhieuMuonCollection { get; set; }
    }
}
