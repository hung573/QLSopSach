using PagedList;
using ShopSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace ShopSach.Controllers
{
    public class AdminController : Controller
    {
        dbQuanLyBanSach db = new dbQuanLyBanSach();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Sach(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.SACH1.ToList().OrderBy(n => n.Masach).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ThemSach()
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.Tenchude), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> ThemSach(FormCollection collection,SACH1 sach1, HttpPostedFileBase fileUpLoad)
        {

            ViewBag.ThongBao = null;
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.Tenchude), "MaCD", "TenChude");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            var tensp = collection["Tensanpham"];
            var giaban = collection["Giaban"];
            var mota = collection["Mota"];
            var soluongton = collection["Soluongton"];
            if (fileUpLoad == null) {
                ViewBag.ThongBao = "Vui long chon anh bia";
            }
            else
            {
                if (ModelState.IsValid) {
                    var fileName = Path.GetFileName(fileUpLoad.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hinh anh da ton tai";
                    }
                    else
                    {
                        fileUpLoad.SaveAs(path);
                    }
                    sach1.Anhbia = fileName;
                    sach1.Tensach = tensp;
                    sach1.Giaban = int.Parse(giaban);
                    sach1.Mota = mota;
                    sach1.Soluongton = int.Parse(soluongton);
                    db.SACH1.Add(sach1);
                    await db.SaveChangesAsync();
                }
            }
            if(ViewBag.ThongBao != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Admin/Sach");
            }
        }
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loai1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loai2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin admin = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (admin == null)
                {
                    ViewBag.ThongBao = "Tài Khoản của bạn không tồn tại";

                }
                else
                {
                    Session["TaiKhoanadmin"] = admin;
                    return Redirect("/Admin/Index");

                }
            }
            return View();
        }
    }
}