using DACS.Models;
using DACS.Models.Api;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;


namespace DACS.Controllers
{
    public class ApiMobileController : ApiController
    {
        private string ApiLogin(string Username, string Password)
        {
            string url = Extension.GetAppSetting("API");
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", "thinh");
            request.AddParameter("password", "123");
            request.AddParameter("grant_type", "password");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return response.Content;
            return null;
        }
        [HttpGet]
        public string TestApi()
        {
            return "ok";
        }
        [HttpPost]
        public JsonResult<ApiMobile> Login(USER login)
        {
            ApiMobile result = new ApiMobile();

            try
            {

                if (String.IsNullOrEmpty(login.USERNAME) || String.IsNullOrEmpty(login.PASSWORD)) throw new Exception("Vui lòng nhập đầy đủ thông tin đăng nhập");

                using (DATHINHEntities db = new DATHINHEntities())
                {
                    login.PASSWORD = db.proc_CryptData(login.PASSWORD).FirstOrDefault();


                    if (db.USERs.Any(x => x.USERNAME.Equals(login.USERNAME)) == false)
                    {
                        result.Message = "Tài khoản không tồn tại!";
                        return Json(result);

                    }
                    else
                    {
                        if (!db.USERs.Any(x => x.USERNAME.Equals(login.USERNAME) && x.PASSWORD.Equals(login.PASSWORD)))
                        {
                            result.Message = "Tài khoản hoặc mật khẩu không chính xác, vui lòng kiểm tra lại";
                            return Json(result);
                        }
                        else
                        {
                            string Token = ApiLogin(login.USERNAME, login.PASSWORD);
                            if (!string.IsNullOrEmpty(Token))
                            {
                                JObject json = JObject.Parse(Token);
                                Login data = new Login();
                                var kq = db.USERs.Where(x => x.USERNAME.Equals(login.USERNAME.ToLower().Trim()) && x.PASSWORD.Equals(login.PASSWORD)).FirstOrDefault();
                                var student = db.STUDENTs.Where(x => x.IDUSER == kq.IDUSER).FirstOrDefault();
                                var nganh = db.NGANHs.Where(x => x.IDNGANH == student.IDNGANH).FirstOrDefault();
                                var nienkhoa = db.NIENKHOAs.Where(x => x.IDNIENKHOA == nganh.IDNIENKHOA).FirstOrDefault();
                                var idRole = kq.ROLE.NAMEROLE;
                                if (student == null && !idRole.Equals("Sinh viên"))
                                {
                                    result.Message = "Tài khoản sinh viên chưa được đăng ký";
                                    return Json(result);
                                }
                                if (kq.IDROLE != 3)
                                {
                                    result.Success = false;
                                    result.Message = "Tài khoản không có quyền sử dụng tính năng này";
                                    return Json(result);
                                }
                                data.IDUSER = kq.IDUSER;
                                data.USERNAME = kq.USERNAME;
                                data.FULLNAME = kq.FULLNAME;
                                data.PHONE = kq.PHONE;
                                data.EMAIL = kq.EMAIL;
                                data.ADDRESS = kq.ADDRESS;
                                data.IDROLE = kq.IDROLE;
                                data.TOKEN = json["access_token"].ToString();
                                data.IDSTUDENT = student.IDSTUDENT;
                                data.IDNGANH = student.IDNGANH;
                                data.IDNIENKHOA = nienkhoa.IDNIENKHOA;
                                data.MSSV = student.MSSV;


                                result.Data = data;
                                result.Success = true;
                                result.Message = "Đăng nhập thành công!";
                            }
                            else
                            {
                                //Login Failed/....
                            }
                        }

                    }
                    return Json(result);

                }

            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }
            return Json(result);
        }

        [HttpPost]
        public JsonResult<ApiMobile> SignUp(Register user)
        {

            ApiMobile result = new ApiMobile();
            if (user is null)
            {
                result.Message = "Vui lòng điền đầy đủ thông tin bên trên";
                return Json(result);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {
                USER u = new USER();

                if (u is null)
                {
                    result.Message = "Vui lòng thử lại";
                    return Json(result);
                }
                u.FULLNAME = user.FULLNAME;
                u.USERNAME = user.USERNAME;
                u.PHONE = user.PHONE;
                u.EMAIL = user.EMAIL;
                u.ADDRESS = user.ADDRESS;
                u.IDROLE = 3;
                u.IDPERMISSION = 4;
                u.PASSWORD = user.PASSWORD;
                if (user.IDUSER == 0)
                {
                    db.USERs.Add(u);
                }
                try
                {
                    db.SaveChanges();
                    int Count = db.USERs.Max(p => p.IDUSER);
                    if (Count > 0)
                    {
                        

                        STUDENT std = new STUDENT();
                        std.IDUSER = Count;
                        std.IDNGANH = user.IDNGANH;
                        std.MSSV = user.MSSV;
                        db.STUDENTs.Add(std);
                        db.SaveChanges();
                    }
                    result.Success = true;
                    result.Message = "Đăng ký thành công!";
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                }
            }
            return Json(result);
        }

        [HttpGet]
        public JsonResult<ApiMobileArray> GetNK()
        {
            ApiMobileArray result = new ApiMobileArray();
            List<NienKhoa> DataArr = new List<NienKhoa>();
            using (DATHINHEntities db = new DATHINHEntities())
            {

                var lstNK = db.NIENKHOAs.ToList();
                foreach (var nk in lstNK)
                {
                    NienKhoa nkNew = new NienKhoa();
                    List<Nganh> NganhArr = new List<Nganh>();
                    nkNew.IDNIENKHOA = nk.IDNIENKHOA;
                    nkNew.NAMENIENKHOA = nk.NAMENIENKHOA;
                    var nganhList = db.NGANHs.Where(x => x.IDNIENKHOA == nk.IDNIENKHOA).ToList();

                    foreach (var nganh in nganhList)
                    {
                        Nganh nganhNew = new Nganh();
                        nganhNew.IDNGANH = nganh.IDNGANH;
                        nganhNew.NAMENGANH = nganh.NAMENGANH;
                        NganhArr.Add(nganhNew);
                    }
                    nkNew.LISTNGANH = NganhArr;
                    DataArr.Add(nkNew);
                }
            }
            result.Data = DataArr;
            result.Success = true;
            result.Message = "Lấy niên khóa thành công!";
            return Json(result);
        }

        [HttpPost]
        public JsonResult<ApiMobileArray> GetNamHoc(int nKhoa)
        {
            ApiMobileArray result = new ApiMobileArray();
            List<NamHoc> NamHocArr = new List<NamHoc>();


            using (DATHINHEntities db = new DATHINHEntities())
            {
                string NkhoaID = db.NIENKHOAs.Where(x => x.IDNIENKHOA == nKhoa).FirstOrDefault().NAMENIENKHOA;
                string[] arrListStr = NkhoaID.Split('-');

                var namHocList = db.NAMHOCs.ToList();
                foreach (var Nam in namHocList)
                {
                    NamHoc Namnew = new NamHoc();
                    Namnew.IDNAM = Nam.IDNAM;
                    string tNamm = Nam.TENNAM.ToString();
                    string[] arrListStrr = tNamm.Split('-');
                    Namnew.TENNAM = (int)Nam.TENNAM;
                    //if (Int32.Parse(arrListStrr[0]) >= Int32.Parse(arrListStr[0]) && Int32.Parse(arrListStrr[1]) <= Int32.Parse(arrListStr[1]))
                    //{

                    //}
                    NamHocArr.Add(Namnew);

                }
                result.Data = NamHocArr;
            }
            result.Success = true;
            result.Message = "Lấy danh sách năm học thành công!";
            return Json(result);
        }


        [HttpGet]
        public JsonResult<ApiMobile> GetProfile(int nKhoa, int idNganh, int idSTD)
        {
            ApiMobile result = new ApiMobile();
            List<NamHoc> NamHocArr = new List<NamHoc>();


            using (DATHINHEntities db = new DATHINHEntities())
            {
                ObjProfile prf = new ObjProfile();


                prf.NIENKHOANAME = db.NIENKHOAs.Where(x => x.IDNIENKHOA == nKhoa).FirstOrDefault().NAMENIENKHOA;
                prf.NGANHNAME = db.NGANHs.Where(x => x.IDNGANH == idNganh).FirstOrDefault().NAMENGANH;
                prf.MSSV = db.STUDENTs.Where(x => x.IDSTUDENT == idSTD).FirstOrDefault().MSSV.ToString();
                result.Data = prf;
            }
            result.Success = true;
            result.Message = "Lấy Profile thành công!";
            return Json(result);
        }

        [HttpPost]
        public JsonResult<ApiMobileArray> GetMonHoc(GetMonHocApiModal dataPost)
        {

            ApiMobileArray result = new ApiMobileArray();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                string HocKiString;
                switch (dataPost.IDHOCKY)
                {
                    case 1:
                        HocKiString = "Học kỳ 1";
                        break;
                    case 2:
                        HocKiString = "Học kỳ 2";
                        break;
                    case 3:
                        HocKiString = "Học kỳ 3";
                        break;
                    default:
                        result.Success = false;
                        result.Message = "Dữ liệu không tồn tại";
                        return Json(result);
                        break;
                }


                var HKi = db.HOCKies.Where(x => x.IDHOCKY == dataPost.IDHOCKY && x.IDNAM == dataPost.IDNAM && x.TENHOCKY == HocKiString).FirstOrDefault();
                if (HKi is null)
                {
                    List<MonHoc> MonHocArr1 = new List<MonHoc>();
                    result.Success = true;
                    result.Message = "Dữ liệu không tồn tại";
                    result.Data = MonHocArr1;
                    return Json(result);
                }

                var monHocList = db.MONHOCs.Where(x => x.IDHOCKY == HKi.IDHOCKY).ToList();
                List<MonHoc> MonHocArr = new List<MonHoc>();
                foreach (var Mon in monHocList)
                {
                    MonHoc MonNew = new MonHoc();
                    MonNew.IDMONHOC = Mon.IDMONHOC;
                    MonNew.IDMONTIENQUYET = (int)Mon.IDMONTIENQUYET;
                    MonNew.TENMONHOC = Mon.TENMONHOC;
                    MonNew.TINCHI = (int)Mon.TINCHI;
                    MonNew.IDHOCKY = Mon.IDHOCKY;
                    //if(MonNew.IDMONTIENQUYET == MonNew.IDMONHOC)
                    //{

                    //}
                    MonHocArr.Add(MonNew);
                }
                result.Data = MonHocArr;
            }
            result.Success = true;
            result.Message = "Lấy môn học thành công!";
            return Json(result);
        }
        [HttpPost]
        public JsonResult<ApiMobileArray> GetInfoSinhVien(int IDSINHVIEN)
        {
            ApiMobileArray result = new ApiMobileArray();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var lstSinhvien = db.STUDENTs.Where(x => x.IDSTUDENT == IDSINHVIEN).FirstOrDefault();
                var user = db.USERs.Where(x => x.IDUSER == lstSinhvien.IDUSER).FirstOrDefault();
                if (IDSINHVIEN == 0)
                {
                    result.Message = " Dữ liệu không tồn tại!";
                    return Json(result);
                }
                GetSinhVienInfo sv = new GetSinhVienInfo();
                sv.IDSTUDENT = lstSinhvien.IDSTUDENT;
                sv.MSSV = lstSinhvien.MSSV;
                sv.NAMENGANH = lstSinhvien.NGANH.NAMENGANH;
                //sv.NAMENIENKHOA = lstSinhvien.NIENKHOA.NAMENIENKHOA;
                sv.PHONE = user.PHONE;
                sv.EMAIL = user.EMAIL;
                sv.FULLNAME = user.FULLNAME;
                sv.ADDRESS = user.ADDRESS;
                result.Success = true;
                result.Message = "Lấy thông tin sinh viên thành công!";
                return Json(result);
            }

        }
    }
}
