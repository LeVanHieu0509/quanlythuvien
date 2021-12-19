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
    public class PhieuTraController : Controller
    {
        // GET: PhieuTra
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
       
        public ActionResult Index()
        {
            var phieuTras = db.PHIEUTRASACHes.Include(s => s.THEDOCGIA);
            return View(phieuTras.ToList());
        }
        public ActionResult ChiTietMuonTra()
        {
            //var phieuTras = db.PHIEUTRASACHes.Include(s => s.THEDOCGIA);phieuTras.ToList()
            var phieuTras = db.CT_PHIEUMUONTRA.Include(s => s.PHIEUMUONSACH).Include(s => s.PHIEUTRASACH).Include(s => s.THONGTINSACH);
            return View(phieuTras.ToList());
            
        }
        public ActionResult Create()
        {
            ViewBag.TheDocGia = new SelectList(db.THEDOCGIAs, "MaTheDocGia", "TenTheDocGia");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTheDocGia,NgayTra,TienPhatKyNay,TongNo")] PHIEUTRASACH phieutra)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTRASACHes.Add(phieutra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieutra);
        }

        public ActionResult ChoosesPhieuTra()
        {
            PHIEUTRASACH PhieuTra = new PHIEUTRASACH();
            PhieuTra.PhieuTraCollection = db.PHIEUTRASACHes.ToList();
            return PartialView(PhieuTra);
        }


        //Tra Sach
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //getIdPhieuMuonTra(id);
            //CT_PHIEUMUONTRA ctMuonTra = db.CT_PHIEUMUONTRA.Find(id);
            //PHIEUMUONSACH phieuMuon = db.PHIEUMUONSACHes.Find(id);
            //PHIEUTRASACH phieuTra = db.PHIEUTRASACHes.Find(id);
            //if (phieuTra == null)
            //{
            //    return HttpNotFound();
            //}
            return View(getIdPhieuMuonTra(id));
        }

        public List<CT_PHIEUMUONTRA> getIdPhieuMuonTra(int? id)
        {
            var iplPhieuMuonTra = new CtPhieuMuonTraModel();
            var LPhieuMuonTra = iplPhieuMuonTra.FindMaPhieuTra(id);
            return LPhieuMuonTra;
        }

        public void RemoveIdPhieuMuonTra(int? id)
        {
            var iplPhieuMuonTra = new CtPhieuMuonTraModel();
            var LPhieuMuonTra = iplPhieuMuonTra.FindMaPhieuTra(id);
           
        }
        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            //PHIEUMUONSACH phieuMuon = db.PHIEUMUONSACHes.Find(id);
            //PHIEUTRASACH phieuTra = db.PHIEUTRASACHes.Find(id);
            //db.CT_PHIEUMUONTRA.Remove(ctMuonTra);
            //db.PHIEUMUONSACHes.Remove(phieuMuon);
            RemoveIdPhieuMuonTra(id);     
            ViewBag.Message = string.Format("Ban Da Tra Sach Thanh Cong");
            return RedirectToAction("ChiTietMuonTra");
        }
    }
}