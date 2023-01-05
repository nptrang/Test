using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using HTC_SHOPVIP.Models;

namespace HTC_SHOPVIP.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
   
 




        public ActionResult AdminLoginView(string tb, string tb1, string tb2)
        {
            ViewBag.tb = tb;
            ViewBag.tb1=tb1;
            ViewBag.tb2 = tb2;
            return View();
        }

        public ActionResult Login(string taikhoan, string matkhau)
        {

            using(var con=new Model1())
            {
                var tk = (from s in con.NguoiBans
                          select s).ToList();
                var tk1 = (from s in con.TaiKhoans
                           where s.isSeller == true
                           select s).ToList();
                foreach(var it in tk1)
                {
                    if(it.tk.ToLower().Trim() == taikhoan.ToLower().Trim() && it.mk.ToLower().Trim()==matkhau.ToLower().Trim() )
                    {
                        var admin = (from s in con.NguoiBans
                                     where s.taikhoan.ToLower().Trim() == taikhoan.ToLower().Trim() && s.matkhau.ToLower().Trim()==matkhau.ToLower().Trim()
                                     select s).FirstOrDefault();
                        Session["admin"] = admin;
                        return Redirect("/Admin/SanPham/DSSanPham");
                    }
                  
                }
                //return RedirectToAction("LoginView", "Home", new { tb = "Tên đăng nhập hoặc tài khoản sai rồi bạn ơi" });
                return RedirectToAction("/AdminLoginView", new { tb = "Tên đăng nhập hoặc tài khoản sai rồi bạn ơi" });
                //return Redirect("/Admin/TaiKhoan/AdminLoginView");

            }

           
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(strRegex);

            return regex.IsMatch(email);
        }
        public ActionResult LuuTaiKhoan(string email, string username, string pass, string repass, string sdt, string hoten,string diachi)
        {
            
            var nv = new NguoiBan();
            var taikhoan = new TaiKhoan();
            nv.Email = email;
            nv.taikhoan = username;
            nv.matkhau = pass;
            nv.HoTen = hoten;
            nv.SDT = sdt;
            nv.DiaChi = diachi;
            taikhoan.tk = username;
            taikhoan.mk = pass;
            taikhoan.isBuyer = false;
            taikhoan.isSeller = true;
            using (var con=new Model1()){
                int dem=(from s in con.NguoiBans
                         where s.taikhoan.Trim().ToLower()==username.Trim().ToLower()
                         select s).Count();
                if(username=="" || pass=="" || repass=="" || sdt=="" || hoten == "")
                {
                    return RedirectToAction("/AdminLoginView", new { tb1 = "Điền đầy đủ thông tin bắt buộc" });
                }
                if (IsNumber(hoten) == true)
                {
                    return RedirectToAction("/AdminLoginView", new { tb1 = "Tên người dùng không hợp lệ" });
                }
                if (dem > 0)
                {
                    return RedirectToAction("/AdminLoginView", new { tb1 = "Tên đăng nhập đã tồn tại" });
                }
                if (pass != repass)
                {
                    return RedirectToAction("/AdminLoginView", new { tb1 = "Thông tin không chính xác" });
                }
                else
                {
                    con.NguoiBans.Add(nv);
                    con.SaveChanges();
                    con.TaiKhoans.Add(taikhoan);
                    con.SaveChanges();
                    return RedirectToAction("/AdminLoginView", new { tb2 = "Đăng ký thành công" });
                }

            }
           
        }
    }
}