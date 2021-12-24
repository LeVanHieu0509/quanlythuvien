using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace quanlythuvien.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected void setAlert( string message,string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
        protected void setAlertLogin(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        public void UpdateSoLuongMuonSach(int? mathedocgia, int soluongsachdangmuon)
        {
            var iplThedocgia = new ThedocgiaModel();
            iplThedocgia.UpdateSoLuongSachDangMuon(mathedocgia, soluongsachdangmuon);
        }

        public int GetCountChitietMuonsach(int? id)
        {
            var iplThedocgia = new CtPhieuMuonTraModel();
            var result = iplThedocgia.CountTotalDangMuon(id);
            return result;
        }
    }
}