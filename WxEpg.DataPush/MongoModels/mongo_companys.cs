using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxEpg.DataPush.MongoModels
{
    [Serializable]
    public class mongo_companys
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        public List<mongo_userchannel> userchannels { get; set; }
    }
}
