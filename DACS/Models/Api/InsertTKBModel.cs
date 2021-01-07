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
        
        public string BUOIHOC1 { get; set; }
        public string CAHOC1 { get; set; }
        public string BUOIHOC2 { get; set; }
        public string CAHOC2 { get; set; }
        public string BUOIHOC3 { get; set; }
        public string CAHOC3 { get; set; }
    }
}