using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class NhaxuatbanModel
    {
        private QuanlythuvienDbContext context = null;
        public NhaxuatbanModel()
        {
            context = new QuanlythuvienDbContext();
        }
        public List<NHAXUATBAN> ListAll()
        {
            var list = context.Database.SqlQuery<NHAXUATBAN>("select * from NHAXUATBAN").ToList();
            return list;
        }
    }
}
