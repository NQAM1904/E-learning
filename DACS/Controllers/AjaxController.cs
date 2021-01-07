using DACS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DACS.Helper;
using System.Net.Mail;
using System.Net;

namespace DACS.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        [HttpGet]
        public JsonResult GetDanhMuc(int id)
        {
            //if (Session["AdminLogin"] is null) return null;

            using (DATHINHEntities db = new DATHINHEntities())
            {
                
                var danhmuc = db.DANHMUCSKs.Where(x => x.IDDANHMUC == id).FirstOrDefault();
                if (danhmuc is null) return null;
                return new JsonResult()
                {
                    Data = new { TIEUDE = danhmuc.TENDANHMUC  },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpPost]
        public JsonResult EditDanhMuc(DANHMUCSK danhmuc)
        {
            //if (Session["AdminLogin"] is null) return null;
            ApiResult result = new ApiResult();
            if (danhmuc is null)
            {
                result.Message = "Vui lòng điền đủ thông tin";
                return Json(result.Data);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                DANHMUCSK d = new DANHMUCSK();
                if (danhmuc.IDDANHMUC > 0) d = db.DANHMUCSKs.Where(x => x.IDDANHMUC == danhmuc.IDDANHMUC).FirstOrDefault();
                if (d is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                d.IDDANHMUC = danhmuc.IDDANHMUC;
                d.TENDANHMUC = danhmuc.TENDANHMUC;
                if (danhmuc.IDDANHMUC == 0) db.DANHMUCSKs.Add(d);
                try
                {
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }

            return Json(result);
        }
        [HttpPost]
        public JsonResult DeleteDanhMuc(int id)
        {
            ApiResult result = new ApiResult();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var danhmuc = db.DANHMUCSKs.Where(x => x.IDDANHMUC == id).FirstOrDefault();
                if (danhmuc is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                try
                {
                    db.DANHMUCSKs.Remove(danhmuc);
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }
        public JsonResult GetPosition(int id)
        {
            //if (Session["AdminLogin"] is null) return null;

            using (DATHINHEntities db = new DATHINHEntities())
            {
                var role = db.ROLEs.Where(x => x.IDROLE == id).FirstOrDefault();
                if (role is null) return null;
                return new JsonResult()
                {
                    Data = new { NAME = role.NAMEROLE },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpPost]
        public JsonResult EditPosition(ROLE role)
        {
            //if (Session["AdminLogin"] is null) return null;
            ApiResult result = new ApiResult();
            if (role is null)
            {
                result.Message = "Vui lòng điền đủ thông tin";
                return Json(result.Data);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                ROLE r = new ROLE();
                if (role.IDROLE > 0) r = db.ROLEs.Where(x => x.IDROLE == role.IDROLE).FirstOrDefault();
                if (r is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                r.IDROLE = role.IDROLE;
                r.NAMEROLE = role.NAMEROLE;
                if (role.IDROLE == 0) db.ROLEs.Add(r);
                try
                {
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }

            return Json(result);
        }
        [HttpPost]
        public string DeleteRole(int id)
        {
            //if (Session["AdminLogin"] is null) return null;

            using (DATHINHEntities db = new DATHINHEntities())
            {
                var role = db.ROLEs.Where(x => x.IDROLE == id).FirstOrDefault();
                if (role is null) return "Không tìm thấy đối tượng này";
                db.ROLEs.Remove(role);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }
        public JsonResult GetUser(int id)
        {
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var user = db.USERs.Where(x => x.IDUSER == id).FirstOrDefault();
                if (user is null) return null;
                return new JsonResult()
                {
                    Data = new { FULLNAME = user.FULLNAME, EMAIL = user.EMAIL, PHONE = user.PHONE, USERNAME = user.USERNAME, ROLE = user.IDROLE },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpPost]
        public JsonResult PostChangePassword(string oldPass, string newPass)
        {
            ApiResult result = new ApiResult();
            if (String.IsNullOrEmpty(oldPass) || String.IsNullOrEmpty(newPass))
            {
                result.Message = "Vui lòng điền đầy đủ thông tin bên trên";
                return Json(result.Data);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var user = (USER)Session["Login"];
                var userDB = db.USERs.Where(x => x.IDUSER == user.IDUSER).FirstOrDefault();
                if (userDB is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }

                userDB.PASSWORD = newPass;

                try
                {
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult PostUser(USER user, string finalString)
        {
            //SendMail.EmailUser = "hotrohoctap.thinh@gmail.com";
            //SendMail.EmailPassword = "Thinh1998";
            //SendMail.EmailName = "Cấp thông tin tài khoản cho nhân viên";

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            finalString = new String(stringChars);


            ApiResult result = new ApiResult();
            if (user is null)
            {
                result.Message = "Vui lòng điền đầy đủ thông tin bên trên";
                return Json(result.Data);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                USER u = new USER();
                if (user.IDUSER > 0) u = db.USERs.Where(x => x.IDUSER == user.IDUSER).FirstOrDefault();
                if (u is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                u.FULLNAME = user.FULLNAME;
                u.USERNAME = user.USERNAME;
                u.PHONE = user.PHONE;
                u.EMAIL = user.EMAIL;
                u.IDROLE = user.IDROLE;
                u.PASSWORD = finalString;
                u.IDPERMISSION = 1;
                if (user.IDUSER == 0) db.USERs.Add(u);
                try
                {
                    db.SaveChanges();
                     
                    string body = @" <div style='width:600px;border: 1px solid black;'>
                                                <div style='background-color:rgb(13, 213, 240);padding: 10px;'>
                                                    <center><h2 style='margin:auto;'>THÔNG TIN TÀI KHOẢN CỦA BẠN</h2></center>
                                                </div>
                                                <div style='padding: 20px;'>
                                                    <p>Thông tin tài khoản: {0}</p>
                                                    <p>Mật khẩu của bạn là: <b>{1}</b></p>
                                                    <p>Vui lòng đăng nhập và đổi mật khẩu mới</p>
                                                </div>
                                            </div>";

                    body = String.Format(body, u.USERNAME, finalString);
                    
                    MailMessage mail = new MailMessage();
                    MailAddress fromAddress = new MailAddress(u.EMAIL);
                    MailAddress toAddress = null;
                    mail.From = fromAddress;
                    toAddress = new MailAddress(u.EMAIL, "Cấp thông tin tài khoản cho nhân viên");
                    mail.Subject = "Chúc Mừng Bạn Đã Tạo Tài Khoản Thành Công";
                    
                    mail.Body = body;
                    mail.To.Add(toAddress);
                    mail.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential("hotrohoctap.thinh@gmail.com", "Thinh1998");
                    smtpClient.Send(mail);
                     
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }

            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            ApiResult result = new ApiResult();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var user = db.USERs.Where(x => x.IDUSER == id).FirstOrDefault();
                if (user is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                try
                {
                    db.USERs.Remove(user);
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }
        public JsonResult GetNganh(int id)
        {
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var nganh = db.NGANHs.Where(x => x.IDNGANH == id).FirstOrDefault();
                var nienkhoa = db.NIENKHOAs.Where(x => x.IDNIENKHOA == nganh.IDNIENKHOA).FirstOrDefault();
                if (nganh is null) return null;
                return new JsonResult()
                {
                    Data = new { NAMENGANH = nganh.NAMENGANH, NAMENIENKHOA = nienkhoa.NAMENIENKHOA },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpPost]
        public JsonResult PostNganh(NGANH nganh)
        {
            ApiResult result = new ApiResult();
            if (nganh is null)
            {
                result.Message = "Vui lòng điền đủ thông tin";
                return Json(result.Data);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                NGANH n = new NGANH();
                if (nganh.IDNGANH > 0) n = db.NGANHs.Where(x => x.IDNGANH == nganh.IDNGANH).FirstOrDefault();
                if (n is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                n.IDNGANH = nganh.IDNGANH;
                n.NAMENGANH = nganh.NAMENGANH;
                n.IDNIENKHOA = nganh.IDNIENKHOA;


                if (nganh.IDNGANH == 0) db.NGANHs.Add(n);
                try
                {
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult DeleteNganh(int id)
        {
            ApiResult result = new ApiResult();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var nganh = db.NGANHs.Where(x => x.IDNGANH == id).FirstOrDefault();
                if (nganh is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                try
                {
                    db.NGANHs.Remove(nganh);
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult PostNienKhoa(NIENKHOA nienkhoa)
        {
            ApiResult result = new ApiResult();
            if (nienkhoa is null)
            {
                result.Message = "Vui lòng điền đủ thông tin";
                return Json(result.Data);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                NIENKHOA n = new NIENKHOA();
                if (nienkhoa.IDNIENKHOA > 0) n = db.NIENKHOAs.Where(x => x.IDNIENKHOA == nienkhoa.IDNIENKHOA).FirstOrDefault();
                if (n is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                n.IDNIENKHOA = nienkhoa.IDNIENKHOA;
                n.NAMENIENKHOA = nienkhoa.NAMENIENKHOA;

                if (nienkhoa.IDNIENKHOA == 0) db.NIENKHOAs.Add(n);
                try
                {
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }

        public JsonResult PostMonHoc(MONHOC monhoc)
        {
            ApiResult result = new ApiResult();
            if (monhoc is null)
            {
                result.Message = "Vui lòng điền đủ thông tin";
                return Json(result.Data);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                MONHOC n = new MONHOC();
                if (monhoc.IDMONHOC > 0) n = db.MONHOCs.Where(x => x.IDMONHOC == monhoc.IDMONHOC).FirstOrDefault();
                if (n is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                n.IDMONHOC = monhoc.IDMONHOC;
                n.TENMONHOC = monhoc.TENMONHOC;
                n.TINCHI = monhoc.TINCHI;
                n.IDHOCKY = monhoc.IDHOCKY;
                n.IDMONTIENQUYET = monhoc.IDMONTIENQUYET;
                 
                if (monhoc.IDMONTIENQUYET != null)
                {
                    n.IDMONTIENQUYET = monhoc.IDMONTIENQUYET;
                }
                else
                {
                    n.IDMONTIENQUYET = 0;
                }

                if (monhoc.IDMONHOC == 0) db.MONHOCs.Add(n);
                try
                {
                    db.SaveChanges();
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }

        //[HttpPost]
        //public JsonResult PostHocKy(HOCKY hk)
        //{
        //    ApiResult result = new ApiResult();
        //    if (hk is null)
        //    {
        //        result.Message = "Vui lòng điền đủ thông tin";
        //        return Json(result.Data);
        //    }
        //    using (DATHINHEntities db = new DATHINHEntities())
        //    {
        //        HOCKY hocky = new HOCKY();
        //        if (hk.IDHOCKY > 0) hocky = db.HOCKies.Where(x => x.IDHOCKY == hk.IDHOCKY).FirstOrDefault();
        //        if (hocky is null)
        //        {
        //            result.Message = "Vui lòng thử lại";
        //            return Json(result);
        //        }
        //        hocky.IDHOCKY = hk.IDHOCKY;
        //        hocky.TENHOCKY = hk.TENHOCKY;
               


        //        if (hk.IDHOCKY == 0) db.HOCKies.Add(hocky);
        //        try
        //        {
        //            db.SaveChanges();
        //            result.Success = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            result.Message = ex.Message;
        //        }
        //    }
        //    return Json(result);
        //}
        
       

    }
}