using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ListBaoCao
    {
        public string matheloaisach { get; set; }
        public string countSLSach { get; set; }
        public ListBaoCao(string matheloaisach, string countSLSach)
        {
            this.matheloaisach = matheloaisach;
            this.countSLSach = countSLSach;
        }
    }
}
