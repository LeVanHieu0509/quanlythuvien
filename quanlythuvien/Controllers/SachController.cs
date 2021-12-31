using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using System.Data.Entity;
using System.Net;
using Models;

namespace quanlythuvien.Controllers
{
    public class SachController : BaseController
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: Sach
        public ActionResult Index()
        {
            
            var saches = db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1);
            return View(saches.ToList());
        }

        public ActionResult CountTotalSach()
        {
            var countTotalSach = new ThongtinsachModel();
            var totalSach = countTotalSach.CountTotalSach();
            ViewBag.infoSach = totalSach;
            return PartialView("CountTotalSach");
        }

        public ActionResult Create()
        {
            ViewBag.LoaiSach = new SelectList(db.THELOAISACHes, "MaTheLoaiSach", "TenTheLoaiSach");
            ViewBag.NXB = new SelectList(db.NHAXUATBANs, "MaNXB", "TenNXB");   
            ViewBag.TacGia = new SelectList(db.TACGIAs, "MaTacGia", "TenTacGia");
          
            return View();
        }

        //them sach
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenSach, MaTheLoaiSach, MaTacGia,NamXuatBan, MaNXB, NgayNhap, TriGia, SoLuongTonKho")] THONGTINSACH sach)
        {
            var iplSach = new ThongtinsachModel();
            DateTime namXB = Convert.ToDateTime(sach.NamXuatBan);
            DateTime checkNamXB = DateTime.Now.AddYears(-8);
            
            if (ModelState.IsValid && namXB > checkNamXB)
            {               
                db.THONGTINSACHes.Add(sach);
                db.SaveChanges();
                //var soluongsachton = iplSach.SoLuongSachTonKho();
                iplSach.updateTinhTrangCon(sach.MaSach);                      
                setAlert("Bạn đã thêm sách thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                setAlert("Chỉ nhận sách xuất bản trong vòng 8 năm", "error");
                return View(sach);
            }
          
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

        public ActionResult CreateTacGia()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTacGia([Bind(Include = "TenTacGia")] TACGIA tacgia)
        {
            if (ModelState.IsValid && db.TACGIAs.Count() <= 100)
            {
                db.TACGIAs.Add(tacgia);
                db.SaveChanges();
                setAlert("Thêm tác giả thành công", "success");
                return RedirectToAction("CreateTheLoaiSach");
            }
            else
            {
                setAlert("Bạn chỉ được thêm tối đa 100 tác giả", "error");
                return View(tacgia);
            }

            
        }
        //add LoaiSach

        public ActionResult CreateTheLoaiSach()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTheLoaiSach([Bind(Include = "TenTheLoaiSach")] THELOAISACH theloaisach)
        {
            if (ModelState.IsValid  && db.THELOAISACHes.Count() <= 3)
            {
                db.THELOAISACHes.Add(theloaisach);
                db.SaveChanges();
                setAlert("Thêm thể loại sách thành công", "success");
                return RedirectToAction("CreateNXB");
            }
            else
            {
                setAlert("Bạn chỉ được thêm tối đa 3 thể loại sách", "error");
                return View(theloaisach);
            }

           
        }

        //them nxb

        public ActionResult CreateNXB()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNXB([Bind(Include = "TenNXB")] NHAXUATBAN nxb)
        {
            
            if (ModelState.IsValid)
            {
                db.NHAXUATBANs.Add(nxb);
                db.SaveChanges();
                setAlert("Thêm thể loại sách thành công", "success");
                return RedirectToAction("Create");
            }
            else
            {
                ModelState.AddModelError("", "Thêm thể loại sách thất bại");
            }

            return View(nxb);
        }
    }
}