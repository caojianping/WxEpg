using System;
using System.Linq;
using System.Collections.Generic;

namespace WxEpg.Mobile.Models
{
    partial class DataNetResourceDataContext
    {
        /// <summary>
        /// 获取网络资源
        /// </summary>
        /// <param name="videoId">影视剧编号</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public NetResource GetNetResourceByVideoId(int videoId, string type)
        {
            return this.NetResource.FirstOrDefault(o => o.VideoId == videoId && o.PlatType == type);
        }
    }
}
