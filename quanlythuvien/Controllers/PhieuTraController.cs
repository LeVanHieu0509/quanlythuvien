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
    public class PhieuTraController : BaseController
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
        public ActionResult Create([Bind(Include = "MaTheDocGia,NgayTra")] PHIEUTRASACH phieutra)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTRASACHes.Add(phieutra);
                db.SaveChanges();
                setAlert("Tạo phiếu trả sách thành công", "success");
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
            return View(getIdPhieuMuonTra(id));
        }
        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RemoveIdPhieuMuonTra(id);

            setAlert("Độc giả trả sách thành công", "success");
            return RedirectToAction("ChiTietMuonTra");
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
            iplPhieuMuonTra.RemoveMaPhieuTra(id);
           
        }
        public void RemoveIdPhieuMuon(int? id)
        {
            var iplPhieuMuonTra = new CtPhieuMuonTraModel();
            iplPhieuMuonTra.RemoveMaPhieuMuon(id);

        }
      




        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRASACH phieutra = db.PHIEUTRASACHes.Find(id);
            if (phieutra == null)
            {
                return HttpNotFound();
            }
            return View(phieutra);
        }

        // POST
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            try
            {
                PHIEUTRASACH phieutra = db.PHIEUTRASACHes.Find(id);
                db.PHIEUTRASACHes.Remove(phieutra);
                db.SaveChanges();
                setAlert("Xóa phiếu trả sách thành công", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                setAlert("Độc giả chưa trả sách hoặc chưa trả tiền phạt", "error");
                return RedirectToAction("Index");
            }
            
        }

        //
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRASACH phieutra = db.PHIEUTRASACHes.Find(id);
            if (phieutra == null)
            {
                return HttpNotFound();
            }
            return View(phieutra);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuTra, MaTheDocGia,NgayTra,TienPhatKyNay,TongNo")] PHIEUTRASACH phieutra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieutra).State = EntityState.Modified;
                db.SaveChanges();
                setAlert("Thẻ độc giả đã được sửa thành công", "success");
                return RedirectToAction("Index");
            }
            return View(phieutra);
        }

        //Detail
        public ActionResult Details(int? id)
        {
            PHIEUTRASACH phieutra = db.PHIEUTRASACHes.Find(id);
            try
            {
                DateTime date = DateTime.Today;
                
                CtPhieuMuonTraModel iplChiTietMuonTra = new CtPhieuMuonTraModel();

                //12/25/2021 12:00:00 AM
                DateTime? ngaytra = iplChiTietMuonTra.FindNgayTra(phieutra.MaTheDocGia);
                DateTime? hantra = iplChiTietMuonTra.FindHanTra(id);
                //     12/25/2021
                string ngaytra1 = ngaytra.ToString().Substring(0, 10);
                string hantra1 = hantra.ToString().Substring(0, 10);

                //12252021

                //5/2021
                int ngaytrasach = Convert.ToInt32(ngaytra1.Substring(3, 2));
                int thangtrasach = Convert.ToInt32(ngaytra1.Substring(0, 2));
                int namtrasach = Convert.ToInt32(ngaytra1.Substring(6, 4));


                int ngayhantra = Convert.ToInt32(hantra1.Substring(3, 2));
                int thanghantra = Convert.ToInt32(hantra1.Substring(0, 2));
                int namhantra = Convert.ToInt32(hantra1.Substring(6, 4));

                int tienphat = (ngaytrasach - ngayhantra) + (thangtrasach - thanghantra) * 30 + (namtrasach - namtrasach) * 325;
                decimal tienphatkynay = Convert.ToDecimal(tienphat) * 1000;

                iplChiTietMuonTra.UpdateTienPhatKyNay(tienphatkynay, phieutra.MaPhieuTra);



                setAlert("Thẻ độc giả đã được sửa thành công", "success");
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (phieutra == null)
                {
                    return HttpNotFound();
                }
                return View(phieutra);
            }
            catch
            {
                return View(phieutra);
            }
            
        }

    }
}