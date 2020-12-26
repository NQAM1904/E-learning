using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class NienKhoa
    {
        public int IDNIENKHOA { get; set; }
        public string NAMENIENKHOA { get; set; }
        public object LISTNGANH { get; set; }
    }
}