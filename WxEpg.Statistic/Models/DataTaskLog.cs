using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxEpg.Statistic.Models
{
    partial class DataTaskLogDataContext
    {
        public List<TaskLog> GetTaskLogs()
        {
            return this.TaskLog.ToList();
        }

        public List<TaskLog> GetTaskLogsByUserAndTime(string userName, DateTime startTime, DateTime endTime, int type)
        {
            if (type == 0)
                return this.TaskLog
                    .Where(m => m.EditName == userName && ((DateTime)m.EditTime >= startTime && (DateTime)m.EditTime <= endTime))
                    .OrderByDescending(m => m.EditTime)
                    .ToList();
            return this.TaskLog
                .Where(m => m.AuditName == userName && ((DateTime)m.AuditTime >= startTime && (DateTime)m.AuditTime <= endTime))
                .OrderByDescending(m => m.AuditTime)
                .ToList();
        }
    }
}
