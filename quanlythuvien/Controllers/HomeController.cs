using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult taothedocgia()
        {
            return View();
        }
    }
}