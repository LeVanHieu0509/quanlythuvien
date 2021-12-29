using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using Models.ViewModel;

namespace Models
{
    public class ThongtinsachModel
    {
        private QuanlythuvienDbContext context = null;
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
       
      
        public ThongtinsachModel()
        {   
            context = new QuanlythuvienDbContext();
        }
        public List<THONGTINSACH> ListAll()
        {
            //var list = context.Database.SqlQuery<THONGTINSACH>("Sp_thongtinsach_ListThongtinsach").ToList();
            var list = context.Database.SqlQuery<THONGTINSACH>("select * from THONGTINSACH, NHAXUATBAN where THONGTINSACH.MaNXB = NHAXUATBAN.MaNXB").ToList();
            return list;
        }

        public IEnumerable<THONGTINSACH> SearchSach(string searchString)
        {
            IQueryable<THONGTINSACH> model = context.THONGTINSACHes;

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenSach.Contains(searchString) || x.tacgia1.TenTacGia.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaSach);
        }

        public int CountTotalSach()
        {
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<THONGTINSACH>("SELECT * FROM THONGTINSACH").Count();
            return countTotal;
        }

        int a;
        public int SoLuongSachTonKho()
        {

            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<THONGTINSACH>("Select * from THONGTINSACH").ToList();
            foreach (var item in countTotal)
            {
                a = item.SoLuongTonKho;
            }
            return a;
        }

        public void updateTinhTrangCon(int masach)
        {
           context.Database.ExecuteSqlCommand("Update THONGTINSACH set TinhTrang = 'ChuaMuon' where MaSach="+masach);
        }
        public void updateTinhTrangHet(int masach)
        {
            context.Database.ExecuteSqlCommand("Update THONGTINSACH set TinhTrang = 'DangMuon' where  MaSach=" + masach);
        }

        public List<THONGTINSACH> ListSach()
        {
          
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<THONGTINSACH>("SELECT * FROM THONGTINSACH ").ToList();
            return countTotal;
        }

        public List<THELOAISACH> ListTheLoaiSach()
        {

            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<THELOAISACH>("SELECT * FROM THELOAISACH").ToList();
            return countTotal;
        }

        //public List<THONGTINSACH> ListSachTest1()
        //{
        //    THONGTINSACH tHONGTINSACH = new THONGTINSACH();
        //    var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
        //    var countTotal = context.Database.SqlQuery<THONGTINSACH>
        //        ("select MaTheLoaiSach, count(*) as SoLuotMuon from THONGTINSACH where TinhTrang = 'ChuaMuon' group by MaTheLoaiSach having count(*) > 0").ToList();
        //    return countTotal;
        //}

        public List<THONGTINSACH> ListSachTest()
        {
            THONGTINSACH tHONGTINSACH = new THONGTINSACH();
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<THONGTINSACH>
                ("select * from THONGTINSACH where TinhTrang = 'DangMuon' ").ToList();
           
            return countTotal;
        }




       


        //

        int masach;
        public int FindMaSach(int? maphieutra)
        {

            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<CT_PHIEUMUONTRA>("Select * from CT_PHIEUMUONTRA where MaPhieuTra =" + maphieutra).ToList();
            foreach (var item in countTotal)
            {
                masach = item.MaSach;
            }
            //tra ve ma doc gia
            return masach;
        }




    }
}

