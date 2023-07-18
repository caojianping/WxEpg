using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WxEpg.DataPush.MongoModels;
using System.Text.RegularExpressions;

namespace WxEpg.DataPush.Models
{
    partial class ChannelDataContext
    {
        /// <summary>
        /// 获取标准频道列表
        /// </summary>
        /// <returns></returns>
        public List<mongo_channel> GetChannels()
        {
            List<mongo_channel> items = new List<mongo_channel>();
            foreach (var item in this.channel.Where(t => t.inuse == true))
            {
                mongo_channel schannel = new mongo_channel()
                {
                    channelId = item.id,
                    channelName = item.name,
                    groups = item.viagroup == null ?
                    new List<string>() : Regex.Split(item.viagroup, @"[,，]").ToList()
                };
                items.Add(schannel);
            }
            return items;
        }
    }
}
