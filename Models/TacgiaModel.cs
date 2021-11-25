using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class TacgiaModel
    {
        private QuanlythuvienDbContext context = null;
        public TacgiaModel()
        {
            context = new QuanlythuvienDbContext();
        }
        public List<TACGIA> ListAll()
        {
            var list = context.Database.SqlQuery<TACGIA>("Select * from TACGIA").ToList();
            return list;
        }
    }
}
