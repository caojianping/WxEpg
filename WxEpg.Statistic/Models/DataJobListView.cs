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
            //�������
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
            //��ȡͳ������
            Dictionary<string, Dictionary<int, Dictionary<int, int>>> dics = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();
            foreach (var jitem in jitems)
            {
                var channelName = jitem.ChannelName;
                if (string.IsNullOrEmpty(channelName)) continue;
                if (!dics.ContainsKey(channelName))
                {
                    //        Dictionary<int, Dictionary<int, int>>
                    //                    |               |
                    //��1���ࡢ2ͼƬ��3������Ϣ�� ��1δ��ˣ�2��˳ɹ���3���ʧ�ܣ�
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
        public int Id { get; set; }//��Ŀ�����
        public string EventName { get; set; }//��Ŀ������
        public string Content { get; set; }//��Ŀ���ƣ����˹���
        public string MainType { get; set; }//������
        public string Category { get; set; }//�ӷ���
        public DateTime PlayTime { get; set; }//����ʱ��
        public int Duration { get; set; }//ʱ��
        public int ChannelId { get; set; }//Ƶ�����
        public string ChannelName { get; set; }//Ƶ������
        public string ChannelGroup { get; set; }//Ƶ������        
        public int VideoId { get; set; }//Ӱ�Ӿ���
        public string Imgs { get; set; }//ͼƬ
        public Dictionary<int, int> AuditStatus { get; set; }//���״̬
    }
}
