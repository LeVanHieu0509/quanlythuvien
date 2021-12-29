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


        public int CountTotalDangMuon(int? id)
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<CT_PHIEUMUONTRA>("SELECT * FROM CT_PHIEUMUONTRA WHERE MaPhieuMuon =" + id).Count();
            return countTotal;

        }

        public int CountTotalMuonQuaHan(int? id)
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<CT_PHIEUMUONTRA>("SELECT * FROM CT_PHIEUMUONTRA WHERE TienPhat > 0 and MaPhieuTra = " + id).Count();
            return countTotal;

        }

        public int CountChiTietMuonTra()
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<CT_PHIEUMUONTRA>("SELECT * FROM CT_PHIEUMUONTRA").Count();
            return countTotal;

        }



        //
        DateTime? ngaytra;
        public DateTime? FindNgayTra(int? mathedocgia)
        {

            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var listPhieuTraSach = context.Database.SqlQuery<PHIEUTRASACH>("Select * from PHIEUTRASACH where MaTheDocGia =" + mathedocgia).ToList();
            foreach (var item in listPhieuTraSach)
            {
                ngaytra = item.NgayTra;
            }
            return ngaytra;
        }

        //
        DateTime? hantra;
        public DateTime? FindHanTra(int? maPhieutra)
        {

            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var listCTPhieuMuonTra = context.Database.SqlQuery<CT_PHIEUMUONTRA>("Select * from CT_PHIEUMUONTRA where MaPhieuTra =" + maPhieutra).ToList();
            foreach (var item in listCTPhieuMuonTra)
            {
                hantra = item.HanTra;
            }
            return hantra;
        }

        public void UpdateTienPhat(decimal? tienphat, int maphieutra)
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            context.Database.ExecuteSqlCommand("UPDATE CT_PHIEUMUONTRA SET  TienPhat =" + tienphat + "Where MaPhieuTra =" + maphieutra);
            

            
        }

        Decimal? TotalTienPhat = 0;
        public Decimal? TienPhatKyNay(int? maphieutra)
        {
            var listCTPhieuMuonTra = context.Database.SqlQuery<CT_PHIEUMUONTRA>("Select * from CT_PHIEUMUONTRA where MaPhieuTra =" + maphieutra).ToList();
            foreach (var item in listCTPhieuMuonTra)
            {
                TotalTienPhat = TotalTienPhat +  item.TienPhat;
            }
            return TotalTienPhat;
        }

        public void UpdateTienPhatKyNay(int? maphieutra)
        {
            Decimal? tienphatkynay1 = TienPhatKyNay(maphieutra);
            context.Database.ExecuteSqlCommand("UPDATE PHIEUTRASACH SET TienPhatKyNay =" + tienphatkynay1 + "Where MaPhieuTra =" + maphieutra);
            context.Database.ExecuteSqlCommand("UPDATE PHIEUTRASACH SET  TongNo =" + tienphatkynay1 + "Where MaPhieuTra =" + maphieutra);
        }
        //public void UpdateTongNo(int? maphieutra)
        //{
        //    Decimal? tienphatkynay1 = TienPhatKyNay(maphieutra);
        //    //context.Database.ExecuteSqlCommand("UPDATE PHIEUTRASACH SET TienPhatKyNay =" + tienphatkynay1 + "Where MaPhieuTra =" + maphieutra);
        //    context.Database.ExecuteSqlCommand("UPDATE PHIEUTRASACH SET  TongNo =" + tienphatkynay1 + "Where MaPhieuTra =" + maphieutra);
        //}


       
    }
} 
