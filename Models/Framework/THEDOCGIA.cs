namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("THEDOCGIA")]
    public partial class THEDOCGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THEDOCGIA()
        {
            PHIEUMUONSACHes = new HashSet<PHIEUMUONSACH>();
            PHIEUTRASACHes = new HashSet<PHIEUTRASACH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Mã thẻ độc giả")]
        [Required(ErrorMessage ="Ban chua nhap ma the doc gia")]
        public int MaTheDocGia { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên độc giả")]

        public string HoTenDocGia { get; set; }
        [Display(Name = "Ngày sinh")]

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]

        public string DiaChi { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Ngày lập thẻ")]


        public DateTime? NgayLapThe { get; set; }

        public int MaLoaiDocGia { get; set; }

        [Display(Name = "Ngày hết hạn thẻ")]

        public DateTime? NgayHetHanThe { get; set; }

        [StringLength(10)]
        [Display(Name = "Số lượng sách mượn quá hạn")]

        public string SLSachMuonQuaHan { get; set; }

        [StringLength(10)]
        [Display(Name = "Số luọng sách đang mượn")]

        public string SLSachDangMuon_ { get; set; }

        public virtual LOAIDOCGIA LOAIDOCGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUONSACH> PHIEUMUONSACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRASACH> PHIEUTRASACHes { get; set; }
        [NotMapped]
        public List<THEDOCGIA> DocGiaCollection { get; set; }
    }
}
