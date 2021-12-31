using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace quanlythuvien.Controllers
{
    public class TienPhatController : BaseController
    {
        // GET: TienPhat
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();

        public ActionResult Index()
        {
            var phieuThu = db.PHIEUTRASACHes.Include(s => s.THEDOCGIA);
            return View(phieuThu.ToList());
        }

        public ActionResult ListPhieuThuTien()
        {
            var phieuThu = db.PHIEUTHUTIENPHATs.Include(s => s.PHIEUTRASACH);
            return View(phieuThu.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.PhieuTraSach = new SelectList(db.PHIEUTRASACHes, "MaPhieuPhat");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuTra,SoTienThu")] PHIEUTHUTIENPHAT phieuthu)
        {
            PhieuThuTienModel iplPhieuThuTien = new PhieuThuTienModel();
            if (ModelState.IsValid )
            {
                if(phieuthu.SoTienThu <= iplPhieuThuTien.TotalNo(phieuthu.MaPhieuTra))
                {             
                    iplPhieuThuTien.UpdateTongNo(phieuthu.SoTienThu, phieuthu.MaPhieuTra);
                    db.PHIEUTHUTIENPHATs.Add(phieuthu);
                    db.SaveChanges();
                    setAlert("Thêm phiếu thu thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    setAlert("Số tiền thu không được vượt quá tổng nợ", "error");
                    return View(phieuthu);

                }

            }
            else
            {
                ModelState.AddModelError("", "Them the doc gia khong thanh cong");
            }

            return View(phieuthu);
        }


        // // GET: 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHUTIENPHAT phieuthu = db.PHIEUTHUTIENPHATs.Find(id);
            if (phieuthu == null)
            {
                return HttpNotFound();
            }
            return View(phieuthu);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIEUTHUTIENPHAT phieuthu = db.PHIEUTHUTIENPHATs.Find(id);
            db.PHIEUTHUTIENPHATs.Remove(phieuthu);
            setAlert("Bạn đã xóa thành công", "success");
            db.SaveChanges();
            return RedirectToAction("ListPhieuThuTien");
        }
        //public ActionResult ChoosesPhieuTra()
        //{
        //    PHIEUTRASACH Phieutra = new PHIEUTRASACH();
        //    Phieutra.PhieuTraCollection = db.PHIEUTRASACHes.ToList();
        //    return PartialView(Phieutra);
        //}
    }
}