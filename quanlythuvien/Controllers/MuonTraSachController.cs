using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanlythuvien.Controllers
{
    public class MuonTraSachController : BaseController
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: MuonTraSach
        public ActionResult Index()
        {
            var phieuTras = db.PHIEUTRASACHes.Include(s => s.THEDOCGIA);
            return View(phieuTras.ToList());
        }


    }
}