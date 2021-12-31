using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using System.Data.Entity;
using Models;
using System.Net;

namespace quanlythuvien.Controllers
{
    public class TraCuuController : BaseController
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: TraCuu
        public ActionResult Index(String searchBy, string search)
        {
            var saches = db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1);
            if (searchBy == "TenSach")
                return View(db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1).Where(s => s.TenSach.StartsWith(search)).ToList());
            else if (searchBy == "TenTacGia")
                return View(db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1).Where(s => s.tacgia1.TenTacGia.StartsWith(search)).ToList());
            else if (searchBy == "TenNhaXuatBan")
                return View(db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1).Where(s => s.nhaxuatban1.TenNXB.StartsWith(search)).ToList());
            else
                return View(saches.ToList());
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
                setAlert("Bạn đã sửa thông tin sách thành công", "success");
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
            setAlert("Bạn đã xóa sách thành công", "success");
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