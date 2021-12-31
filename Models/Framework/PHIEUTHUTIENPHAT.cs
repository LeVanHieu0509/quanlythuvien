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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã phiếu phạt")]

        public int MaPhieuPhat { get; set; }
        [Display(Name = "Số tiền thu")]

        public decimal? SoTienThu { get; set; }
        [Display(Name = "Mã phiếu trả")]

        public int MaPhieuTra { get; set; }

        public virtual PHIEUTRASACH PHIEUTRASACH { get; set; }
    }
}
