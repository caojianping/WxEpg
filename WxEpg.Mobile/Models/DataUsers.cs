using System;
using System.Linq;
using System.Collections.Generic;

namespace WxEpg.Mobile.Models
{
    partial class DataUsersDataContext
    {
        public string GetUserNameByWxId(string wxId)
        {
            var item = this.users.FirstOrDefault(o => o.wxid == wxId);
            if (item != null) return item.username;
            return string.Empty;
        }
    }
}
