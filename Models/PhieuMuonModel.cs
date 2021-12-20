﻿using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class PhieuMuonModel 
    {
        private QuanlythuvienDbContext context = null;
        public PhieuMuonModel()
        {
            context = new QuanlythuvienDbContext();
        }
        int a;
        public int FindMaPhieuMuon(int? id)
        {
           
            //var count = context.Database.SqlQuery(" SELECT * FROM dbo.THONGTINSACH").Count()
            var countTotal = context.Database.SqlQuery<PHIEUMUONSACH>("Select * from PHIEUMUONSACH where MaTheDocGia =" + id).ToList();
            foreach (var item in countTotal)
            {
                a = item.MaPhieuMuon;
            }
            return a;
        }

        string check = "";
        public string ischeck(int? id)
        {
            
            var countTotal = context.Database.SqlQuery<THONGTINSACH>("Select * from THONGTINSACH where MaSach =" + id).ToList();
            foreach (var item in countTotal)
            {
                check =  item.TinhTrang;
            }
            return check;
        }
    }
}
