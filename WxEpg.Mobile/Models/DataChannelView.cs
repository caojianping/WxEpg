using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataChannelViewDataContext
    {
        /// <summary>
        /// ��ȡ��׼Ƶ��
        /// </summary>
        /// <param name="id">��׼Ƶ�����</param>
        /// <returns></returns>
        public ChannelView GetChannelById(int id)
        {
            var item = this.ChannelView.FirstOrDefault(s => s.id == id);
            return item;
        }

        /// <summary>
        /// ��ȡ��׼Ƶ������
        /// </summary>
        /// <param name="id">��׼Ƶ�����</param>
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
