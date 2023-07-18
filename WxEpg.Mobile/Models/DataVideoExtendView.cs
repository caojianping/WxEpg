using System;
using System.Linq;
using System.Collections.Generic;

namespace WxEpg.Mobile.Models
{
    partial class DataVideoExtendViewDataContext
    {
        /// <summary>
        /// 获取影视剧扩展信息列表
        /// </summary>
        /// <returns></returns>
        public List<VideoExtendView> GetVideoExtends()
        {
            return this.VideoExtendView.OrderByDescending(m => m.visitCount).ToList();
        }
    }
}
