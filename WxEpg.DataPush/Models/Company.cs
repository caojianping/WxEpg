using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WxEpg.DataPush.MongoModels;
using System.IO;

namespace WxEpg.DataPush.Models
{
    partial class CompanyDataContext
    {
        public string[] GetSyncCompanys()
        {
            string companyPath = Properties.Settings.Default.CompanyPath;
            if (!File.Exists(companyPath))
            {
                FileStream fs = File.Create(companyPath);
                fs.Close();
            }
            return File.ReadAllLines(companyPath, Encoding.Default);
        }

        /// <summary>
        /// 获取运营商列表
        /// </summary>
        /// <returns></returns>
        public List<mongo_companys> GetCompanys()
        {
            List<mongo_companys> items = new List<mongo_companys>();
            string[] arrs = GetSyncCompanys();
            var companys = this.networkcompany.Where(t => arrs.Contains<string>(t.name) == true);
            foreach (var item in companys)
            {
                var userchannels = GetUserChannels(item.Id);
                mongo_companys company = new mongo_companys()
                {
                    companyId = item.Id,
                    companyName = item.name,
                    userchannels = userchannels,
                };
                items.Add(company);
            }
            return items;
        }

        /// <summary>
        /// 根据运营商编号获取用户频道列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<mongo_userchannel> GetUserChannels(int companyId)
        {
            List<mongo_userchannel> items = new List<mongo_userchannel>();
            var userchannels = this.userchannel.Where(t => t.companyId == companyId);
            foreach (var item in userchannels)
            {
                mongo_userchannel userchannel = new mongo_userchannel()
                {
                    id = item.Id,
                    name = item.name,
                    relId = item.relChannelId ?? -1,
                    relName = item.relChannelName,
                    station = item.stationNumber
                };
                items.Add(userchannel);
            }
            return items;
        }
    }
}
