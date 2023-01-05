using HTC_SHOPVIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTC_SHOPVIP.Areas.QuanTriVien.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: QuanTriVien/TaiKhoan
        public ActionResult Index()
        {
            using (var con = new Model1())
            {
                var db = con.TaiKhoans.ToList();
                return View(db);
            }

        }
        public ActionResult TimKiemTenTaiKhoan(string tentaikhoan)
        {
            using (var con = new Model1())
            {
                var db = (from s in con.TaiKhoans
                          where s.tk.Contains(tentaikhoan)
                          select s).ToList();
                if (db.Count() > 0)
                {
                    ViewBag.thongbao = "có" + db.Count().ToString() + " bản ghi được tìm thấy";
                }
                else
                {
                    ViewBag.thongbao = "Tên tài khoản không tồn tại";
                }
                return View(db);

            }

        }

        public ActionResult XoaTK(string id)
        {
            using (var con = new Model1())
            {
                var sp = (from s in con.TaiKhoans
                          where s.tk == id
                          select s).FirstOrDefault();
                con.TaiKhoans.Remove(sp);
                con.SaveChanges();
                return View("Index");
            }
        }
    }

    }