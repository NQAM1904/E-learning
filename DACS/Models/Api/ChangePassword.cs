using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models.Api
{
    public class ChangePassword
    {
        public int IDUSER { get; set; }
        public string OLDPASSWORD { get; set; }
        public string PASSWORD { get; set; }
    }
}