using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Models;

namespace quanlythuvien.Controllers
{
    public class PhieuMuonController : BaseController
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
                try
                {
                    db.PHIEUMUONSACHes.Add(phieumuon);
                    db.SaveChanges();
                    setAlert("Bạn đã tạo phiếu mượn sách thành công", "success");
                    return RedirectToAction("Index");
                }
                catch
                {
                    setAlert("Tạo phiếu mượn thất bại", "error");
                    return RedirectToAction("Index");
                }
                
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
                var masach = ct_phieumuon.MaSach;
                var ilpPhieuMuon = new PhieuMuonModel();
                string  ischeckTinhTrang = ilpPhieuMuon.ischeck(masach);
                //setAlert(ischeckTinhTrang, "success");
                if (ischeckTinhTrang.Trim() == "Con")
                {
                    db.CT_PHIEUMUONTRA.Add(ct_phieumuon);
                    db.SaveChanges();
                    setAlert("Bạn đã tạo chi tiết phiếu mượn sách thành công", "success");
                    return RedirectToAction("ChiTietMuonTra", "PhieuTra");
                }
                else
                {
                    setAlert("Bạn Tạo chi tiết phiếu mượn sách thất bại vì sách bạn mượn đã hết", "error");
                    return RedirectToAction("ChiTietMuonTra", "PhieuTra");
                   // return RedirectToAction("Index");
                }
                
            }
            return View(ct_phieumuon);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUONSACH phieumuon = db.PHIEUMUONSACHes.Find(id);
            if (phieumuon == null)
            {
                return HttpNotFound();
            }
            return View(phieumuon);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                PHIEUMUONSACH phieumuon = db.PHIEUMUONSACHes.Find(id);
                db.PHIEUMUONSACHes.Remove(phieumuon);
                db.SaveChanges();
                setAlert("Bạn xóa phiếu mượn sách thành công", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                setAlert("Bạn xóa phiếu mượn sách thất bại", "error");
                return RedirectToAction("Index");
            }
           
        }

        

    }
}