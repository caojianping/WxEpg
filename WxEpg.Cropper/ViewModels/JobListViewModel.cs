using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Cropper.ViewModels
{
    public class JobListViewModel
    {
        public List<string> Groups { get; set; }
        public QueryParameters Parameters { get; set; }
        public List<Models.JobItem> Data { get; set; }
    }

    public class QueryParameters
    {
        public string EventName { get; set; }
        public string ChannelName { get; set; }
        public string ChannelGroup { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MainType { get; set; }
        public string TaskType { get; set; }
    }

}