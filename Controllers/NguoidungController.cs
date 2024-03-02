using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopSach.Models;

namespace ShopSach.Controllers
{
    public class NguoidungController : Controller
    {
        dbQuanLyBanSach db = new dbQuanLyBanSach();

        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        public ActionResult DangKy( FormCollection collection, KHANHHANG kh)
        {

            var hoten = collection["HoTen"];
            var tendn = collection["TaiKhoan"];
            var matkhau = collection["MatKhau"];
            // var matkhaunhaplai = collection["Matkhaunhaplai"];
            var email = collection["Email"];
            var diachi = collection["DiachiKH"];
            var dienthoai = collection["DienthoiKH"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);

            kh.HoTen = hoten;
            kh.TaiKhoan = tendn;
            kh.MatKhau = matkhau;
            kh.Email = email;
            kh.DiachiKH = diachi;
            kh.DienthoiKH = dienthoai;
            kh.Ngaysinh = DateTime.Parse(ngaysinh);
            db.KHANHHANGs.Add(kh);
            db.SaveChanges();
            return this.DangNhap();

        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TaiKhoan"];
            var matkhau = collection["MatKhau"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loai1"] = "Phải nhập tên đăng nhập";
            }else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loai2"] = "Phải nhập mật khẩu";
            }
            else
            {
                KHANHHANG kh = db.KHANHHANGs.SingleOrDefault(n => n.TaiKhoan == tendn && n.MatKhau == matkhau);
                if (kh == null)
                {
                    ViewBag.ThongBao = "Tài Khoản của bạn không tồn tại";

                }
                else
                {
                    Session["TaiKhoan"] = kh;
                    return Redirect("/BookStore/Index");
                }
            }
            return View();
        }
    }

}