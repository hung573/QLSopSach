using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopSach.Models
{
    public class GioHang
    {
        dbQuanLyBanSach data = new dbQuanLyBanSach();
        public int iMasach { get; set; }
        public string sTensach { get; set; }
        public string sAnhbia { get; set; }
        public Double dDongia { get; set; }
        public int iSoluong { get; set; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        public GioHang(int Masach) {
            iMasach = Masach;
            SACH1 sach = data.SACH1.Single(n => n.Masach == iMasach);
            sTensach = sach.Tensach;
            sAnhbia = sach.Anhbia;
            dDongia = double.Parse(sach.Giaban.ToString());
            iSoluong = 1;
        }
    }
}