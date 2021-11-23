namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUMUONTRA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuMuon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuTra { get; set; }

        [StringLength(10)]
        public string SoNgayMuon { get; set; }

        public decimal? TienPhat { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        public DateTime? HanTra { get; set; }

        public virtual PHIEUMUONSACH PHIEUMUONSACH { get; set; }

        public virtual PHIEUTRASACH PHIEUTRASACH { get; set; }

        public virtual THONGTINSACH THONGTINSACH { get; set; }
    }
}
