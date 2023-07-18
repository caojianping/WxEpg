using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxEpg.DataPush.Models;
using WxEpg.DataPush.MongoModels;

namespace WxEpg.DataPush
{
    public class PushController
    {
        private UsersDataContext userContext = null;
        private CompanyDataContext companyContext = null;
        private ChannelDataContext channelContext = null;
        private OperateLogDataContext logContext = null;

        public PushController()
        {
            userContext = new UsersDataContext();
            companyContext = new CompanyDataContext();
            channelContext = new ChannelDataContext();
            logContext = new OperateLogDataContext();
        }

        public List<mongo_users> GetUsers()
        {
            return userContext.GetUsers();
        }

        public List<mongo_companys> GetCompanys()
        {
            return companyContext.GetCompanys();
        }

        public List<mongo_channel> GetChannels()
        {
            return channelContext.GetChannels();
        }

        public List<OperateLog> GetLatestOperateLogs()
        {
            return logContext.GetLatestOperateLogs();
        }

        public bool UpdateOperateLogStatus(List<int> ids)
        {
            return logContext.UpdateOperateLogStatus(ids);
        }
    }
}
