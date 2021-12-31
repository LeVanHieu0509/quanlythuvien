using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PhieuTraModel
    {
        private QuanlythuvienDbContext context = null;
        public PhieuTraModel()
        {
            context = new QuanlythuvienDbContext();
        }

        public List<CT_PHIEUMUONTRA> ListTraSach(int? maphieutra)
        {

            var listCTPhieuMuonTra = context.Database.SqlQuery<CT_PHIEUMUONTRA>("Select * from CT_PHIEUMUONTRA where MaPhieuTra =" + maphieutra).ToList();
           
            return listCTPhieuMuonTra;
        }
    }
}
