using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTC_SHOPVIP.Models;

namespace HTC_SHOPVIP.Areas.Admin.Controllers
{
    public class KhuyenMaiController : Controller
    {
        // GET: Admin/KhuyenMai
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("AdminLoginView", "TaiKhoan");
            }
            return View();
        }

        public ActionResult ThemMoiKhuyemMai()
        {
            return View();
        }

        public  ActionResult DonKM(DateTime ngaybatdau, DateTime ngayketthuc, int phantramgg, string mota)
        {
            using(var con=new Model1())
            {
                var kmnew = new khuyenmai();
                kmnew.Ngaybatdau = ngaybatdau;
                kmnew.Ngayketthuc = ngayketthuc;
                kmnew.phantramgiam = phantramgg;
                kmnew.MoTa = mota;

                con.khuyenmais.Add(kmnew);
                con.SaveChanges();
            }
            return View("Index");
        }
        public ActionResult XoaKM (int id)
        {
            using (var con=new Model1())
            {
                var km=con.khuyenmais.Find(id);
                var km1 = (from s in con.KM_SPs
                           where s.MaKM==id
                           select s).ToList();
                foreach(var  item in km1)
                {
                    con.KM_SPs.Remove(item);
                    con.SaveChanges();
                }
                var km2 = (from s in con.KM_KHs
                           where s.MaKM == id
                           select s).ToList();
                foreach (var item in km2)
                {
                    con.KM_KHs.Remove(item);
                    con.SaveChanges();
                }
                con.khuyenmais.Remove(km);
                con.SaveChanges();
                return View("Index");
                
            }
        }

        public ActionResult ViewChinhSua(int id)
        {
            ViewBag.id = id;
            return View();
        }

        public ActionResult CapNhat(DateTime ngaybatdau, DateTime ngayketthuc, int phantramgg, string mota, int id)
        {
            using (var con = new Model1())
            {
                var sp = con.khuyenmais.Find(id);
                sp.Ngaybatdau = ngaybatdau;
                sp.Ngayketthuc = ngayketthuc;
                sp.phantramgiam = phantramgg;
                sp.MoTa = mota;
                con.SaveChanges();
                 
            }
            return View("Index");
        }
    }
}