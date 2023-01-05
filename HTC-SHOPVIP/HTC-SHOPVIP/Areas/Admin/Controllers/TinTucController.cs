using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTC_SHOPVIP.Models;
namespace HTC_SHOPVIP.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        // GET: Admin/TinTuc
       
    




      
        public ActionResult AnhSlide()
        {
            return View();
        }

        public ActionResult AnhSanPham()
        {
            return View();
        }

        public ActionResult ThemAnhSanPham(string maanh, int masp)
        {
            {
                using (var con = new Model1())
                {
                    var anhspnew = new SP_anh();
                    anhspnew.MaSP = masp;
                    anhspnew.Linkanh = maanh;

                    con.SP_anh.Add(anhspnew);
                    con.SaveChanges();
                    return Redirect("/Admin/TinTuc/AnhSanPham");
                }
              
            }
        }
        [HttpPost]
        public ActionResult ThemAnhSlide(HttpPostedFileBase link) {





            if (link != null && link.ContentLength > 0)
            {
                string rootFile = Server.MapPath("/Content/img/slide/");
                string pathImage = rootFile + link.FileName;
                link.SaveAs(pathImage);
            }

            using (var con=new Model1())
            {
                var slidenew = new Slide_anh();
                slidenew.Linkanh = link.FileName;
                con.Slide_anh.Add(slidenew);
                con.SaveChanges();
                return Redirect("/Admin/TinTuc/AnhSlide");
            }
           
        }





        public ActionResult XoaAnhSlide(int id)
        {
            using(var con=new Model1())
            {
                var db = con.Slide_anh.Find(id);
                con.Slide_anh.Remove(db);
                con.SaveChanges();
                return Redirect("/Admin/TinTuc/AnhSlide");
            }
        }


     
        public ActionResult XoaAnhSanPham(int masp, string linkanh)
        {
            using(var con=new Model1())
            {
                var db=(from s in con.SP_anh
                        where s.MaSP==masp && s.Linkanh==linkanh
                        select s).FirstOrDefault();
                con.SP_anh.Remove(db);
                con.SaveChanges();
                return Redirect("/Admin/TinTuc/AnhSanPham");
            }
        }
      
    }
}