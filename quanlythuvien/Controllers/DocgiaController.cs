using Models;
using Models.Framework;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;

namespace quanlythuvien.Controllers
{
    public class DocgiaController : Controller
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
            if (ModelState.IsValid)
            {
                db.THEDOCGIAs.Add(docgia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docgia);
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
            db.THEDOCGIAs.Remove(docgia);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            THEDOCGIA docgia = db.THEDOCGIAs.Find(id);
            if (docgia == null)
            {
                return HttpNotFound();
            }
            return View(docgia);
        }

    }
}