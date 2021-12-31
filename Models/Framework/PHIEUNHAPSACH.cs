namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAPSACH")]
    public partial class PHIEUNHAPSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAPSACH()
        {
            CT_PHIEUNHAPSACH = new HashSet<CT_PHIEUNHAPSACH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuNhapSach { get; set; }
        [Display(Name = "Ngày nhập sách")]

        public DateTime? NgayNhapSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAPSACH> CT_PHIEUNHAPSACH { get; set; }
    }
}
