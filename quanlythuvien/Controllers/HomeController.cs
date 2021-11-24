using Models;
using Models.Framework;
using System.Web.Mvc;

namespace quanlythuvien.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult xemdanhsachthedocgia()
        {
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

        //Chuc nang xem danh sach thong tin sach
        public ActionResult xemdanhsachthongtinsach()
        {
            var iplThongtinsach = new ThongtinsachModel();
            var model1 = iplThongtinsach.ListAll();
           
            return View(model1);
        }
    }
}