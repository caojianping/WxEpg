using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxEpg.DataPush.MongoModels
{
    [Serializable]
    public class mongo_userchannel
    {
        public int id { get; set; }//用户频道编号
        public string name { get; set; }//用户频道名称
        public int relId { get; set; }//标准频道编号
        public string relName { get; set; }//标准频道名称
        public string station { get; set; }//台号
    }
}
