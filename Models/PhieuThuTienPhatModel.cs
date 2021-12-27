using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class PhieuThuTienPhatModel
    {
        private QuanlythuvienDbContext context = null;
        public PhieuThuTienPhatModel()
        {
            context = new QuanlythuvienDbContext();
        }
    }
}
