using System;
using System.Linq;
using System.Collections.Generic;

namespace WxEpg.Mobile.Models
{
    partial class DataNetResourceDataContext
    {
        /// <summary>
        /// ��ȡ������Դ
        /// </summary>
        /// <param name="videoId">Ӱ�Ӿ���</param>
        /// <param name="type">����</param>
        /// <returns></returns>
        public NetResource GetNetResourceByVideoId(int videoId, string type)
        {
            return this.NetResource.FirstOrDefault(o => o.VideoId == videoId && o.PlatType == type);
        }
    }
}
