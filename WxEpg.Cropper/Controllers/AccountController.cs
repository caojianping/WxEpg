using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpgAuth;
using WxEpg.Cropper.Models;

namespace WxEpg.Cropper.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 登录视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            var cookie = Request.Cookies["USER"];
            if (cookie != null)
            {
                string userName = cookie["UserName"];
                string password = EpgAuth.EncryptAndDecrypt.Decrypt(cookie["Password"]);
                if (Session["USER"] == null)
                {
                    var item = AuthHelper.GetEpgUserByUserName(userName);
                    Session["USER"] = item;
                    Session.Timeout = 120;
                }
                bool result = DataHelper.IsPasswordCorrect(userName, password);
                if (!result) return View();
                return RedirectToAction("MainPage", "Account");
            }
            else
            {
                if (Session["USER"] != null) Session.Abandon();
                return View();
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string userName = form["userName"];
            string password = form["password"];
            bool result = DataHelper.IsPasswordCorrect(userName, password);
            if (result)
            {
                string remember = form["remember"];
                if (!string.IsNullOrEmpty(remember))
                {
                    bool isRemember = bool.Parse(form["remember"]);
                    if (isRemember && Request.Cookies["USER"] == null)
                    {
                        HttpCookie cookie = new HttpCookie("USER");
                        cookie.Values.Add("UserName", userName);
                        cookie.Values.Add("Password", EpgAuth.EncryptAndDecrypt.Encrypt(password));
                        cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie);
                    }
                }
                if (Session["USER"] == null)
                {
                    var item = AuthHelper.GetEpgUserByUserName(userName);
                    Session["USER"] = item;
                    Session.Timeout = 120;
                }
                return RedirectToAction("MainPage", "Account");
            }
            else
            {
                TempData["Msg"] = "用户名或者密码错误！";
                return View();
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [SessionExpireHandle()]
        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies["USER"].Expires = DateTime.Now.AddSeconds(-1);
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// 导航视图
        /// </summary>
        /// <returns></returns>
        [SessionExpireHandle()]
        public ActionResult MainPage()
        {
            return View();
        }

    }
}
