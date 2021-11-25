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
    }
}
