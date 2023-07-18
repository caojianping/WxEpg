using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataArticleDataContext
    {
        /// <summary>
        /// ��ȡ΢��������Ŀ
        /// </summary>
        /// <param name="videoId">Ӱ�Ӿ���</param>
        /// <returns></returns>
        public int GetArticleCountByVideoId(int videoId)
        {
            var items = this.Article.Where(o => o.VideoId == videoId);
            int count = (items == null) ? 0 : items.Count<Article>();
            return count;
        }

        /// <summary>
        /// ��ȡ΢�������б�
        /// </summary>
        /// <param name="videoId">Ӱ�Ӿ���</param>
        /// <returns></returns>
        public List<Article> GetArticles(int videoId)
        {
            return this.Article.Where(o => o.VideoId == videoId).ToList();
        }
    }
}
