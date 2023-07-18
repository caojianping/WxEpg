using System;
using System.Collections.Generic;
using System.Linq;

namespace WxEpg.Statistic.Models
{
    partial class DataTaskStatusDataContext
    {
        public Dictionary<int, int> GetAuditStatusByVideoId(int videoId)
        {
            if (videoId == -1) return null;
            var items = this.TaskStatus.Where(o => o.VideoId == videoId);
            if (items.Count<TaskStatus>() <= 0) return null;
            Dictionary<int, int> olds = new Dictionary<int, int>();
            foreach (var item in items)
            {
                if (!olds.ContainsKey(item.TaskType))
                {
                    olds.Add(item.TaskType, (int)item.Step);
                }
            }
            var news = (from item in olds orderby item.Key select item).ToDictionary(o => o.Key, o => o.Value);
            return news;
        }

        public Dictionary<int, Dictionary<int, int>> GetTaskStat()
        {
            Dictionary<int, Dictionary<int, int>> dics = new Dictionary<int, Dictionary<int, int>>() {
                {1,new Dictionary<int,int>(){{1,0},{2,0},{3,0}}},
                {2,new Dictionary<int,int>(){{1,0},{2,0},{3,0}}},
                {3,new Dictionary<int,int>(){{1,0},{2,0},{3,0}}}
            };
            List<TaskStatus> items = this.TaskStatus.ToList();
            foreach (var item in items)
            {
                int key = item.TaskType;
                int skey = item.Step ?? 0;
                dics[key][skey] += 1;
            }
            return dics;
        }

    }
}
