using System;
using System.Linq;
using System.Collections.Generic;

namespace WxEpg.Mobile.Models
{
    partial class DataVideoExtendViewDataContext
    {
        /// <summary>
        /// ��ȡӰ�Ӿ���չ��Ϣ�б�
        /// </summary>
        /// <returns></returns>
        public List<VideoExtendView> GetVideoExtends()
        {
            return this.VideoExtendView.OrderByDescending(m => m.visitCount).ToList();
        }
    }
}
