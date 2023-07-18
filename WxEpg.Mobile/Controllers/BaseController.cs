using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxEpg.Mobile.Models;
using WenXinHelper;
using CommentLib;

namespace WxEpg.Mobile.Controllers
{
    public class BaseController : Controller
    {
        protected MobileHelper mhelper;
        public BaseController()
        {
            mhelper = new MobileHelper();
        }

        #region Session处理
        /// <summary>
        /// Session预处理
        /// </summary>
        protected void SessionPretreat()
        {
            if (Session["USER"] == null)
            {
                suser suser = new suser();
                string code = Request.QueryString["code"];
                if (string.IsNullOrEmpty(code))
                {
                    //throw new Exception("code参数不能为空！");
                    suser.wxid = "o2mLIswjntIW4mgtdFfS_qyR2RKE";
                    suser.userid = string.Empty;
                    suser.username = "曹剑平";
                    Session["USER"] = suser;
                }
                else
                {
                    Auth2 auth = new Auth2();
                    string openId = auth.GetOpenIDByCode(code);
                    if (string.IsNullOrEmpty(openId)) throw new Exception("OpenID不能为空！");

                    suser.wxid = openId;
                    suser.userid = string.Empty;
                    suser.username = mhelper.GetUserNameByWxId(openId);
                    Session["USER"] = suser;
                }
            }
        }
        #endregion

        #region 获取微信编号
        protected string GetWxId()
        {
            string code = Request.QueryString["code"];
            if (string.IsNullOrEmpty(code)) throw new Exception("code不能为空！");

            Auth2 auth = new Auth2();
            string openId = auth.GetOpenIDByCode(code);
            if (string.IsNullOrEmpty(openId)) throw new Exception("OpenID不能为空！");
            return openId;
        }
        #endregion

        #region 自定义JSON
        /// <summary>
        /// 返回JsonResult
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="contentType">内容类型</param>
        /// <param name="contentEncoding">内容编码</param>
        /// <param name="behavior">行为</param>
        /// <returns>JsonReuslt</returns>
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new CustomJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                Format = "yyyy-MM-dd HH:mm:ss"
            };
        }

        /// <summary>
        /// 返回JsonResult.24
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="behavior">行为</param>
        /// <param name="format">json中dateTime类型的格式</param>
        /// <returns>Json</returns>
        protected JsonResult CustomJson(object data, JsonRequestBehavior behavior, string format)
        {
            return new CustomJsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
                Format = format
            };
        }

        /// <summary>
        /// 返回JsonResult42         /// </summary>
        /// <param name="data">数据</param>
        /// <param name="format">数据格式</param>
        /// <returns>Json</returns>
        protected JsonResult CustomJson(object data, string format)
        {
            return new CustomJsonResult
            {
                Data = data,
                Format = format
            };
        }
        #endregion

        #region 分享
        /// <summary>
        /// 添加分享信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="link"></param>
        protected void AddShareMsg(string title, string desc, string link)
        {
            suser suser = (suser)Session["USER"];
            mhelper.AddShareMsg(suser.wxid, title, desc, link);
        }
        #endregion
    }

    public class Error
    {
        public string Msg { get; set; }
        public string Url { get; set; }
    }
}