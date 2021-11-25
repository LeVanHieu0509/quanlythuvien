using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class TheloaisachModel
    {
        private QuanlythuvienDbContext context = null;
        public TheloaisachModel()
        {
            context = new QuanlythuvienDbContext();
        }
        public List<THELOAISACH> ListAll()
        {
            var list = context.Database.SqlQuery<THELOAISACH>("select * from THELOAISACH").ToList();
            return list;
        }
    }
}
