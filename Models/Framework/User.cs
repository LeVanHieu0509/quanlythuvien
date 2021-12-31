namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User1")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }

        [StringLength(30)]
        [Display(Name = "Tài khoản")]

        public string TaiKhoan { get; set; }

        
        [StringLength(30)]
        [Display(Name = "Mật khẩu")]

        public string MatKhau { get; set; }
        

        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("MatKhau")]
        public string ConfirmPassword { get; set; }
    }
}
