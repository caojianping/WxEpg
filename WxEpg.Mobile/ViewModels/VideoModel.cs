using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Mobile.ViewModels
{
    public class VideoModel
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public Dictionary<string, string> Main { get; set; }
        public string Synopsis { get; set; }
        public List<WxNetInfo.Json.EverySection> Section { get; set; }
        public int CommentCount { get; set; }
        public string Sign { get; set; }
        public Dictionary<string, List<string>> Programs { get; set; }
        public Info Blog { get; set; }
        public Info PostBar { get; set; }
        public int ArticleCount { get; set; }
    }

    public class Info
    {
        public string Url { get; set; }
        public string Attach { get; set; }
    }
}