namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIDOCGIA")]
    public partial class LOAIDOCGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIDOCGIA()
        {
            THEDOCGIAs = new HashSet<THEDOCGIA>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLoaiDocGia { get; set; }

        [StringLength(30)]
        [Display(Name = "Loại độc giả")]

        public string TenLoaiDocGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEDOCGIA> THEDOCGIAs { get; set; }

        [NotMapped]
        public List<LOAIDOCGIA> LoaiDGCollection { get; set; }
    }
}
