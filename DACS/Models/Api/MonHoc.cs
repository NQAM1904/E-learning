﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class MonHoc
    {
        public int IDMONHOC { get; set; }
        public string TENMONHOC { get; set; }
        public int IDMONTIENQUYET { get; set; }

        public string  TENMONTIENQUYET { get; set; }
        public int TINCHI { get; set; }
        public int IDHOCKY { get; set; }

        public int IDCOSO { get; set; }
        public int IDTIETHOC { get; set; }
    }
}