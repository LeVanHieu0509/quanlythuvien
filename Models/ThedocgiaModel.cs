using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class ThedocgiaModel
    {
        private QuanlythuvienDbContext context = null;
        public ThedocgiaModel()
        {
            context = new QuanlythuvienDbContext();
        }
        public List<THEDOCGIA> ListAll()
        {
            var list = context.Database.SqlQuery<THEDOCGIA>("Sp_thedocgia_ListAll").ToList();
            return list;
        }
    }
}
