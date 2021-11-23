namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTHUTIENPHAT")]
    public partial class PHIEUTHUTIENPHAT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaPhieuPhat { get; set; }

        public decimal? SoTienThu { get; set; }

        public int MaPhieuTra { get; set; }

        public virtual PHIEUTRASACH PHIEUTRASACH { get; set; }
    }
}
