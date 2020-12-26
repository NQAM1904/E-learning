using System;
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
        public int TINCHI { get; set; }
        public int IDHOCKY { get; set; }
    }
}