using DACS.Models;
using DACS.Models.Api;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public JsonResult<ApiMobileArray> UpdateDiem(UpdateDiem dataPost)
        {
            ApiMobileArray result = new ApiMobileArray();
            if (dataPost is null)
            {
                result.Message = "Vui lòng điền đủ thông tin";
                return Json(result);
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {

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
                    Namnew.TENNAM = Convert.ToDateTime(Nam.TENNAM).Year;
                    NamHocArr.Add(Namnew);
                    //if (Int32.Parse(arrListStrr[0]) >= Int32.Parse(arrListStr[0]) && Int32.Parse(arrListStrr[1]) <= Int32.Parse(arrListStr[1]))
                    //{
                    //}


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


                var HKi = db.HOCKies.Where(x => x.IDNAM == dataPost.IDNAM && x.TENHOCKY == HocKiString).FirstOrDefault();
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
                    if ((int)Mon.IDMONTIENQUYET > 0)
                    {
                        var tenMonTQ = db.MONHOCs.Where(x => x.IDMONHOC == Mon.IDMONTIENQUYET).FirstOrDefault().TENMONHOC;
                        MonNew.TENMONTIENQUYET = tenMonTQ;
                    }

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

        [HttpGet]
        public JsonResult<ApiMobileArray> GetTKB(int IDSINHVIEN)
        {
            ApiMobileArray result = new ApiMobileArray();
            using (DATHINHEntities db = new DATHINHEntities())
            {

                var ListTKB = db.TKBs.Where(x => x.IDSTUDENT == IDSINHVIEN).ToList();
                if (ListTKB is null)
                {

                    result.Success = false;
                    result.Message = "Thời khóa biểu không tồn tại!";
                    return Json(result);
                }
                else
                {
                    List<TKBModel> TKBArr = new List<TKBModel>();
                    foreach (var TKB in ListTKB)
                    {
                        TKBModel TKBObj = new TKBModel();
                        TKBObj.IDTKB = TKB.IDTKB;
                        TKBObj.THOIGIANBATDAU = Convert.ToDateTime(TKB.THOIGIANBATDAU).Date;
                        TKBObj.THOIGIANKETTHUC = Convert.ToDateTime(TKB.THOIGIANKETTHUC).Date;
                        TKBObj.TENMONHOC = db.MONHOCs.Where(x => x.IDMONHOC == TKB.IDMONHOC).FirstOrDefault().TENMONHOC;
                        var CSo = db.COSOes.Where(x => x.IDCOSO == TKB.IDCOSO).FirstOrDefault();
                        TKBObj.PHONGHOC = CSo.TENCS + "-" + CSo.PHONGHOC;
                        TKBObj.SOTIETHOC = (int)db.TIETHOCs.Where(x => x.IDTIETHOC == TKB.IDTIETHOC).FirstOrDefault().SOTIETHOC;
                        LichHocModel LHoc = new LichHocModel();
                        var LHocDB = db.LICHHOCTUANs.Where(x => x.IDLICHHOC == TKB.IDLICHHOC).FirstOrDefault();
                        LHoc.IDLICHOC = LHocDB.IDLICHHOC;
                        LHoc.SOBUOIHOC = LHocDB.SOBUOIHOC;
                        LHoc.BUOIHOC1 = db.BUOIHOCs.Where(x => x.IDBUOIHOC == LHocDB.IDBUOIHOC1).FirstOrDefault().DAY;
                        LHoc.CAHOC1 = db.CAHOCs.Where(x => x.IDCAHOC == LHocDB.IDCAHOC1).FirstOrDefault().SOCA;

                        if (LHocDB.IDBUOIHOC2 is null)
                        {

                        }
                        else
                        {
                            LHoc.BUOIHOC2 = db.BUOIHOCs.Where(x => x.IDBUOIHOC == LHocDB.IDBUOIHOC2).FirstOrDefault().DAY;
                            LHoc.CAHOC2 = db.CAHOCs.Where(x => x.IDCAHOC == LHocDB.IDCAHOC2).FirstOrDefault().SOCA;
                        }

                        if (LHocDB.IDBUOIHOC3 is null)
                        {

                        }
                        else
                        {
                            LHoc.BUOIHOC3 = db.BUOIHOCs.Where(x => x.IDBUOIHOC == LHocDB.IDBUOIHOC3).FirstOrDefault().DAY;
                            LHoc.CAHOC3 = db.CAHOCs.Where(x => x.IDCAHOC == LHocDB.IDCAHOC3).FirstOrDefault().SOCA;
                        }

                        TKBObj.LICHOC = LHoc;
                        TKBArr.Add(TKBObj);
                    }

                    result.Success = true;
                    result.Message = "Lấy thông thời khóa biểu thành công!";
                    result.Data = TKBArr;
                    return Json(result);
                }

            }

        }


        [HttpPost]
        public JsonResult<ApiMobileArray> InsertTKBSV(InsertTKBModel dataPost)
        {
            ApiMobileArray result = new ApiMobileArray();

            using (DATHINHEntities db = new DATHINHEntities())
            {


                var idMonTQ = db.MONHOCs.Where(x => x.IDMONHOC == dataPost.IDMONHOC).FirstOrDefault().IDMONTIENQUYET;
                if (idMonTQ != 0)
                {
                    var DiemTQ = db.DIEMs.Where(x => x.IDMONHOC == idMonTQ && x.IDSTUDENT == dataPost.IDSTUDENT).FirstOrDefault();
                    if (DiemTQ is null || DiemTQ.DIEMTB < 5)
                    {
                        result.Success = false;
                        result.Message = "Môn học trước chưa học or chưa đậu";
                        result.Data = null;
                        return Json(result);
                    }
                    else
                    {
                        try
                        {
                            LICHHOCTUAN LHNew = new LICHHOCTUAN();
                            var Count = 1;
                            LHNew.IDBUOIHOC1 = dataPost.LICHHOC.BUOIHOC1;
                            LHNew.IDCAHOC1 = dataPost.LICHHOC.CAHOC1;
                            if (dataPost.LICHHOC.BUOIHOC2 > 0)
                            {
                                LHNew.IDBUOIHOC2 = dataPost.LICHHOC.BUOIHOC2;
                                LHNew.IDCAHOC2 = dataPost.LICHHOC.CAHOC2;
                                Count++;
                            }
                            if (dataPost.LICHHOC.BUOIHOC3 > 0)
                            {
                                LHNew.IDBUOIHOC3 = dataPost.LICHHOC.BUOIHOC3;
                                LHNew.IDCAHOC3 = dataPost.LICHHOC.CAHOC3;
                                Count++;
                            }
                            LHNew.SOBUOIHOC = Count;

                            db.LICHHOCTUANs.Add(LHNew);
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {

                            result.Success = false;
                            result.Message = "Thêm thất bại";
                            result.Data = null;
                            return Json(result);
                        }

                        try
                        {
                            TKB TKBNew = new TKB();
                            TKBNew.IDCOSO = dataPost.IDCOSO;
                            TKBNew.IDSTUDENT = dataPost.IDSTUDENT;
                            TKBNew.IDTIETHOC = dataPost.IDTIETHOC;
                            TKBNew.IDMONHOC = dataPost.IDMONHOC;
                            TKBNew.THOIGIANBATDAU = dataPost.TIMESTART;
                            TKBNew.THOIGIANKETTHUC = dataPost.TIMEEND;
                            TKBNew.IDLICHHOC = db.LICHHOCTUANs.Max(x => x.IDLICHHOC);
                            db.TKBs.Add(TKBNew);
                            db.SaveChanges();
                            result.Success = true;
                            result.Message = "Thêm thành công";
                            result.Data = null;
                            return Json(result);
                        }
                        catch (Exception e)
                        {
                            result.Success = false;
                            result.Message = "Thêm thất bại";
                            result.Data = null;
                            return Json(result);

                        }
                    }
                }
                else
                {
                    try
                    {
                        TKB TKBNew = new TKB();
                        TKBNew.IDCOSO = dataPost.IDCOSO;
                        TKBNew.IDSTUDENT = dataPost.IDSTUDENT;
                        TKBNew.IDTIETHOC = dataPost.IDTIETHOC;
                        TKBNew.IDMONHOC = dataPost.IDMONHOC;
                        TKBNew.THOIGIANBATDAU = dataPost.TIMESTART;
                        TKBNew.THOIGIANKETTHUC = dataPost.TIMEEND;
                        TKBNew.IDLICHHOC = db.LICHHOCTUANs.Max(x => x.IDLICHHOC);
                        db.TKBs.Add(TKBNew);
                        db.SaveChanges();
                        result.Success = true;
                        result.Message = "Thêm thành công";
                        result.Data = null;
                        return Json(result);
                    }
                    catch (Exception e)
                    {
                        result.Success = false;
                        result.Message = "Thêm thất bại";
                        result.Data = null;
                        return Json(result);

                    }
                }






                return Json(result);
            }

        }

        [HttpPost]
        public JsonResult<ApiMobileArray> InsertDiem(UpdateDiem dataPost)
        {
            ApiMobileArray result = new ApiMobileArray();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                DateTime TimeEnd = (DateTime)db.TKBs.Where(x => x.IDSTUDENT == dataPost.IDSTUDENT && x.IDMONHOC == dataPost.IDMONHOC).FirstOrDefault().THOIGIANKETTHUC;
                if (TimeEnd > DateTime.Now)
                {
                    result.Success = false;
                    result.Message = "Thời gian học chưa kết thúc hoặc sinh viên không đăng kí môn này";
                    result.Data = null;

                    return Json(result);
                }
                else
                {
                    try
                    {
                        db.DIEMs.Add(new DIEM { IDSTUDENT = dataPost.IDSTUDENT, DIEMTB = dataPost.DIEMTB, STCDAT = dataPost.STCDAT, TONGDIEM = dataPost.TONGDIEM, IDMONHOC = dataPost.IDMONHOC });
                        db.SaveChanges();
                        result.Success = true;
                        result.Message = "Thêm thành công!!!";
                        result.Data = null;

                        return Json(result);
                    }
                    catch
                    {
                        result.Success = false;
                        result.Message = "Thêm thất bại! Yêu cầu xem lại!!!";
                        result.Data = null;

                        return Json(result);
                    }
                }
            }
            return Json(result);
        }



        [HttpGet]
        public JsonResult<ApiMobileArray> GetDiemByMH(int IDSINHVIEN, int IDMONHOC)
        {
            ApiMobileArray result = new ApiMobileArray();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var lstSinhvien = db.STUDENTs.Where(x => x.IDSTUDENT == IDSINHVIEN).FirstOrDefault();
                var lstMonhoc = db.MONHOCs.Where(x => x.IDMONHOC == IDMONHOC).FirstOrDefault();

                if (IDSINHVIEN == 0)
                {
                    result.Message = "Dữ liệu không tồn tại!";
                    return Json(result);
                }
                var diemNow = db.DIEMs.Where(x => x.IDSTUDENT == IDSINHVIEN).FirstOrDefault();
                GetDiem diem = new GetDiem();
                diem.IDSTUDENT = lstSinhvien.IDSTUDENT;
                diem.IDMONHOC = lstMonhoc.IDMONHOC;
                diem.STCDAT = (int)lstMonhoc.TINCHI;
                diem.DIEMTB = (int)diemNow.DIEMTB;
                diem.TONGDIEM = (int)diemNow.TONGDIEM;


                result.Success = true;
                result.Data = diem;
                result.Message = "Lấy điểm môn học thành công!";
                return Json(result);
            }

        }
        [HttpGet]
        public JsonResult<ApiMobileArray> GetMonHocByDay(int IDSINHVIEN, DateTime Day)
        {
            ApiMobileArray result = new ApiMobileArray();
            var IDDay = -1;
            if ((int)Day.DayOfWeek == 0)
            {
                IDDay = 7;
            }
            else
            {
                IDDay = (int)Day.DayOfWeek;
            }
            using (DATHINHEntities db = new DATHINHEntities())
            {

                //DateTime dt = DateTime.ParseExact(Day, "yyyMMdd", CultureInfo.InvariantCulture);
                var getMH = db.TKBs.Where(x => x.IDSTUDENT == IDSINHVIEN && x.THOIGIANBATDAU <= Day && x.THOIGIANKETTHUC >= Day).ToList();
                if (getMH is null)
                {

                    result.Success = false;
                    result.Message = "Không có môn học!";
                    return Json(result);
                }
                else
                {
                    List<MonHocInDayModel> getMHArr = new List<MonHocInDayModel>();
                    var NumGlobal = 0;
                    foreach (var TKBMonHoc in getMH)
                    {
                        MonHocInDayModel lHocNew = new MonHocInDayModel();
                        lHocNew.IDMONHOC = TKBMonHoc.IDMONHOC;
                        lHocNew.TENMONHOC = db.MONHOCs.Where(x => x.IDMONHOC == TKBMonHoc.IDMONHOC).FirstOrDefault().TENMONHOC;
                        lHocNew.TINCHI = (int)db.MONHOCs.Where(x => x.IDMONHOC == TKBMonHoc.IDMONHOC).FirstOrDefault().TINCHI;
                        lHocNew.HOCKY = db.HOCKies.Where(x => x.IDHOCKY == db.MONHOCs.Where(y => y.IDMONHOC == TKBMonHoc.IDMONHOC).FirstOrDefault().IDHOCKY).FirstOrDefault().TENHOCKY;
                        lHocNew.TENCS = db.COSOes.Where(x => x.IDCOSO == TKBMonHoc.IDCOSO).FirstOrDefault().TENCS;
                        lHocNew.PHONGHOC = db.COSOes.Where(x => x.IDCOSO == TKBMonHoc.IDCOSO).FirstOrDefault().PHONGHOC;
                        lHocNew.SOTIETHOC = (int)db.TIETHOCs.Where(x => x.IDTIETHOC == TKBMonHoc.IDTIETHOC).FirstOrDefault().SOTIETHOC;
                        var LHocDB = db.LICHHOCTUANs.Where(x => x.IDLICHHOC == TKBMonHoc.IDLICHHOC).FirstOrDefault();
                        LichHocModel LHoc = new LichHocModel();
                        LHoc.IDLICHOC = LHocDB.IDLICHHOC;
                        LHoc.SOBUOIHOC = LHocDB.SOBUOIHOC;
                        int num = 0;
                        if (LHocDB.IDBUOIHOC1 == IDDay)
                        {
                            LHoc.BUOIHOC1 = db.BUOIHOCs.Where(x => x.IDBUOIHOC == LHocDB.IDBUOIHOC1).FirstOrDefault().DAY;
                            LHoc.CAHOC1 = db.CAHOCs.Where(x => x.IDCAHOC == LHocDB.IDCAHOC1).FirstOrDefault().SOCA;
                            num++;
                        }
                        if (LHocDB.IDBUOIHOC2 == IDDay)
                        {
                            LHoc.BUOIHOC2 = db.BUOIHOCs.Where(x => x.IDBUOIHOC == LHocDB.IDBUOIHOC2).FirstOrDefault().DAY;
                            LHoc.CAHOC2 = db.CAHOCs.Where(x => x.IDCAHOC == LHocDB.IDCAHOC2).FirstOrDefault().SOCA;
                            num++;
                        }
                        if (LHocDB.IDBUOIHOC3 == IDDay)
                        {
                            LHoc.BUOIHOC3 = db.BUOIHOCs.Where(x => x.IDBUOIHOC == LHocDB.IDBUOIHOC3).FirstOrDefault().DAY;
                            LHoc.CAHOC3 = db.CAHOCs.Where(x => x.IDCAHOC == LHocDB.IDCAHOC3).FirstOrDefault().SOCA;
                            num++;
                        }

                        lHocNew.LICHOC = LHoc;
                        if (num != 0)
                        {
                            getMHArr.Add(lHocNew);
                            NumGlobal++;
                        }

                    }

                    if (NumGlobal == 0)
                    {
                        result.Success = false;
                        result.Message = "Không có môn học trong ngày hôm nay!";
                        return Json(result);
                    }
                    else
                    {
                        result.Success = true;
                        result.Message = "Lấy thông thời khóa biểu ngày " + Day;
                        result.Data = getMHArr;
                        return Json(result);
                    }

                }

            }

        }
        [HttpGet]
        public JsonResult<ApiMobileArray> Diem(int IDSINHVIEN)
        {
            ApiMobileArray result = new ApiMobileArray();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                //var lstDiem = db.DIEMs.ToList();
                var diemNow = db.DIEMs.Where(x => x.IDSTUDENT == IDSINHVIEN).ToList();

                if (diemNow is null)
                {
                    result.Success = false;
                    result.Message = "Không tồn tại sinh viên này";
                    return Json(result);
                }
                else
                {
                    List<DIEM> diemArr = new List<DIEM>();
                    foreach (var diem in diemNow)
                    {
                        DIEM d = new DIEM();
                        d.IDDIEM = diem.IDDIEM;
                        d.IDMONHOC = diem.IDMONHOC;
                        d.IDSTUDENT = diem.IDSTUDENT;
                        d.DIEMTB = diem.DIEMTB;
                        d.STCDAT = diem.STCDAT;
                        d.TONGDIEM = diem.TONGDIEM;
                        diemArr.Add(d);
                    }
                    result.Success = true;
                    result.Message = "Lấy điêm môn học thành công!";
                    result.Data = diemArr;
                    return Json(result);
                }

            }

        }

        [HttpGet]
        public JsonResult<List<NEWS>> News()
        {
            List<NEWS> result = new List<NEWS>();
            using (DATHINHEntities db = new DATHINHEntities())
            {
                var lstnews = db.EVENTS.ToList();

                foreach (var news in lstnews)
                {
                    var danhmuc = db.DANHMUCSKs.Where(x => x.IDDANHMUC == news.DANHMUCSK.IDDANHMUC).FirstOrDefault();
                    NEWS n = new NEWS();
                    n.IDEVENT = news.IDEVENTS;
                    n.TENEVENT = news.TENEVENT;
                    n.MOTA = news.MOTA;
                    n.TENDANHMUC = news.DANHMUCSK.TENDANHMUC;
                    n.THOIGIANEV = (DateTime)news.THOIGIANEV;
                    result.Add(n);
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult<List<NEWS>> GetNews(int id)
        {

            List<NEWS> result = new List<NEWS>();
            using (DATHINHEntities db = new DATHINHEntities())
            {

                var tintuc = db.EVENTS.Where(x => x.IDEVENTS == id).FirstOrDefault();
                var nhanvien = db.USERs.Where(x => x.IDUSER == tintuc.IDUSER).FirstOrDefault();
                var danhmuc = db.DANHMUCSKs.Where(x => x.IDDANHMUC == tintuc.DANHMUCSK.IDDANHMUC).FirstOrDefault();
                NEWS n = new NEWS();
                n.IDEVENT = tintuc.IDEVENTS;
                n.FULLNAME = nhanvien.FULLNAME;
                n.MOTA = tintuc.MOTA;
                n.TENEVENT = tintuc.TENEVENT;
                n.TENDANHMUC = tintuc.DANHMUCSK.TENDANHMUC;
                n.THOIGIANEV = (DateTime)tintuc.THOIGIANEV;
                result.Add(n);
            }
            return Json(result);
        }
        [HttpGet]
        public JsonResult<ApiMobileArray> GetMonHocAllowDK(int IDSINHVIEN)
        {
            ApiMobileArray result = new ApiMobileArray();

            using (DATHINHEntities db = new DATHINHEntities())
            {
                List<MonHoc> MonHocArr = new List<MonHoc>();

                var MonHocDaPass = db.DIEMs.Where(x => x.IDSTUDENT == IDSINHVIEN && x.TONGDIEM >= 4).ToList();
                List<int> SubjectPassedArr = new List<int>();
                foreach (var SubjectPassed in MonHocDaPass)
                {
                    SubjectPassedArr.Add((int)SubjectPassed.IDMONHOC);
                }
                var SubjectList = db.MONHOCs.ToList();
                foreach (var SubjectListt in SubjectList)
                {
                    MonHoc MonNew = new MonHoc();
                    if (SubjectListt.IDMONTIENQUYET == 0)
                    {
                        var NumC = 0;
                        foreach (int SJ in SubjectPassedArr)
                        {
                            if (SJ == (int)SubjectListt.IDMONHOC)
                            {
                                NumC++;
                            }
                        }
                        if (NumC == 0)
                        {
                            MonNew.IDMONHOC = SubjectListt.IDMONHOC;
                            MonNew.IDMONTIENQUYET = (int)SubjectListt.IDMONTIENQUYET;
                            if ((int)SubjectListt.IDMONTIENQUYET > 0)
                            {
                                var tenMonTQ = db.MONHOCs.Where(x => x.IDMONHOC == SubjectListt.IDMONTIENQUYET).FirstOrDefault().TENMONHOC;
                                MonNew.TENMONTIENQUYET = tenMonTQ;
                            }

                            MonNew.TENMONHOC = SubjectListt.TENMONHOC;
                            MonNew.TINCHI = (int)SubjectListt.TINCHI;
                            MonNew.IDHOCKY = SubjectListt.IDHOCKY;
                            MonHocArr.Add(MonNew);
                        }

                    }
                    else
                    {
                        foreach (int SJ in SubjectPassedArr)
                        {
                            if (SJ == (int)SubjectListt.IDMONTIENQUYET)
                            {
                                MonNew.IDMONHOC = SubjectListt.IDMONHOC;
                                MonNew.IDMONTIENQUYET = (int)SubjectListt.IDMONTIENQUYET;
                                if ((int)SubjectListt.IDMONTIENQUYET > 0)
                                {
                                    var tenMonTQ = db.MONHOCs.Where(x => x.IDMONHOC == SubjectListt.IDMONTIENQUYET).FirstOrDefault().TENMONHOC;
                                    MonNew.TENMONTIENQUYET = tenMonTQ;
                                }

                                MonNew.TENMONHOC = SubjectListt.TENMONHOC;
                                MonNew.TINCHI = (int)SubjectListt.TINCHI;
                                MonNew.IDHOCKY = SubjectListt.IDHOCKY;
                                MonHocArr.Add(MonNew);
                            }
                        }
                    }


                }
                result.Success = true;
                result.Message = "Lấy danh sách môn học có thể đăng ký thành công";
                result.Data = MonHocArr;
                return Json(result);
            }

        }
    }
}

//List<MonHoc> MonHocArr = new List<MonHoc>();
//foreach (var Mon in monHocList)
//{
//    MonHoc MonNew = new MonHoc();
//    MonNew.IDMONHOC = Mon.IDMONHOC;
//    MonNew.IDMONTIENQUYET = (int)Mon.IDMONTIENQUYET;
//    if ((int)Mon.IDMONTIENQUYET > 0)
//    {
//        var tenMonTQ = db.MONHOCs.Where(x => x.IDMONHOC == Mon.IDMONTIENQUYET).FirstOrDefault().TENMONHOC;
//        MonNew.TENMONTIENQUYET = tenMonTQ;
//    }

//    MonNew.TENMONHOC = Mon.TENMONHOC;
//    MonNew.TINCHI = (int)Mon.TINCHI;
//    MonNew.IDHOCKY = Mon.IDHOCKY;
//    //if(MonNew.IDMONTIENQUYET == MonNew.IDMONHOC)
//    //{

//    //}
//    MonHocArr.Add(MonNew);
//}