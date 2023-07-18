using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataShareMsgViewDataContext
    {
        /// <summary>
        /// 获取分享列表
        /// </summary>
        /// <returns></returns>
        public List<ShareMsgView> GetShareMsgs()
        {
            return this.ShareMsgView.ToList();
        }

        /// <summary>
        /// 添加分享
        /// </summary>
        /// <param name="userId">用户号</param>
        /// <param name="title">分享主题</param>
        /// <param name="desc">内容描述</param>
        /// <param name="link">链接地址</param>
        public void AddShareMsg(string userId, string title, string desc, string link)
        {
            if (string.IsNullOrEmpty(userId)) return;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into ShareMessage(UserId,ShareTime,Title,Description,Link) values (");
                sb.Append("'" + userId + "',");
                sb.Append("'" + DateTime.Now.ToString() + "',");
                sb.Append("'" + title + "',");
                sb.Append("'" + desc + "',");
                sb.Append("'" + link + "');");
                if (sb.Length > 0) SqlHelper.ExecuteNonQuery(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
