using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class GetMonHoc
    {
        public int IDMONHOC { get; set; }
        public string TENMONHOC { get; set; }
        public int TINCHI { get; set; }
        public int IDHOCKY { get; set; }
        public DateTime THOIGIANBATDAU { get; set; }
        public DateTime THOIGIANKETTHUC { get; set; }
        public string TENCS { get; set; }
        public string PHONGHOC { get; set; }
        public LichHocModel LICHOC { get; set; }
        public int SOTIETHOC { get; set; }
    }
}