using Models;
using Models.Framework;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;

namespace quanlythuvien.Controllers
{
    public class DocgiaController : Controller
    {
        // GET: Docgia
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        public ActionResult Index()
        {
            return View(db.THEDOCGIAs.ToList());
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

    }
}