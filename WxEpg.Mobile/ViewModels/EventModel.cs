using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Mobile.ViewModels
{
    public class EventModel
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public DateTime PlayDate { get; set; }
        public List<DateTime> ShowDates { get; set; }
        public List<Models.MobileEvent> Data { get; set; }
        public string Sign { get; set; }
    }
}