using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Cropper.ViewModels
{
    public class VideoViewModel
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public Dictionary<string, string> Main { get; set; }
        public string Synopsis { get; set; }
        public List<WxNetInfo.Json.EverySection> Section { get; set; }
    }
}