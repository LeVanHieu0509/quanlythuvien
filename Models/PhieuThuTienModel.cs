using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PhieuThuTienModel
    {
        private QuanlythuvienDbContext context = null;
        public PhieuThuTienModel()
        {
            context = new QuanlythuvienDbContext();
        }
        public void UpdateTongNo(decimal? tienthu,int maphieutra)
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
           context.Database.ExecuteSqlCommand("UPDATE PHIEUTRASACH SET TongNo = TienPhatKyNay -" + tienthu + "Where MaPhieuTra =" + maphieutra);
        }

        Decimal? TotalTongNo;
        public Decimal? TotalNo(int? maphieutra)
        {
            var listCTPhieuMuonTra = context.Database.SqlQuery<PHIEUTRASACH>("Select * from PHIEUTRASACH where MaPhieuTra =" + maphieutra).ToList();
            foreach (var item in listCTPhieuMuonTra)
            {
                TotalTongNo = item.TongNo;
            }
            return TotalTongNo;
        }
    }
}
