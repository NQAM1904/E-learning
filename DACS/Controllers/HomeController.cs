using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(USER user)
        {
          using(DATHINHEntities  db = new DATHINHEntities ())
            {
                if (db is null) return HttpNotFound();
                if (String.IsNullOrEmpty(user.USERNAME) || String.IsNullOrEmpty(user.PASSWORD))
                {
                    ViewBag.Error = "Vui lòng điền thông tin";
                    return View("Login");
                }
                user.PASSWORD = db.proc_CryptData(user.PASSWORD).FirstOrDefault();
                var adlogin = db.USERs.Where(x => x.USERNAME.Equals(user.USERNAME.ToLower().Trim()) && x.PASSWORD.Equals(user.PASSWORD)).FirstOrDefault();
                if (adlogin is null)
                {
                    ViewBag.Error = "Sai thông tin đăng nhập";
                    return View("Login");
                }
                Session["Login"] = adlogin;
                int idRole = ((USER)Session["Login"]).IDROLE;
                if (idRole != 1 && idRole != 2)
                {
                    ViewBag.Error2 = "Không đủ quyền truy cập !!!";
                    return View("Index");
                }
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult Role()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
        public ActionResult User()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
       public ActionResult Nganh()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
        public ActionResult HocKy()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
        public ActionResult MonHoc()
        {
            if (Session["Login"] is null) return View("Login");
            return View();

        }
        public ActionResult TinChi()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
        public ActionResult NienKhoa()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
      public ActionResult TinTuc()
        {
            if (Session["Loin"] is null) return View("Login");
            return View();
        }
        public ActionResult DMSuKien()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
        public ActionResult SuKien()
        {
            if (Session["Login"] is null) return View("Login");
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}