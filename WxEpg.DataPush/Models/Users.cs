using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WxEpg.DataPush.MongoModels;

namespace WxEpg.DataPush.Models
{
    partial class UsersDataContext
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public List<mongo_users> GetUsers()
        {
            int defaultCompanyId = 35;
            List<mongo_users> items = new List<mongo_users>();
            foreach (var item in this.users)
            {
                mongo_users user = new mongo_users()
                {
                    userid = item.userid,
                    wxid = item.wxid,
                    companyId = item.companyid ?? defaultCompanyId,
                    loveChannels = new List<int>(),
                    lastVisit = 0
                };
                items.Add(user);
            }
            return items;
        }
    }
}
