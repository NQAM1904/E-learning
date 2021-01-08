using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class InsertTKBModel
    {
         
        public int IDSTUDENT { get; set; }
        public int  IDMONHOC { get; set; }
        public int  IDCOSO { get; set; }
        public int  IDTIETHOC { get; set; }
        public DateTime TIMESTART { get; set; }
        public DateTime TIMEEND { get; set; }
        public LICHHOCDATA LICHHOC { get; set; }
    }
    public class LICHHOCDATA
    {
        
        public int BUOIHOC1 { get; set; }
        public int CAHOC1 { get; set; }
        public int BUOIHOC2 { get; set; }
        public int CAHOC2 { get; set; }
        public int BUOIHOC3 { get; set; }
        public int CAHOC3 { get; set; }
    }
}