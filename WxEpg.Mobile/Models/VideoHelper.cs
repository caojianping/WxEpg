using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WxNetInfo.Json;

namespace WxEpg.Mobile.Models
{
    /// <summary>
    /// 影视剧帮助类
    /// </summary>
    public class VideoHelper : HttpHelper
    {
        static string uri = Properties.Settings.Default.VideoUri;

        /// <summary>
        /// 获取影视剧基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetVideoMain(int id)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            WxNetInfo.Json.JsonConverter jc = GetVideoJCById(id);
            List<string> keys = jc.GetMainAtt();
            foreach (string key in keys)
            {
                string value = jc.GetMainValue(key);
                if (key != "介绍") dics.Add(key, value);
            }
            return dics;
        }

        /// <summary>
        /// 获取影视剧概要信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetVideoSynopsis(int id)
        {
            WxNetInfo.Json.JsonConverter jc = GetVideoJCById(id);
            string synopsis = jc.GetMainValue("介绍");
            return synopsis;
        }

        /// <summary>
        /// 获取影视剧分集信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<EverySection> GetVideoSection(int id)
        {
            WxNetInfo.Json.JsonConverter jc = GetVideoJCById(id);
            List<EverySection> sections = jc.GetSections();
            sections.Sort((a, b) => int.Parse(a.SectionId) - int.Parse(b.SectionId));
            return sections;
        }

        /// <summary>
        /// 获取影视剧数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static WxNetInfo.Json.JsonConverter GetVideoJCById(int id)
        {
            string url = uri + "Video/GetVideoDataById?id=" + id;
            string data = GetData(url);
            WxNetInfo.Json.JsonConverter jc = new WxNetInfo.Json.JsonConverter(data);
            return jc;
        }
    }
}