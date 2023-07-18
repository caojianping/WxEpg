using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Statistic.ViewModels
{
    public class TaskLogViewModel
    {
        public TaskLogQueryParameters Parameters { get; set; }
        public List<Models.TaskLog> Data { get; set; }
    }

    public class TaskLogQueryParameters
    {
        public string UserName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int LogType { get; set; }
    }
}