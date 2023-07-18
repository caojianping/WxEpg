using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxEpg.DataPush.MongoModels
{
    [Serializable]
    public class mongo_users
    {
        public string userid { get; set; }
        public string wxid { get; set; }
        public int companyId { get; set; }
        public List<int> loveChannels { get; set; }
        public int lastVisit { get; set; }
    }
}
