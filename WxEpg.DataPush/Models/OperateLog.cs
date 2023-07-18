using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace WxEpg.DataPush.Models
{
    partial class OperateLogDataContext
    {
        public List<OperateLog> GetLatestOperateLogs()
        {
            var items = this.OperateLog.Where(t => t.Status == true);
            return items.ToList();
        }

        public bool UpdateOperateLogStatus(List<int> ids)
        {
            string sql = "update OperateLog set Status=0,UpdateTime='" + DateTime.Now.ToString() +
                "' where Id in (" + string.Join(",", ids.ToArray()) + ")";
            return SqlHelper.ExecuteNonQuery(sql) > 0;
        }
    }
}
