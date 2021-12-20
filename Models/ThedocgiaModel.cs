using Models.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Models
{
    public class ThedocgiaModel
    {
        private QuanlythuvienDbContext context = null;
        public ThedocgiaModel()
        {
            context = new QuanlythuvienDbContext();
        }
        public List<THEDOCGIA> ListAll()
        {
            var list = context.Database.SqlQuery<THEDOCGIA>("Sp_thedocgia_ListTheDocGia").ToList();
            return list;
        }
        public int TaoTheDocGia(string HoTenDocGia1, string DiaChi1, string Email1, int MaLoaiDocGia1)
        {
            object[] parameters =
            {
                new SqlParameter("@HoTenDocGia1",HoTenDocGia1),
                new SqlParameter("@Diachi1",DiaChi1),
                new SqlParameter("@Email1",Email1),
                new SqlParameter("@MaLoaiDocGia1",MaLoaiDocGia1)

            };
            int res = context.Database.ExecuteSqlCommand("Sp_TheDocGia_Insert @HoTenDocGia1, @Diachi1, @Email1, @MaLoaiDocGia1", parameters);
            return res;
        }


        public void UpdateSoLuongSachDangMuon(int? mathedocgia,int soluong)
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.ExecuteSqlCommand("UPDATE THEDOCGIA SET SLSachDangMuon_=" + soluong + "Where MaTheDocGia =" + mathedocgia);
            
        }
    }
}
