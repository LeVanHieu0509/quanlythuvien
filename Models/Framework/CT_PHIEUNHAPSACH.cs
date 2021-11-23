namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUNHAPSACH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuNhapSach { get; set; }

        [StringLength(10)]
        public string SoLuongNhap { get; set; }

        public virtual PHIEUNHAPSACH PHIEUNHAPSACH { get; set; }

        public virtual THONGTINSACH THONGTINSACH { get; set; }
    }
}
