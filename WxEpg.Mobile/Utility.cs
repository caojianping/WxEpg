using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WxEpg.Mobile
{
    public class Utility
    {
        public static string RootPath { get; set; }

        public static string DataPath
        {
            get
            {
                string dir = RootPath + "/data/";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string ActivityPath
        {
            get
            {
                string dir = RootPath + "/activity/";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string LoggerPath
        {
            get
            {
                string dir = RootPath + "/log/";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                return dir;
            }
        }
    }
}