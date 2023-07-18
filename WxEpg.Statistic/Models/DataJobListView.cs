using System;
using System.Collections.Generic;
using System.Linq;
using MatchLib;

namespace WxEpg.Statistic.Models
{
    partial class DataJobListViewDataContext
    {
        public Dictionary<string, Dictionary<int, Dictionary<int, int>>> GetTaskStat()
        {
            //任务过滤
            List<JobItem> jitems = new List<JobItem>();
            List<JobListView> jobs = this.JobListView.ToList();
            foreach (var item in jobs)
            {
                List<string> words = new SplitWord().Split(item.eventname);
                if (jitems.FirstOrDefault(m => m.Content == words[0]) == null)
                {
                    int videoId = item.programid ?? -1;
                    var auditStatus = new DataTaskStatusDataContext().GetAuditStatusByVideoId(videoId);
                    JobItem jitem = new JobItem()
                    {
                        Id = (int)item.id,
                        EventName = item.eventname,
                        Content = words[0],
                        MainType = item.mainType,
                        Category = item.category,
                        PlayTime = (DateTime)item.playtime,
                        Duration = (int)item.duration,
                        ChannelId = (int)item.channelid,
                        ChannelName = item.channelname,
                        ChannelGroup = item.viagroup,
                        VideoId = item.programid ?? -1,
                        Imgs = item.imgs,
                        AuditStatus = auditStatus
                    };
                    jitems.Add(jitem);
                }
            }
            //获取统计数据
            Dictionary<string, Dictionary<int, Dictionary<int, int>>> dics = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();
            foreach (var jitem in jitems)
            {
                var channelName = jitem.ChannelName;
                if (string.IsNullOrEmpty(channelName)) continue;
                if (!dics.ContainsKey(channelName))
                {
                    //        Dictionary<int, Dictionary<int, int>>
                    //                    |               |
                    //（1分类、2图片、3基本信息） （1未审核，2审核成功，3审核失败）
                    Dictionary<int, Dictionary<int, int>> sdics = new Dictionary<int, Dictionary<int, int>> {
                        {1,new Dictionary<int,int>{{1,0},{2,0},{3,0}}},
                        {2,new Dictionary<int,int>{{1,0},{2,0},{3,0}}},
                        {3,new Dictionary<int,int>{{1,0},{2,0},{3,0}}}
                    };
                    if (jitem.AuditStatus != null)
                    {
                        foreach (var kv in jitem.AuditStatus)
                        {
                            sdics[kv.Key][kv.Value] += 1;
                        }
                    }
                    dics.Add(channelName, sdics);
                }
                else
                {
                    if (jitem.AuditStatus != null)
                    {
                        foreach (var kv in jitem.AuditStatus)
                        {
                            dics[channelName][kv.Key][kv.Value] += 1;
                        }
                    }
                }
            }
            return dics;
        }

    }

    public class JobItem
    {
        public int Id { get; set; }//节目单编号
        public string EventName { get; set; }//节目单名称
        public string Content { get; set; }//栏目名称（过滤规则）
        public string MainType { get; set; }//主分类
        public string Category { get; set; }//子分类
        public DateTime PlayTime { get; set; }//播出时间
        public int Duration { get; set; }//时长
        public int ChannelId { get; set; }//频道编号
        public string ChannelName { get; set; }//频道名称
        public string ChannelGroup { get; set; }//频道分组        
        public int VideoId { get; set; }//影视剧编号
        public string Imgs { get; set; }//图片
        public Dictionary<int, int> AuditStatus { get; set; }//审核状态
    }
}
