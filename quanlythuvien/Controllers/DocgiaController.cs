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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult xemdanhsachthedocgia()
        {
            QuanlythuvienDbContext db = new QuanlythuvienDbContext();
            //var model = db.Database.SqlQuery<THEDOCGIA>("select * from THEDOCGIA, LOAIDOCGIA").ToList();

            var iplThedocgia = new ThedocgiaModel();
            var model = iplThedocgia.ListAll();
            return View(model);
        }


        [HttpGet]
        public ActionResult taothedocgia()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult taothedocgia(THEDOCGIA collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new ThedocgiaModel();
                    int res = model.TaoTheDocGia(collection.HoTenDocGia,
                       collection.DiaChi, collection.Email, collection.MaLoaiDocGia);

                    if (res > 0)
                    {
                        return RedirectToAction("xemdanhsachthedocgia");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Them moi ko thanh cong");
                    }
                    return RedirectToAction("index");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }

        }

    }
}