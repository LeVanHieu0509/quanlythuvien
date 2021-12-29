using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Framework;

namespace quanlythuvien.Controllers
{
    public class BaoCaoController : BaseController
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: BaoCao
        public ActionResult BaoCaoTheoTheLoai()
        {
            
            List<THONGTINSACH> thongtinsach = db.THONGTINSACHes.ToList();
            List<CT_PHIEUMUONTRA> ctPhieuMuonTra = db.CT_PHIEUMUONTRA.ToList();
            ArrayList arr = new ArrayList();
           
            var query = thongtinsach.AsEnumerable().Where(r=> r.TinhTrang == "DangMuon  ")
                    .GroupBy(r => new { matheloaisach = r.MaTheLoaiSach })
                    .Select(grp => new
                    {
                        MaTheLoaiSach = grp.Key.matheloaisach, 
                        Count = grp.Count()
                    });

            foreach (var item in query)
            {
                arr.Add(new ListBaoCao(item.MaTheLoaiSach.ToString(), item.Count.ToString()));
            }
            ViewBag.baocao = arr;
            return View();

        }

        public List<THONGTINSACH> ListBaoCao(){
            THONGTINSACH tHONGTINSACH = new THONGTINSACH();
            var iplGetBooks = new ThongtinsachModel();
            var getBooks = iplGetBooks.ListSachTest();
            //string sql = "select MaTheLoaiSach, count(*) as SoLuotMuon from THONGTINSACH where TinhTrang = 'ChuaMuon' group by MaTheLoaiSach having count(*) > 0";
            return getBooks;
        }

        //public ActionResult ChoosesSoLuongMuon()
        //{
        //    var masach;
        //    THONGTINSACH tHONGTINSACH = new THONGTINSACH();
        //    var iplGetBooks = new ThongtinsachModel();
        //     var getBooks = iplGetBooks.ListSach();
        //    foreach (var item in getBooks)
        //    {
        //        masach = GetCountChitietMuonsach(item.MaSach);
        //        var theloai = item.MaTheLoaiSach;
        //        //tHONGTINSACH.BaoCaoCollection.AddRange(masach,theloai);  
        //    }
        //    return PartialView(masach);
        //}

    }

   
}