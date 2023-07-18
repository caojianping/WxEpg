using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxEpg.Mobile.Models;
using WenXinHelper;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace WxEpg.Mobile.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// 用户视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                SessionPretreat();
                var suser = (suser)Session["USER"];
                var item = mhelper.GetUsersByWxId(suser.wxid);
                return View(item);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="phone">电话</param>
        /// <param name="companyId">运营商编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string userName, string phone, int companyId)
        {
            try
            {
                SessionPretreat();
                var suser = (suser)Session["USER"];
                bool result = mhelper.UpdateUsersByWxId(suser.wxid, userName, phone, companyId);
                TempData["Message"] = result ? "保存成功！" : "保存失败！";
                var item = mhelper.GetUsersByWxId(suser.wxid);
                return View(item);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 根据地理位置获取运营商集合
        /// </summary>
        /// <param name="province">省</param>
        /// <param name="city">市</param>
        /// <returns></returns>
        public JsonResult GetCompanyDictionaryByLocation(string province, string city)
        {
            var dic = mhelper.GetCompanyDictionaryByLocation(province, city);
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取城市数据
        /// </summary>
        /// <returns></returns>
        public string GetCityData()
        {
            try
            {
                Dictionary<string, List<string>> dics = new Dictionary<string, List<string>>();
                string fileName = Server.MapPath("~/city.txt");
                if (!System.IO.File.Exists(fileName)) System.IO.File.Create(fileName);
                string[] lines = System.IO.File.ReadAllLines(fileName, Encoding.Default);
                foreach (string l in lines)
                {
                    string[] parts = Regex.Split(l.Trim(), @"\s+");
                    string first = parts.Length >= 1 ? parts[0] : string.Empty;
                    string second = parts.Length >= 2 ? parts[1] : string.Empty;
                    string third = parts.Length >= 3 ? parts[2] : string.Empty;
                    if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second) && !string.IsNullOrEmpty(third))
                    {
                        //如果second存在，判断second是否存在？
                        if (dics.ContainsKey(second))
                        {
                            //如果second存在，判断third是否存在？
                            if (!dics[second].Contains(third))
                            {
                                //如果third不存在，添加third
                                dics[second].Add(third);
                            }
                        }
                        else
                        {
                            //如果second不存在，添加second、third
                            dics.Add(second, new List<string>() { third });
                        }
                    }
                }
                return new JavaScriptSerializer().Serialize(dics);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
