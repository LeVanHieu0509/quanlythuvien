using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Data.Entity;
using System.Net;
using Models.Framework;

namespace quanlythuvien.Controllers
{
    public class BaoCaoController : BaseController
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: BaoCao
        public ActionResult BaoCaoTheoTheLoai()
        {

            try
            {
                List<THONGTINSACH> thongtinsach = db.THONGTINSACHes.ToList();
                var iplChitietMuonTra = new CtPhieuMuonTraModel();
                int countchitietmuontra = iplChitietMuonTra.CountChiTietMuonTra();

                ArrayList arr = new ArrayList();

                var query = thongtinsach.AsEnumerable().Where(r => r.TinhTrang == "DangMuon  ")
                        .GroupBy(r => new { matheloaisach = r.MaTheLoaiSach, tensach = r.loaisach1.TenTheLoaiSach })
                        .Select(grp => new
                        {
                            tensach = grp.Key.tensach,
                            MaTheLoaiSach = grp.Key.matheloaisach,
                            Count = grp.Count()
                        });

                foreach (var item in query)
                {
                    arr.Add(new ListBaoCao(item.MaTheLoaiSach, item.Count, Convert.ToDouble((item.Count * 100) / countchitietmuontra), item.tensach));

                }
                ViewBag.baocao = arr;
                return View();
            }
            catch
            {
               
                
                return View();
            }
          

        }

        public List<THONGTINSACH> ListBaoCao(){
            THONGTINSACH tHONGTINSACH = new THONGTINSACH();
            var iplGetBooks = new ThongtinsachModel();
            var getBooks = iplGetBooks.ListSachTest();
            //string sql = "select MaTheLoaiSach, count(*) as SoLuotMuon from THONGTINSACH where TinhTrang = 'ChuaMuon' group by MaTheLoaiSach having count(*) > 0";
            return getBooks;
        }
        public ActionResult BaoCaoSachTraTre()
        {
            try
            {
                var ct_muon = db.CT_PHIEUMUONTRA.Include(s => s.THONGTINSACH).Include(s => s.PHIEUMUONSACH).ToList();
                ArrayList arr = new ArrayList();
                foreach (var item in ct_muon)
                {

                    arr.Add(new ListBaoCaoTraTre(item.THONGTINSACH.TenSach, Convert.ToDateTime(item.PHIEUMUONSACH.NgayMuon), Convert.ToInt32(item.TienPhat / 1000)));

                }
                ViewBag.baocaotratre = arr;
                return View();
            }
            catch
            {
                return View();
            }
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