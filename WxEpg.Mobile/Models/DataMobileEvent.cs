using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WxEpg.Mobile.Models
{
    partial class DataMobileEventDataContext
    {
        /// <summary>
        /// ����Ƶ����š��������ڻ�ȡ��Ŀ����Ϣ
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="playDate"></param>
        /// <returns></returns>
        public List<MobileEvent> GetEventsByIdAndDate(int channelId, string playDate)
        {
            if (channelId <= 0 || string.IsNullOrEmpty(playDate)) return null;
            var items = this.MobileEvent.Where(s => s.channelid == channelId &&
                s.playtime.Date == DateTime.Parse(playDate));
            return items.OrderBy(o => o.playtime).ToList();
        }

        /// <summary>
        /// ����������ȡ���ڲ����б�
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="playTime"></param>
        /// <param name="category"></param>
        /// <param name="sort"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<sp_getplaysResult> GetPlays(int companyId, string playTime, string category, string cid, int count)
        {
            if (companyId <= 0) return null;
            var items = this.sp_getplays(companyId, playTime, category, cid, count);
            return items.ToList();
        }

        /// <summary>
        /// ��ȡ��Ŀ���б�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<MobileEvent> GetEventsByName(string name)
        {
            var items = this.MobileEvent.Where(m => m.eventname.Contains(name));
            return items.ToList();
        }

        /// <summary>
        /// ����������Ŀ���Ʋ�ѯ��Ŀ�б�
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, int>> QueryEventsByName(string name)
        {
            Dictionary<string, Dictionary<string, int>> dics = new Dictionary<string, Dictionary<string, int>>();
            var items = this.sp_queryevent(name);
            foreach (var item in items)
            {
                if (item.MainType == "����")
                {
                    string rname = Regex.IsMatch(item.Name, @"\(.+\)$") ? Regex.Replace(item.Name, @"\(.+\)$", "") : item.Name;
                    if (!dics.ContainsKey(item.MainType))
                    {
                        dics.Add(item.MainType, new Dictionary<string, int>() { { rname, (int)item.VideoId } });
                    }
                    else
                    {
                        if (!dics[item.MainType].ContainsKey(rname))
                        {
                            dics[item.MainType].Add(rname, (int)item.VideoId);
                        }
                    }
                }
                else
                {
                    if (!dics.ContainsKey(item.MainType))
                    {
                        dics.Add(item.MainType, new Dictionary<string, int>() { { item.Name, (int)item.VideoId } });
                    }
                    else
                    {
                        if (!dics[item.MainType].ContainsKey(item.Name))
                        {
                            dics[item.MainType].Add(item.Name, (int)item.VideoId);
                        }
                    }
                }

            }
            return dics;
        }
    }

    partial class MobileEvent
    {
        /// <summary>
        /// �Ƿ����ڲ���
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                DateTime now = DateTime.Now;
                return this.playtime <= now && this.playtime.AddSeconds(this.duration) > now;
            }
        }
    }
}
