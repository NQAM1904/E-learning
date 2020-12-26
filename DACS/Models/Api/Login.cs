using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class Login
    {
        public int IDUSER { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public int IDROLE { get; set; }
        public string EMAIL { get; set; }
        public string TOKEN { get; set; }
        public int IDSTUDENT { get; set; }
        public Nullable<int> MSSV { get; set; }
        public int IDNGANH { get; set; }
        public int IDNIENKHOA { get; set; }

    }
}