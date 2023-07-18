using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxEpg.Mobile.Models;
using WxEpg.Mobile.ViewModels;
using WenXinHelper;

namespace WxEpg.Mobile.Controllers
{
    public class TecentController : BaseController
    {
        #region 搜节目
        /// <summary>
        /// 搜节目视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search()
        {
            try
            {
                SessionPretreat();
                return View();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 节目搜索
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search(string name)
        {
            var items = mhelper.QueryEventsByName(name);
            return View(items);
        }
        #endregion

        #region 频道表
        /// <summary>
        /// 频道表视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Channel()
        {
            try
            {
                SessionPretreat();
                suser suser = (suser)Session["USER"];
                string wxId = suser.wxid;
                mhelper.AddUsersByWxId(wxId);

                int? companyId = mhelper.GetCompanyIdByWxId(wxId);
                if (companyId == null) return View("ErrorCommon", new Error { Msg = "亲，您还没有设置运营商！", Url = "/Account/Index" });

                string companyName = mhelper.GetCompanyNameByCompanyId((int)companyId);
                ChannelModel item = new ChannelModel()
                {
                    CompanyId = (int)companyId,
                    CompanyName = companyName,
                    Sign = WxHelper.RegisterUrl(HttpContext.Request.Url.ToString())
                };
                return View(item);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 加载分部数据
        /// </summary>
        /// <param name="companyId">运营商编号</param>
        /// <param name="cid">当前编号</param>
        /// <param name="count">条目</param>
        /// <returns></returns>
        public ActionResult GetPartsUserChannels(int companyId, int cid, int count)
        {
            var items = mhelper.GetUserChannelsByCompanyId(companyId, cid, count);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 节目单视图
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="playDate"></param>
        /// <returns></returns>
        public ActionResult Event(int channelId, string playDate)
        {
            try
            {
                SessionPretreat();
                suser suser = (suser)Session["USER"];
                mhelper.AddUsersByWxId(suser.wxid);

                ChannelView channel = mhelper.GetChannelById(channelId);
                if (channel == null) return View("ErrorCommon", new Error { Msg = "亲，暂无此频道对应的节目单数据！", Url = "/Tecent/Channel" });

                EventModel item = new EventModel()
                {
                    ChannelId = channelId,
                    ChannelName = channel.name,
                    PlayDate = DateTime.Parse(playDate),
                    ShowDates = GetShowDates(),
                    Data = mhelper.GetEventsByIdAndDate(channelId, playDate),
                    Sign = WenXinHelper.WxHelper.RegisterUrl(HttpContext.Request.Url.ToString())
                };
                return View(item);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 获取七天日期
        /// </summary>
        /// <returns></returns>
        private List<DateTime> GetShowDates()
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                dates.Add(DateTime.Now.AddDays(i));
            }
            return dates;
        }
        #endregion

        #region 正在播出
        [HttpGet]
        public ActionResult Play(string playTime, string showTime, string category)
        {
            try
            {
                SessionPretreat();
                var suser = (suser)Session["USER"];
                string wxId = suser.wxid;
                mhelper.AddUsersByWxId(wxId);

                int? companyId = mhelper.GetCompanyIdByWxId(wxId);
                if (companyId == null) return View("ErrorCommon", new Error { Msg = "亲，您还没有设置运营商！", Url = "/Account/Index" });

                if (string.IsNullOrEmpty(playTime)) playTime = DateTime.Now.ToString();
                if (string.IsNullOrEmpty(showTime)) showTime = "当前时间";
                if (string.IsNullOrEmpty(category)) category = "*";
                PlayModel item = new PlayModel()
                {
                    CompanyId = (int)companyId,
                    PlayTime = playTime,
                    ShowTime = showTime,
                    Category = category,
                };
                return View(item);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 根据条件分部加载正在播出列表
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="playTime"></param>
        /// <param name="category"></param>
        /// <param name="cid"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ActionResult GetPartsPlays(int companyId, string playTime, string category, string cid, int count)
        {
            var items = mhelper.GetPlays(companyId, playTime, category, cid, count);
            return CustomJson(items, JsonRequestBehavior.AllowGet, "yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region 大家爱看
        [HttpGet]
        public ActionResult Favourite()
        {
            try
            {
                SessionPretreat();
                var items = mhelper.GetVideoExtends();
                return View(items);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region 推广员
        [HttpGet]
        public ActionResult Promoter()
        {
            try
            {
                SessionPretreat();
                var suser = (suser)Session["USER"];
                int id = mhelper.GetUsersIdByWxId(suser.wxid);
                var item = PromoterHelper.GetInfo(id + 10000);
                return View(item);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 创建二维码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult CreateDimensionCode(int id)
        {
            var item = PromoterHelper.CreateDimensionCode(id);
            string expire = item.expire.ToString("MM/dd");
            string url = item.imgurl;
            return Json(new { expire = expire, imgurl = url }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 留言板
        [HttpGet]
        public ActionResult LeaveMsg()
        {
            try
            {
                var items = mhelper.GetLeaveMsgs();
                return View(items);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult LeaveMsg(string contents)
        {
            try
            {
                var suser = (suser)Session["USER"];
                bool result = mhelper.AddLeaveMsg(suser.wxid, contents);
                TempData["Message"] = result ? "添加成功！" : "添加失败！";
                var items = mhelper.GetLeaveMsgs();
                return View(items);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                var items = mhelper.GetLeaveMsgs();
                return View(items);
            }
        }
        #endregion
    }
}
