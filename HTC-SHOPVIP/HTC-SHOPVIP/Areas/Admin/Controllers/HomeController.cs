using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTC_SHOPVIP.Models;


namespace HTC_SHOPVIP.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult LayGiaTriTuCSDL()
        {
            string[] DuLieu = new string[6];
            string sql = @"select count(tl.Maloaisp) as 'DienThoai',(select count(tl.Maloaisp) from SP_Theloai as TL join Sanpham as SP on sp.MaloaiSP=tl.Maloaisp join CTDonHang as dh on sp.MaSP=dh.MaSP where tl.Maloaisp=2 ) as 'MayTinhBang',(select count(tl.Maloaisp) from SP_Theloai as TL join Sanpham as SP on sp.MaloaiSP=tl.Maloaisp join CTDonHang as dh on sp.MaSP=dh.MaSP where tl.Maloaisp=5 ) as 'MayCu',(select count(tl.Maloaisp) from SP_Theloai as TL join Sanpham as SP on sp.MaloaiSP=tl.Maloaisp join CTDonHang as dh on sp.MaSP=dh.MaSP where tl.Maloaisp=3 ) as 'PC',(select count(tl.Maloaisp) from SP_Theloai as TL join Sanpham as SP on sp.MaloaiSP=tl.Maloaisp join CTDonHang as dh on sp.MaSP=dh.MaSP where tl.Maloaisp=4 ) as 'PhuKien',(select count(tl.Maloaisp) from SP_Theloai as TL join Sanpham as SP on sp.MaloaiSP=tl.Maloaisp join CTDonHang as dh on sp.MaSP=dh.MaSP where tl.Maloaisp=8 ) as 'Laptop'from SP_Theloai as TL join Sanpham as SP on sp.MaloaiSP=tl.Maloaisp join CTDonHang as dh on sp.MaSP=dh.MaSP where tl.Maloaisp=1";
            DataTable dt = Dataprovider.ExecuteQuery(sql);
            DuLieu[0] = dt.Rows[0]["DienThoai"].ToString();
            DuLieu[1] = dt.Rows[0]["MayTinhBang"].ToString();
            DuLieu[2] = dt.Rows[0]["MayCu"].ToString();
            DuLieu[3] = dt.Rows[0]["PC"].ToString();
            DuLieu[4] = dt.Rows[0]["PhuKien"].ToString();
            DuLieu[5] = dt.Rows[0]["Laptop"].ToString();
            return Json(new { DuLieu }, JsonRequestBehavior.AllowGet);

        }
    }
}