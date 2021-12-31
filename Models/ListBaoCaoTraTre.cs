using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ListBaoCaoTraTre
    {
        public string tensach { get; set; }
        public DateTime? ngaymuon { get; set; }

        public int songaytratre { get; set; }

        public ListBaoCaoTraTre(string tensach, DateTime ngaymuon, int songaytratre)
        {
            this.tensach = tensach;
            this.ngaymuon = ngaymuon;
            this.songaytratre = songaytratre;
        }
    }
}
