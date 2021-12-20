using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CtPhieuMuonTraModel
    {
        private QuanlythuvienDbContext context = null;
        public CtPhieuMuonTraModel()
        {
            context = new QuanlythuvienDbContext();
        }
        public List<CT_PHIEUMUONTRA> FindMaPhieuTra(int? id)
        {
            var list = context.Database.SqlQuery<CT_PHIEUMUONTRA>("Select * from CT_PHIEUMUONTRA where MaPhieuTra ="+id).ToList();
            return list;
        }

        public void RemoveMaPhieuTra(int? id)
        {
            context.Database.ExecuteSqlCommand("Delete from CT_PHIEUMUONTRA where MaPhieuTra =" + id);   
        }
        public void RemoveMaPhieuMuon(int? id)
        {
            var list = context.Database.SqlQuery<CT_PHIEUMUONTRA>("Select * from PHIEUMUONTRA where MaPhieuTra =" + id).ToList();
            
            context.Database.ExecuteSqlCommand("Delete from PHIEUMUONSACH where MaPhieuMuon =" + id);
        }
    }
}
