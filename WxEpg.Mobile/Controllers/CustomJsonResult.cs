using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WxEpg.Mobile.Controllers
{
    /// <summary>
    /// 自定义JsonResult
    /// </summary>
    public class CustomJsonResult : JsonResult
    {
        /// <summary>
        /// 格式化字符串
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 重写ExecuteResult
        /// </summary>
        /// <param name="context">控制器上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? this.ContentType : "application/json";
            if (this.ContentEncoding != null) response.ContentEncoding = this.ContentEncoding;
            if (this.Data != null)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string result = jss.Serialize(this.Data);
                string patt = @"\\/Date\((\d+)\)\\/";
                MatchEvaluator me = new MatchEvaluator(this.ConvertJsonDateToDateString);
                Regex reg = new Regex(patt);
                result = reg.Replace(result, me);
                response.Write(result);
            }
        }

        /// <summary>
        /// /Date(1294499956278)/转换为时间字符串
        /// </summary>  
        /// <param name="m">正则匹配</param>
        /// <returns>格式化后的字符串</returns>
        private string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            result = dt.ToString(Format);
            return result;
        }
    }
}