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
    public class MuonTraSachController : BaseController
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: MuonTraSach
        public ActionResult Index()
        {
            //var phieuTras = db.PHIEUTRASACHes.Include(s => s.THEDOCGIA);phieuTras.ToList()
            ViewBag.DocGia = new SelectList(db.THEDOCGIAs, "MaTheDocGia", "TenTheDocGia");
            var phieuTras = db.CT_PHIEUMUONTRA.Include(s => s.PHIEUMUONSACH).Include(s => s.PHIEUTRASACH).Include(s => s.THONGTINSACH);
            return View(phieuTras.ToList());

        }
    }
}