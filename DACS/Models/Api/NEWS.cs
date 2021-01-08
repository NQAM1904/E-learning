using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class NEWS
    {
        public int IDEVENT { get; set; }
       
        public string TENEVENT { get; set; }
        public DateTime THOIGIANEV { get; set; }

        public int IDUSER { get; set; }
        public string FULLNAME { get; set; }
        public string MOTA { get; set; }
        public string TENDANHMUC { get; set; }
    }
}