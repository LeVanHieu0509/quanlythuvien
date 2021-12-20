using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class PhieuMuonModel
    {
        private QuanlythuvienDbContext context = null;
        public PhieuMuonModel()
        {
            context = new QuanlythuvienDbContext();
        }

        public int FindMaPhieuMuon(int? id)
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<PHIEUMUONSACH>("Select MaPhieuMuon from PHIEUMUONSACH where MaTheDocGia =" + id);
            return countTotal.Where(;

        }
    }
}
