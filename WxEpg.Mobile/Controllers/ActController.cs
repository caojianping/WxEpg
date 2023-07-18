using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WenXinHelper;
using WxEpg.Mobile.Models;
using WxEpg.Mobile.ViewModels;

namespace WxEpg.Mobile.Controllers
{
    public class ActController : BaseController
    {
        public ActionResult Index(string sid)
        {
            string wxId = GetWxId();
            if (string.IsNullOrEmpty(wxId)) return Content("非法的请求途径！");

            WxUser wuser = WxHelper.GetUserInfo(wxId);
            bool isWatch = wuser.subscribe == "0" ? false : true;

            if (!string.IsNullOrEmpty(sid))
            {
                string ip = Request.UserHostAddress;
                if (!ActivityHelper.IsReplyExist(sid, wxId))
                {
                    ActivityHelper.AddReply(sid, wxId, ip);
                }
            }
            var gitem = PromoterHelper.GetInfo(mhelper.GetUsersIdByWxId(sid) + 10000);
            var ditem = PromoterHelper.CreateDimensionCode(gitem.id);
            string dcode = ditem.imgurl;
            string sign = WxHelper.RegisterUrl(HttpContext.Request.Url.ToString());
            ActivityViewModel item = new ActivityViewModel()
            {
                ShareId = sid,
                WxId = wxId,
                IsWatch = isWatch,
                DimensionCode = dcode,
                Sign = sign
            };
            return View(item);
        }

        public void Init(string title, string desc, string link, string wxId)
        {
            string fileName = Utility.ActivityPath + "/" + wxId;
            if (!System.IO.File.Exists(fileName))
            {
                var fs = System.IO.File.Create(fileName);
                fs.Close();
            }
        }

        public ActionResult Rank(string wxId)
        {
            RankViewModel item = new RankViewModel()
            {
                WxId = wxId,
                Name = mhelper.GetUserNameByWxId(wxId),
                Rank = ActivityHelper.GetCurrentRank(wxId),
                Data = ActivityHelper.GetActivityRanks()
            };
            return View(item);
        }
    }
}
