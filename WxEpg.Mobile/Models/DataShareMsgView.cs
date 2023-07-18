using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataShareMsgViewDataContext
    {
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <returns></returns>
        public List<ShareMsgView> GetShareMsgs()
        {
            return this.ShareMsgView.ToList();
        }

        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="userId">�û���</param>
        /// <param name="title">��������</param>
        /// <param name="desc">��������</param>
        /// <param name="link">���ӵ�ַ</param>
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
