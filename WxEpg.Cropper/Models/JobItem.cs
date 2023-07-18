using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Cropper.Models
{
    public class JobItem
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Content { get; set; }
        public string MainType { get; set; }
        public string Category { get; set; }
        public DateTime PlayTime { get; set; }
        public int Duration { get; set; }
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelGroup { get; set; }
        public int VideoId { get; set; }
        public string Imgs { get; set; }
        public Dictionary<string, string> AuditStatus { get; set; }
    }
}