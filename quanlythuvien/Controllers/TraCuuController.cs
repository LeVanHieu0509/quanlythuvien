using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using System.Data.Entity;
using Models;

namespace quanlythuvien.Controllers
{
    public class TraCuuController : Controller
    {
        public QuanlythuvienDbContext db = new QuanlythuvienDbContext();
        // GET: TraCuu
        public ActionResult Index(String searchBy, string search)
        {
            var saches = db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1);
            if (searchBy == "TenSach")
                return View(db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1).Where(s => s.TenSach.StartsWith(search)).ToList());
            else if (searchBy == "TenTacGia")
                return View(db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1).Where(s => s.tacgia1.TenTacGia.StartsWith(search)).ToList());
            else if (searchBy == "TenNhaXuatBan")
                return View(db.THONGTINSACHes.Include(s => s.loaisach1).Include(s => s.tacgia1).Include(s => s.nhaxuatban1).Where(s => s.nhaxuatban1.TenNXB.StartsWith(search)).ToList());
            else
                return View(saches.ToList());
        }
    }
}