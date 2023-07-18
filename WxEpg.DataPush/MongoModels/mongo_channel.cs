using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxEpg.DataPush.MongoModels
{
    public class mongo_channel
    {
        public int channelId { get; set; }
        public string channelName { get; set; }
        public List<string> groups { get; set; }
    }
}
