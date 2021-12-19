using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace quanlythuvien.Controllers
{
    public class PhieuMuonController : Controller
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: PhieuMuon
        public ActionResult Index()
        {
            var phieuMuons = db.PHIEUMUONSACHes.Include(s => s.THEDOCGIA);
            return View(phieuMuons.ToList());
        }

        public ActionResult ChoosesDocGia()
        {
            THEDOCGIA docgia = new THEDOCGIA();
            docgia.DocGiaCollection = db.THEDOCGIAs.ToList();
            return PartialView(docgia);
        }
        public ActionResult ChoosesSach()
        {
            THONGTINSACH saches = new THONGTINSACH();
            saches.SachCollection = db.THONGTINSACHes.ToList();
            return PartialView(saches);
        }
        public ActionResult ChoosesPhieuMuon()
        {
            PHIEUMUONSACH Phieumuon = new PHIEUMUONSACH();
            Phieumuon.PhieuMuonCollection = db.PHIEUMUONSACHes.ToList();
            return PartialView(Phieumuon);
        }


        public ActionResult Create()
        {
            ViewBag.TheDocGia = new SelectList(db.THEDOCGIAs, "MaTheDocGia", "TenTheDocGia");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="MaTheDocGia,NgayMuon,TinhTrangMuon")] PHIEUMUONSACH phieumuon)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUMUONSACHes.Add(phieumuon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieumuon);
        }

        //Create detail

        public ActionResult CreateDetail()
        {
            ViewBag.Sach = new SelectList(db.THONGTINSACHes, "MaSach", "TenSach");
            ViewBag.PhieuMuon = new SelectList(db.PHIEUMUONSACHes, "MaPhieuMuon");
            ViewBag.PhieuTra = new SelectList(db.PHIEUTRASACHes, "MaPhieuTra");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDetail([Bind(Include ="MaPhieuMuon,SoNgayMuon,HanTra,MaSach,MaPhieuTra")] CT_PHIEUMUONTRA ct_phieumuon)
        {
            if (ModelState.IsValid)
            {
                db.CT_PHIEUMUONTRA.Add(ct_phieumuon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ct_phieumuon);
        }

    }
}