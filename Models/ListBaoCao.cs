﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ListBaoCao
    {
        public int matheloaisach { get; set; }
        public int countSLSach { get; set; }

       public double tile { get; set;  }

        public ListBaoCao(int matheloaisach, int countSLSach, double tile)
        {
            this.matheloaisach = matheloaisach;
            this.countSLSach = countSLSach;
            this.tile = tile;
        }
    }
}
