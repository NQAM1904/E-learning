using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class Diem
    {
        public int IDSTUDENT { get; set; }
        public int IDMONHOC { get; set; }
        public int IDDIEM { get; set; }
        public float DIEMTB { get; set; }
        public float TONGDIEM { get; set; }
        public int STCDAT { get; set; }
    }
}