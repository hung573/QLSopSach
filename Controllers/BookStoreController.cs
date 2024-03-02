using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopSach.Models;

using PagedList;
using PagedList.Mvc;

namespace ShopSach.Controllers
{
    public class BookStoreController : Controller
    {
        dbQuanLyBanSach db = new dbQuanLyBanSach();

        private List<SACH1> Laysachmoi(int count) {
            return db.SACH1.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        // GET: BookStore
        public ActionResult Index(int ? page)
        {
            int pageSize = 3;
            int pageNum = (page ?? 1);
            var sachmoi =  Laysachmoi(15);
            return View(sachmoi.ToPagedList(pageNum,pageSize));
        }
        public ActionResult Chude()
        {
            var chude = from cd in db.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult Nhaxuatban()
        {
            var nhaxuatban = from xb in db.NHAXUATBANs select xb;
            return PartialView(nhaxuatban);
        }
        public ActionResult SPTheochude(int id)
        {
            var sach = from s in db.SACH1 where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SPTheonhaxuatban(int id)
        {
            var sach = from s in db.SACH1 where s.MaNXB == id select s;
            return View(sach);
        }
        public ActionResult details(int id)
        {
            var sach = from s in db.SACH1
                       where s.Masach == id select s;
            return View(sach.Single());
        }
    }
}