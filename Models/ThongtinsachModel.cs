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
            //var list = context.Database.SqlQuery<THONGTINSACH>("Sp_thongtinsach_ListThongtinsach").ToList();
            //var list = context.Database.SqlQuery<THONGTINSACH>("select * from THONGTINSACH, NHAXUATBAN where THONGTINSACH.MaNXB = NHAXUATBAN.MaNXB").ToList();
            //return list;
            
            var countTotal = context.Database.ExecuteSqlCommand("SELECT count(*)  FROM THONGTINSACH");
            return countTotal;
        }
    }
}
