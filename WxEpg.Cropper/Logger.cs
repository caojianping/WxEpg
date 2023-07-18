using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WxEpg.Cropper
{
    public static class Logger
    {
        public static void Append(string path, string text)
        {
            File.AppendAllText(path, string.Format("time({0})：{1}\r\n", DateTime.Now.ToString("MM/dd hh:mm:ss"), text));
        }
    }
}