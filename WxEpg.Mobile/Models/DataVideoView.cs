using System;
using System.Linq;
using System.Collections.Generic;

namespace WxEpg.Mobile.Models
{
    partial class DataVideoViewDataContext
    {
        /// <summary>
        /// 根据影视剧编号获取影视剧名称
        /// </summary>
        /// <param name="videoId">影视剧编号</param>
        /// <returns></returns>
        public string GetVideoNameByVideoId(int videoId)
        {
            var item = this.VideoView.FirstOrDefault(m => m.Id == videoId);
            return (item == null) ? string.Empty : item.Name;
        }

        /// <summary>
        /// 根据影视剧编号获取相关的节目单数据
        /// </summary>
        /// <param name="videoId">影视剧编号</param>
        /// <returns></returns>
        public Dictionary<string, List<string>> GetProgramByVideoId(int videoId)
        {
            Dictionary<string, List<string>> dics = new Dictionary<string, List<string>>();
            DataMobileEventDataContext mecontext = new DataMobileEventDataContext();
            var events = mecontext.MobileEvent.Where(o => o.programid != -1 && o.programid == videoId && o.playtime.Date == DateTime.Now.Date).ToList();
            foreach (var item in events)
            {
                DataChannelViewDataContext ccontext = new DataChannelViewDataContext();
                string name = ccontext.GetChannelNameById(item.channelid);
                DateTime playTime = item.playtime;
                string week = "星期" + "日一二三四五六".Substring((int)playTime.DayOfWeek, 1);
                string program = playTime.ToString("MM-dd") + "(" + week + ") " + playTime.ToString("hh:mm") + " " + item.eventname;
                if (dics.Keys.Count >= 2) break;
                if (!dics.ContainsKey(name))
                {
                    dics.Add(name, new List<string> { program });
                }
                else
                {
                    if (dics[name].Count >= 2) break;
                    if (!dics[name].Contains(program))
                    {
                        dics[name].Add(program);
                    }
                }
            }
            return dics;
        }
    }
}
