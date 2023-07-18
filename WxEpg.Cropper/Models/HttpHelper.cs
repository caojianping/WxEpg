using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WxEpg.Cropper.Models
{
    public class HttpHelper
    {
        /// <summary>
        /// get数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetData(string url)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            return wc.GetHtml(url);
        }

        /// <summary>
        /// post数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PostData(string url, byte[] data)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            return wc.Post(url, data);
        }
    }
}