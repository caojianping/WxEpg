using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WxNetInfo.Json;

namespace WxEpg.Cropper.Models
{
    /// <summary>
    /// 影视剧帮助类
    /// </summary>
    public class VideoHelper : HttpHelper
    {
        static string uri = Properties.Settings.Default.Uri;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public static string GetVideoName(int videoId)
        {
            WxNetInfo.Json.JsonConverter jc = GetVideoJCById(videoId);
            string name = jc.GetMainValue("名称");
            return name;
        }

        /// <summary>
        /// 获取影视剧基本信息
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetVideoMain(int videoId)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            WxNetInfo.Json.JsonConverter jc = GetVideoJCById(videoId);
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
        /// <param name="videoId"></param>
        /// <returns></returns>
        public static string GetVideoSynopsis(int videoId)
        {
            WxNetInfo.Json.JsonConverter jc = GetVideoJCById(videoId);
            string synopsis = jc.GetMainValue("介绍");
            return synopsis;
        }

        /// <summary>
        /// 获取影视剧分集信息
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public static List<EverySection> GetVideoSection(int videoId)
        {
            WxNetInfo.Json.JsonConverter jc = GetVideoJCById(videoId);
            List<EverySection> sections = jc.GetSections();
            sections.Sort((a, b) => int.Parse(a.SectionId) - int.Parse(b.SectionId));
            return sections;
        }

        /// <summary>
        /// 获取影视剧数据
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        private static WxNetInfo.Json.JsonConverter GetVideoJCById(int videoId)
        {
            string url = uri + "Video/GetJsonVideo?videoId=" + videoId;
            string data = GetData(url);
            WxNetInfo.Json.JsonConverter jc = new WxNetInfo.Json.JsonConverter(data);
            return jc;
        }

    }
}