using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Mobile.Models
{
    public class MobileHelper
    {
        private DataArticleDataContext aContext;
        private DataChannelViewDataContext cContext;
        private DataCompanyViewDataContext cmpContext;
        private DataLeaveMsgViewDataContext lmContext;
        private DataMobileEventDataContext meContext;
        private DataNetResourceDataContext nrContext;
        private DataShareMsgViewDataContext smContext;
        private DataUserChannelViewDataContext ucContext;
        private DataUsersCompanyViewDataContext ucmpContext;
        private DataVideoExtendViewDataContext veContext;
        private DataVideoViewDataContext vvContext;

        public MobileHelper()
        {
            aContext = new DataArticleDataContext();
            cContext = new DataChannelViewDataContext();
            cmpContext = new DataCompanyViewDataContext();
            lmContext = new DataLeaveMsgViewDataContext();
            meContext = new DataMobileEventDataContext();
            nrContext = new DataNetResourceDataContext();
            smContext = new DataShareMsgViewDataContext();
            ucContext = new DataUserChannelViewDataContext();
            ucmpContext = new DataUsersCompanyViewDataContext();
            veContext = new DataVideoExtendViewDataContext();
            vvContext = new DataVideoViewDataContext();
        }

        #region 微信文章模块接口
        public int GetArticleCountByVideoId(int videoId)
        {
            return aContext.GetArticleCountByVideoId(videoId);
        }

        public List<Article> GetArticles(int videoId)
        {
            return aContext.GetArticles(videoId);
        }
        #endregion

        #region 标准频道模块接口
        public ChannelView GetChannelById(int id)
        {
            return cContext.GetChannelById(id);
        }
        public string GetChannelNameById(int id)
        {
            return cContext.GetChannelNameById(id);
        }
        #endregion

        #region 运营商模块接口
        public string GetCompanyNameByCompanyId(int companyId)
        {
            return cmpContext.GetCompanyNameByCompanyId(companyId);
        }

        public Dictionary<string, string> GetCompanyDictionaryByLocation(string province, string city)
        {
            return cmpContext.GetCompanyDictionaryByLocation(province, city);
        }
        #endregion

        #region 留言信息模块接口
        public List<LeaveMsgView> GetLeaveMsgs()
        {
            return lmContext.GetLeaveMsgs();
        }
        public bool AddLeaveMsg(string wxId, string contents)
        {
            return lmContext.AddLeaveMsg(wxId, contents);
        }
        #endregion

        #region 节目单模块接口
        public List<MobileEvent> GetEventsByIdAndDate(int channelId, string playDate)
        {
            return meContext.GetEventsByIdAndDate(channelId, playDate);
        }

        public List<sp_getplaysResult> GetPlays(int companyId, string playTime, string category, string cid, int count)
        {
            return meContext.GetPlays(companyId, playTime, category, cid, count);
        }

        public List<MobileEvent> GetEventsByName(string name)
        {
            return meContext.GetEventsByName(name);
        }

        public Dictionary<string, Dictionary<string, int>> QueryEventsByName(string name)
        {
            return meContext.QueryEventsByName(name);
        }
        #endregion

        #region 网络资源模块接口
        public NetResource GetNetResourceByVideoId(int videoId, string type)
        {
            return nrContext.GetNetResourceByVideoId(videoId, type);
        }
        #endregion

        #region 共享信息模块接口
        public List<ShareMsgView> GetShareMsgs()
        {
            return smContext.GetShareMsgs();
        }
        public void AddShareMsg(string userId, string title, string desc, string link)
        {
            smContext.AddShareMsg(userId, title, desc, link);
        }
        #endregion

        #region 用户频道模块接口
        public List<UserChannelView> GetUserChannelsByCompanyId(int companyId)
        {
            return ucContext.GetUserChannelsByCompanyId(companyId);
        }

        public List<UserChannelView> GetUserChannelsByCompanyId(int companyId, int cid, int count)
        {
            return ucContext.GetUserChannelsByCompanyId(companyId, cid, count);
        }

        public List<UserChannelView> GetUserChannelsByName(int companyId, string name)
        {
            return ucContext.GetUserChannelsByName(companyId, name);
        }
        #endregion

        #region 用户模块接口
        public void AddUsersByWxId(string wxId)
        {
            ucmpContext.AddUsersByWxId(wxId);
        }

        public UsersCompanyView GetUsersByWxId(string wxId)
        {
            return ucmpContext.GetUsersByWxId(wxId);
        }

        public string GetUserNameByWxId(string wxId)
        {
            return ucmpContext.GetUserNameByWxId(wxId);
        }

        public bool IsUsersExist(string wxId)
        {
            return ucmpContext.IsUsersExist(wxId);
        }

        public bool UpdateUsersByWxId(string wxId, string userName, string phone, int companyId)
        {
            return ucmpContext.UpdateUsersByWxId(wxId, userName, phone, companyId);
        }

        public int? GetCompanyIdByWxId(string wxId)
        {
            return ucmpContext.GetCompanyIdByWxId(wxId);
        }

        public int GetUsersIdByWxId(string wxId)
        {
            return ucmpContext.GetUsersIdByWxId(wxId);
        }

        public string GetHeadByWxId(string wxId)
        {
            return ucmpContext.GetHeadByWxId(wxId);
        }
        #endregion

        #region 影视剧扩展信息模块接口
        public List<VideoExtendView> GetVideoExtends()
        {
            return veContext.GetVideoExtends();
        }
        #endregion

        #region 影视剧模块接口
        public string GetVideoNameByVideoId(int videoId)
        {
            return vvContext.GetVideoNameByVideoId(videoId);
        }

        public Dictionary<string, List<string>> GetProgramByVideoId(int videoId)
        {
            return vvContext.GetProgramByVideoId(videoId);
        }
        #endregion
    }
}