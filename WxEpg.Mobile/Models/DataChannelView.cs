using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataChannelViewDataContext
    {
        /// <summary>
        /// 获取标准频道
        /// </summary>
        /// <param name="id">标准频道编号</param>
        /// <returns></returns>
        public ChannelView GetChannelById(int id)
        {
            var item = this.ChannelView.FirstOrDefault(s => s.id == id);
            return item;
        }

        /// <summary>
        /// 获取标准频道名称
        /// </summary>
        /// <param name="id">标准频道编号</param>
        /// <returns></returns>
        public string GetChannelNameById(int id)
        {
            var item = this.ChannelView.FirstOrDefault(o => o.id == id);
            if (item == null)
                return string.Empty;
            return item.name;
        }
    }
}
