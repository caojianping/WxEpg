using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataUserChannelViewDataContext
    {
        /// <summary>
        /// 获取用户频道列表
        /// </summary>
        /// <param name="companyId">运营商编号</param>
        /// <returns></returns>
        public List<UserChannelView> GetUserChannelsByCompanyId(int companyId)
        {

            var items = this.UserChannelView.Where(o => o.companyId == companyId && o.channelId != null && o.channelId > 0).OrderBy(o => o.Id).ToList();
            items.Sort(new CustomCompare());
            return items;
        }

        /// <summary>
        /// 根据运营商编号获取用户频道列表（分部加载）
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
        /// 根据用户频道名称获取用户频道列表
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
