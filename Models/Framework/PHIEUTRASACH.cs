namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTRASACH")]
    public partial class PHIEUTRASACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTRASACH()
        {
            PHIEUTHUTIENPHATs = new HashSet<PHIEUTHUTIENPHAT>();
            CT_PHIEUMUONTRA = new HashSet<CT_PHIEUMUONTRA>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Tên phiếu trả")]
        public int MaPhieuTra { get; set; }

        public int MaTheDocGia { get; set; }
        [Display(Name = "Tổng nợ")]

        public decimal? TongNo { get; set; }

        [Display(Name = "Tiền phạt kỳ này")]

        public decimal? TienPhatKyNay { get; set; }
        [Display(Name = "Ngày trả")]

        public DateTime? NgayTra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUTIENPHAT> PHIEUTHUTIENPHATs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUMUONTRA> CT_PHIEUMUONTRA { get; set; }

        public virtual THEDOCGIA THEDOCGIA { get; set; }
        [NotMapped]
        public List<PHIEUTRASACH> PhieuTraCollection { get; set; }
    }
}
