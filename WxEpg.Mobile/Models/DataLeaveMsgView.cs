using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataLeaveMsgViewDataContext
    {
        /// <summary>
        /// 获取留言列表
        /// </summary>
        /// <returns></returns>
        public List<LeaveMsgView> GetLeaveMsgs()
        {
            return this.LeaveMsgView.ToList();
        }

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="wxId"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public bool AddLeaveMsg(string wxId, string contents)
        {
            if (string.IsNullOrEmpty(wxId))
                return false;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into LeaveMsg (WxId,Contents,Status,Reply,CreateTime) values (");
                sb.Append("'" + wxId + "',");
                sb.Append("'" + contents + "',");
                sb.Append("'" + false + "',");
                sb.Append("'" + string.Empty + "',");
                sb.Append("'" + DateTime.Now.ToString() + "');");
                if (sb.Length > 0 && SqlHelper.ExecuteNonQuery(sb.ToString()) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
