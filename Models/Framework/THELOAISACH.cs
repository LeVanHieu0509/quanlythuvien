namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THELOAISACH")]
    public partial class THELOAISACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THELOAISACH()
        {
            THONGTINSACHes = new HashSet<THONGTINSACH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã loại sách")]

        public int MaTheLoaiSach { get; set; }

        [StringLength(30)]
        [Display(Name = "Loại sách")]
        public string TenTheLoaiSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGTINSACH> THONGTINSACHes { get; set; }

        [NotMapped]
        public List<THELOAISACH> LoaiSachCollection { get; set; }
    }
}
