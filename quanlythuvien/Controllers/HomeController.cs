using Models;
using Models.Framework;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;

namespace quanlythuvien.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        //Chuc nang xem danh sach thong tin sach
        public ActionResult xemdanhsachthongtinsach()
        {
            //Lay thong tin nhung bang khoas ngoai lien quan toi bang thong tin sach là khóa chính
            dynamic dy = new ExpandoObject();
            dy.theloaisachList = getTheloaisach();
            dy.nhaxuatbanList = getNhasanxuat();
            dy.thongtinsachList = getThongtinsach();
            dy.tacgiaList = getTacgia();

            //var iplThongtinsach = new ThongtinsachModel();
            //var model = iplThongtinsach.ListAll();

            return View(dy);
        }
        //lấy thông tin bảng thông tín sách trong database
        public List<THONGTINSACH> getThongtinsach()
        {
            var iplThongtinsach = new ThongtinsachModel();
            var LThongtinsach = iplThongtinsach.ListAll();
            return LThongtinsach;
        }
        //lấy thông tin bảng nhà sản xuất trong database
        public List<NHAXUATBAN> getNhasanxuat()
        {
            var iplNhaxuatban = new NhaxuatbanModel();
            var LNhaxuatban = iplNhaxuatban.ListAll();
            return LNhaxuatban;
        }
        //lấy data bảng thể loại sách  trong database
        public List<THELOAISACH> getTheloaisach()
        {
            var iplTheloaisach = new TheloaisachModel();
            var LTheloaisach = iplTheloaisach.ListAll();
            return LTheloaisach;
        }
        //Lấy data bảng tác giá
        public List<TACGIA> getTacgia()
        {
            var iplTacgia = new TacgiaModel();
            var LTacgia = iplTacgia.ListAll();
            return LTacgia;
        }
    }
}