using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataUserChannelViewDataContext
    {
        /// <summary>
        /// ��ȡ�û�Ƶ���б�
        /// </summary>
        /// <param name="companyId">��Ӫ�̱��</param>
        /// <returns></returns>
        public List<UserChannelView> GetUserChannelsByCompanyId(int companyId)
        {

            var items = this.UserChannelView.Where(o => o.companyId == companyId && o.channelId != null && o.channelId > 0).OrderBy(o => o.Id).ToList();
            items.Sort(new CustomCompare());
            return items;
        }

        /// <summary>
        /// ������Ӫ�̱�Ż�ȡ�û�Ƶ���б��ֲ����أ�
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="cid"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<UserChannelView> GetUserChannelsByCompanyId(int companyId, int cid, int count)
        {
            if (companyId <= 0) return null;
            if (cid == 0)
                return this.UserChannelView.Where(o => o.companyId == companyId).OrderBy(o => o.Id).Take(count).ToList();
            return this.UserChannelView.Where(o => o.companyId == companyId && o.Id > cid).OrderBy(o => o.Id).Take(count).ToList();
        }

        /// <summary>
        /// �����û�Ƶ�����ƻ�ȡ�û�Ƶ���б�
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<UserChannelView> GetUserChannelsByName(int companyId, string name)
        {
            if (companyId <= 0)
                return null;
            return this.UserChannelView.Where(o => o.name.Contains(name)).ToList();
        }
    }

    public class CustomCompare : IComparer<UserChannelView>
    {
        public int Compare(UserChannelView x, UserChannelView y)
        {
            int m, n;
            int.TryParse(x.stationNumber, out m);
            int.TryParse(y.stationNumber, out n);
            return m - n;
        }
    }

}
