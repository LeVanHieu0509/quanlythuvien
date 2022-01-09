using Models;
using Models.Framework;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System;

namespace quanlythuvien.Controllers
{
    public class DocgiaController : BaseController
    {
        // GET: Docgia
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        public ActionResult Index(string searchBy, string search)
        {
            var docgia = db.THEDOCGIAs.Include(s => s.LOAIDOCGIA);
            if (searchBy == "HoTenDocGia")
                return View(db.THEDOCGIAs.Include(s => s.LOAIDOCGIA).Where(s => s.HoTenDocGia.StartsWith(search)).ToList());
            else if (searchBy == "TenLoaiDocGia")
                return View(db.THEDOCGIAs.Include(s => s.LOAIDOCGIA).Where(s => s.LOAIDOCGIA.TenLoaiDocGia.StartsWith(search)).ToList());
 
            else
                return View(docgia.ToList());         
        }

        public ActionResult CountTotalDocGia()
        {
            var countTotalDocGia = new ThedocgiaModel();
            var totalDocGia = countTotalDocGia.CountTotalDocGia();
            ViewBag.infoDocGia = totalDocGia;
            return PartialView("CountTotalDocGia");
        }
        public ActionResult ChoosesLoaiDG()
        {
            LOAIDOCGIA loaiDG = new LOAIDOCGIA();
            loaiDG.LoaiDGCollection = db.LOAIDOCGIAs.ToList();
            return PartialView(loaiDG);    
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotenDocGia, MaLoaiDocGia,NgaySinh,DiaChi,Email,NgayLapThe")] THEDOCGIA docgia)
        {
            DateTime ngaysinh = Convert.ToDateTime(docgia.NgaySinh);;
            DateTime checkAge = DateTime.Now.AddYears(-18);
            DateTime checkAge2 = DateTime.Now.AddYears(-55);
            //the co gia tri 6 thang
            DateTime date = Convert.ToDateTime(docgia.NgayLapThe).AddDays(181);
            docgia.NgayHetHanThe = date;

            //setAlert(added.ToString(), "success");
            if (ModelState.IsValid && ngaysinh < checkAge && ngaysinh > checkAge2)
            {
                db.THEDOCGIAs.Add(docgia);

                
                db.SaveChanges();
                setAlert("Thêm thẻ độc giả thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                setAlert("Độc giả không nằm trong độ tuổi cho phép mượn sách", "error");
                return View(docgia);
            }            
        }

        //xoa
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEDOCGIA docgia = db.THEDOCGIAs.Find(id);
            if (docgia == null)
            {
                return HttpNotFound();
            }
            return View(docgia);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THEDOCGIA docgia = db.THEDOCGIAs.Find(id);
            try
            { 
                db.THEDOCGIAs.Remove(docgia);
                db.SaveChanges();
                setAlert("Thẻ độc giả đã được xóa", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                setAlert("Không thể xóa độc giả đang mượn sách", "error");
                return View(docgia);
            }
            
        }

        //edit
        // GET
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEDOCGIA docgia = db.THEDOCGIAs.Find(id);
            if (docgia == null)
            {
                return HttpNotFound();
            }
            return View(docgia);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTheDocGia,HoTenDocGia,MaLoaiDocGia,NgaySinh,DiaChi,Email,NgayLapThe")] THEDOCGIA docgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docgia).State = EntityState.Modified;
                db.SaveChanges();
                setAlert("Thẻ độc giả đã được sửa thành công", "success");
                return RedirectToAction("Index");
            }
            return View(docgia);
        }

        //Detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var iplPhieuMuon = new PhieuMuonModel();
            var result = iplPhieuMuon.FindMaPhieuMuon(id); //MaPhieuMuon:12, id: 31
            var count = GetCountChitietMuonsach(result);
            UpdateSoLuongMuonSach(id, count);
            THEDOCGIA docgia = db.THEDOCGIAs.Find(id);
            if (docgia == null)
            {
                return HttpNotFound();
            }

            try
            {
                var maphieutra = iplPhieuMuon.FindMaPhieuTra(id);
                PHIEUTRASACH phieutra = db.PHIEUTRASACHes.Find(maphieutra);
                CtPhieuMuonTraModel iplChiTietMuonTra = new CtPhieuMuonTraModel();
                ThedocgiaModel iplTheDocGia = new ThedocgiaModel();


                //     12/25/2021
                //string ngaytra = iplChiTietMuonTra.FindNgayTra(id).ToString().Substring(0, 10);
                //string hantra = iplChiTietMuonTra.FindHanTra(id).ToString().Substring(0, 10);

                ////5/2021
                //int ngaytrasach = Convert.ToInt32(ngaytra.Substring(3, 2));
                //int thangtrasach = Convert.ToInt32(ngaytra.Substring(0, 2));
                //int namtrasach = Convert.ToInt32(ngaytra.Substring(6, 4));


                //int ngayhantra = Convert.ToInt32(hantra.Substring(3, 2));
                //int thanghantra = Convert.ToInt32(hantra.Substring(0, 2));
                //int namhantra = Convert.ToInt32(hantra.Substring(6, 4));

                //int ngaytre = (ngaytrasach - ngayhantra) + (thangtrasach - thanghantra) * 30 + (namtrasach - namtrasach) * 325;

                
                
                   int soluong = iplChiTietMuonTra.CountTotalMuonQuaHan(phieutra.MaPhieuTra);
                   //setAlert(soluong.ToString(), "success");
                   iplTheDocGia.UpdateSLSachMuonQuaHan(id, soluong); // mathe va soluong
                
                return View(docgia);
            }
            catch
            {
                ThedocgiaModel iplTheDocGia = new ThedocgiaModel();
                iplTheDocGia.UpdateSLSachMuonQuaHan(id, 0);
                return View(docgia);
            }

        }

     
        public ActionResult CreateLoaiDocGia()
        {
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoaiDocGia([Bind(Include = "TenLoaiDocGia")] LOAIDOCGIA loaidocgia)
        {
            if (ModelState.IsValid && db.LOAIDOCGIAs.Count() <= 2)
            {
                    //var nfDoc = db.LOAIDOCGIAs.Find(loaidocgia.TenLoaiDocGia);
                    db.LOAIDOCGIAs.Add(loaidocgia);
                    db.SaveChanges();
                    setAlert("Thêm loại độc giả thành công", "success");
                    return RedirectToAction("Create");
                               
            }
            else
            {
               
                setAlert("Bạn chỉ được thêm tối đa 2 loại độc giả", "error");
                return View(loaidocgia);
            }          
        }
    }


   
}