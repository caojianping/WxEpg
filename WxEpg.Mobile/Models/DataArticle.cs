using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataArticleDataContext
    {
        /// <summary>
        /// 获取微信文章数目
        /// </summary>
        /// <param name="videoId">影视剧编号</param>
        /// <returns></returns>
        public int GetArticleCountByVideoId(int videoId)
        {
            var items = this.Article.Where(o => o.VideoId == videoId);
            int count = (items == null) ? 0 : items.Count<Article>();
            return count;
        }

        /// <summary>
        /// 获取微信文章列表
        /// </summary>
        /// <param name="videoId">影视剧编号</param>
        /// <returns></returns>
        public List<Article> GetArticles(int videoId)
        {
            return this.Article.Where(o => o.VideoId == videoId).ToList();
        }
    }
}
