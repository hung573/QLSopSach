using ShopSach.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopSach.Controllers
{
    public class GioHangController : Controller
    {
        dbQuanLyBanSach data = new dbQuanLyBanSach();
        //Lay Gio hang
        public List<GioHang> Laygiohang()
        {
            List<GioHang> listGiohang = Session["Giohang"] as List<GioHang>;
            if (listGiohang == null)
            {
                listGiohang = new List<GioHang>();
                Session["Giohang"] = listGiohang;
            }
            return listGiohang;
        }
        //Them vao gio hang
        public ActionResult ThemGioHang(int Masach, string strURL)
        {
            //Lay ra session gio hang
            List<GioHang> listGiohang = Laygiohang();
            //kiem tra sach da ton tai trong session hay chua
            GioHang sanpham = listGiohang.Find(n => n.iMasach == Masach);
            if (sanpham == null)
            {
                sanpham = new GioHang(Masach);
                listGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        //Tong so luong
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> listGiohang = Session["Giohang"] as List<GioHang>;
            if (listGiohang != null)
            {
                iTongSoLuong = listGiohang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }
        //Tinh Tong tien
        private double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> listGiohang = Session["Giohang"] as List<GioHang>;
            if (listGiohang != null)
            {
                iTongTien = listGiohang.Sum(n => n.dThanhtien);
            }
            return iTongTien;
        }
        
        //Xoa gio hang
        public ActionResult Xoagiohang(int iMaSP)
        {
            List<GioHang> listGiohang = Laygiohang();
            GioHang sanpham = listGiohang.SingleOrDefault(n => n.iMasach == iMaSP);
            if (sanpham != null)
            {
                listGiohang.RemoveAll(n => n.iMasach == iMaSP);
                return RedirectToAction("GioHang");
            }
            if (listGiohang.Count == 0)
            {
                return RedirectToAction("Index", "BookStore");
            }
            return RedirectToAction("GioHang");
        }
        //cap nhat gio hang
        public ActionResult CapnhatGioHang(int iMaSP, FormCollection f)
        {
            List<GioHang> listGioHang = Laygiohang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.iMasach == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtSoLuong"].ToString()); 
            }
            return RedirectToAction("GioHang");
        }
        //Xoa tat ca trong gio hang
        public ActionResult XoatTatCaTrongGioHang()
        {
            List<GioHang> listGioHang = Laygiohang();
            listGioHang.Clear();
            return RedirectToAction("Index", "BookStore");
        }
        //Hien thi view DangNhap dde cap nhat cac thong tin cho Don Hang
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString()=="") {
                return RedirectToAction("DangNhap","Nguoidung");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "BookStore");
            }
            List<GioHang> listGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(listGiohang);
        }
        public async Task<ActionResult> DatHang(FormCollection f)
        {
            DONATHANG DDH = new DONATHANG();
            KHANHHANG kh = (KHANHHANG)Session["Taikhoan"];
            List<GioHang> ListGiohang = Laygiohang();
            DDH.MaKH = kh.MaKH;
            DDH.NgayDH = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", f["Ngaygiao"]);
            DDH.Ngaygiao = DateTime.Parse(ngaygiao);
            DDH.Tinhtranggiaohang = false;
            DDH.Dathanhtoan = false;
            data.DONATHANGs.Add(DDH);

            //Them Chi tiet don hang 
            foreach (var item in ListGiohang)
            {
                CTDATHANG ctdh = new CTDATHANG();
                ctdh.SoDH = DDH.SoDH;
                ctdh.Massach = item.iMasach;
                ctdh.Soluong = item.iSoluong;
                ctdh.Dongia = (decimal)item.dDongia;
                data.CTDATHANGs.Add(ctdh);
            }
            await data.SaveChangesAsync();
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");
        }
        //Xac nhan don hang
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
        // GET: GioHang
        public ActionResult GioHang()
        {
            List<GioHang> listGiohang = Laygiohang();
            if(listGiohang.Count == 0)
            {
                return RedirectToAction("Index", "BookStore");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(listGiohang);

        }
        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }

    }
}