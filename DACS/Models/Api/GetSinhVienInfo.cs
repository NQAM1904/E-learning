using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class GetSinhVienInfo
    {
        public int IDUSER { get; set; }
        public int IDSTUDENT { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> MSSV { get; set; }
        public string NAMENGANH { get; set; }
        public string NAMENIENKHOA { get; set; }
    }
}