using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class TKBModel
    {
        public int IDTKB { get; set; }
        public DateTime THOIGIANBATDAU { get; set; }
        public DateTime THOIGIANKETTHUC { get; set; }

        public string TENMONHOC { get; set; }
        public string PHONGHOC { get; set; }    

        public int SOTIETHOC { get; set; }
        public LichHocModel LICHOC { get; set; }


    }
}