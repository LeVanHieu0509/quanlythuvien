using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using System.Data.Entity;
using System.Net;

namespace quanlythuvien.Controllers
{
    public class SachController : Controller
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: Sach
        public ActionResult Index()
        {
            var saches = db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1);
            return View(saches.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.LoaiSach = new SelectList(db.THELOAISACHes, "MaTheLoaiSach", "TenTheLoaiSach");
            ViewBag.NXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB");   
            ViewBag.TacGia = new SelectList(db.TACGIAs, "MaTacGia", "TenTacGia");
          
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenSach, MaTheLoaiSach, MaTacGia,NamXuatBan, MaNXB, NgayNhap, TriGia, SoLuongTonKho")] THONGTINSACH sach)
        {
            if (ModelState.IsValid)
            {
                db.THONGTINSACHes.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.LoaiSach = new SelectList(db.LoaiSaches, "ID", "MaLoaiSach", sach.LoaiSach);
            //ViewBag.NXB = new SelectList(db.NXBs, "ID", "MaNXB", sach.NXB);
            //ViewBag.Muon = new SelectList(db.PhieuMuons, "ID", "MaMuon", sach.Muon);
            //ViewBag.TacGia = new SelectList(db.TacGias, "ID", "MaTacGia", sach.TacGia);
            //ViewBag.ViTri = new SelectList(db.ViTris, "ID", "MaViTri", sach.ViTri);
            return View(sach);
        }

        public ActionResult ChoosesLoaiSach()
        {
            THELOAISACH loaisach = new THELOAISACH();
            loaisach.LoaiSachCollection = db.THELOAISACHes.ToList();
            return PartialView(loaisach);
        }
        public ActionResult ChoosesTacGia()
        {
            TACGIA tacgia = new TACGIA();
            tacgia.TacGiaCollection = db.TACGIAs.ToList();
            return PartialView(tacgia);
        }
        public ActionResult ChoosesNXB()
        {
            NHAXUATBAN NXB = new NHAXUATBAN();
            NXB.NXBCollection = db.NHAXUATBANs.ToList();
            return PartialView(NXB);
        }


        // GET: Saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINSACH sach = db.THONGTINSACHes.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiSach = new SelectList(db.THELOAISACHes, "MaTheLoaiSach", "TenTheLoaiSach");
            ViewBag.NXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB");
            ViewBag.TacGia = new SelectList(db.TACGIAs, "MaTacGia", "TenTacGia");
            return View(sach);
        }

        // POST: Saches

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach, TenSach, MaTheLoaiSach,NamXuatBan,NgayNhap,TriGia,MaNXB,MaTacGia, SoLuongTonKho")] THONGTINSACH sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiSach = new SelectList(db.THELOAISACHes, "MaTheLoaiSach", "TenTheLoaiSach");
            ViewBag.NXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB");
            ViewBag.TacGia = new SelectList(db.TACGIAs, "MaTacGia", "TenTacGia");
            return View(sach);
        }

        // GET: 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINSACH sach = db.THONGTINSACHes.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THONGTINSACH sach = db.THONGTINSACHes.Find(id);
            db.THONGTINSACHes.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINSACH sach = db.THONGTINSACHes.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }
    }
}