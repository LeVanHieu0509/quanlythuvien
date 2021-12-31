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
        int a;
        public int FindMaPhieuMuon(int? id)
        {
           
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<PHIEUMUONSACH>("Select * from PHIEUMUONSACH where MaTheDocGia =" + id).ToList();
            foreach (var item in countTotal)
            {
                a = item.MaPhieuMuon;
            }
            return a;
        }
        int b;
        public int FindMaPhieuTra(int? id)
        {

            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<PHIEUTRASACH>("Select * from PHIEUTRASACH where MaTheDocGia =" + id).ToList();
            foreach (var item in countTotal)
            {
                b = item.MaPhieuTra;
            }
            return b;
        }

        string check = "";
        public string ischeck(int? id)
        {
            
            var countTotal = context.Database.SqlQuery<THONGTINSACH>("Select * from THONGTINSACH where MaSach =" + id).ToList();
            foreach (var item in countTotal)
            {
                check =  item.TinhTrang;
            }
            return check;
        }
        int checkthedocgia;
        DateTime? ngayhethanthe;
        public DateTime? ischeckTheDocGia(int? id)
        {

            var countTotal = context.Database.SqlQuery<PHIEUMUONSACH>("Select * from PHIEUMUONSACH where MaPhieuMuon =" + id).ToList();
            foreach (var item in countTotal)
            {
                checkthedocgia = item.MaTheDocGia;
            }
            var countTotal1 = context.Database.SqlQuery<THEDOCGIA>("Select * from THEDOCGIA where MaTheDocGia =" + checkthedocgia).ToList();

            foreach (var item in countTotal1)
            {
                ngayhethanthe = item.NgayHetHanThe;
            }
            return ngayhethanthe;
        } 
        
    }
}
