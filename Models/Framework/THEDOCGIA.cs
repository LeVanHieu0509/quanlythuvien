namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTheDocGia { get; set; }

        [StringLength(50)]
        public string HoTenDocGia { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? NgayLapThe { get; set; }

        public int MaLoaiDocGia { get; set; }

        public DateTime? NgayHetHanThe { get; set; }

        [StringLength(10)]
        public string SLSachMuonQuaHan { get; set; }

        [StringLength(10)]
        public string SLSachDangMuon_ { get; set; }

        public virtual LOAIDOCGIA LOAIDOCGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUONSACH> PHIEUMUONSACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRASACH> PHIEUTRASACHes { get; set; }
    }
}
