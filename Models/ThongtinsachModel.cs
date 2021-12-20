using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

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

        public void updateTinhTrangCon()
        {
           context.Database.ExecuteSqlCommand("Update THONGTINSACH set TinhTrang = 'Con' where SoLuongTonKho > 0");
        }
        public void updateTinhTrangHet()
        {
            context.Database.ExecuteSqlCommand("Update THONGTINSACH set TinhTrang = 'Het' where SoLuongTonKho = 0");
        }
    }
}

