using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DACS.Models
{
    public class Extension
    {
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}