using Models;
using Models.Framework;
using System.Web.Mvc;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace quanlythuvien.Controllers
{
    public class HomeController : BaseController
    {
        private QuanlythuvienDbContext _db = new QuanlythuvienDbContext();
       
    
        //Chuc nang xem danh sach thong tin sach
        public ActionResult Index()
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

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "TaiKhoan,MatKhau, ConfirmPassword")] User _user)
        {
            if (ModelState.IsValid)
            {
                //var check = _db.Users.FirstOrDefault(s => s.TaiKhoan == _user.TaiKhoan);
                if (ModelState.IsValid)
                {
                    _db.Users.Add(_user);
                    _db.SaveChanges();
                    
                    return RedirectToAction("Login");
                }
                else
                {
                    setAlertLogin("Bạn đã đăng ký thất bại", "error");
                    return RedirectToAction("Register");
                }

                return View(_user);


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "TaiKhoan,MatKhau")] User user)
        {
           
                var data = _db.Users.Where(s => s.TaiKhoan.Equals(user.TaiKhoan) && s.MatKhau.Equals(user.MatKhau)).ToList();
                if (data.Count() > 0)
                {
                    Session["FullName"] = data.FirstOrDefault().TaiKhoan;
                    Session["MatKhau"] = data.FirstOrDefault().MatKhau;
                    Session["ID"] = data.FirstOrDefault().idUser;
                    setAlert("Bạn đã đăng nhập thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                setAlertLogin("Bạn đã đăng nhập thất bại", "error");
                    return RedirectToAction("Login");
                }
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}