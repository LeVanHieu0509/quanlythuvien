using System;
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

            
            return View(ListBaoCao());

        }

        public List<THONGTINSACH> ListBaoCao(){
            THONGTINSACH tHONGTINSACH = new THONGTINSACH();
            var iplGetBooks = new ThongtinsachModel();
            var getBooks = iplGetBooks.ListSach();
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