using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WxEpg.Mobile.Models
{
    /// <summary>
    /// 推广员帮助类
    /// </summary>
    public class PromoterHelper : HttpHelper
    {
        static string uri = Properties.Settings.Default.PromoterUri;

        /// <summary>
        /// 获取推广员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ArgItem GetInfo(int id)
        {
            string url = uri + "main/info?uid=" + id;
            string data = GetData(url);
            var item = JsonConvert.DeserializeObject<ArgItem>(data);
            return item;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ArgItem CreateDimensionCode(int id)
        {
            string url = uri + "main/create?uid=" + id;
            string data = GetData(url);
            var item = JsonConvert.DeserializeObject<ArgItem>(data);
            return item;
        }

        /// <summary>
        /// 获取关注的微信用户列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<detailItem> GetAllDetail(int id)
        {
            string url = uri + "main/GetAllDetail?uid=" + id;
            string data = GetData(url);
            var items = JsonConvert.DeserializeObject<List<detailItem>>(data);
            return items;
        }
    }

    public partial class ArgItem
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public string user { get; set; }

        /// <summary>
        /// 二维码地址
        /// </summary>
        public string imgurl { get; set; }

        /// <summary>
        /// 推广字符串地址
        /// </summary>
        public string strurl { get; set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime expire { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        public int qrscene_count { get; set; }

        /// <summary>
        /// 扫描数
        /// </summary>
        public int scan_count { get; set; }

        public DateTime addtime { get; set; }

    }

    public partial class ArgItem
    {
        public ArgItem()
        {
            Users = new List<detailItem>();
        }
        /// <summary>
        /// 开通状态
        /// </summary>
        public bool IsOpen { get; set; }

        public List<detailItem> Users { get; set; }
    }

    public class detailItem
    {
        public string wxid { get; set; }
        public DateTime addtime { get; set; }
        public string username
        {
            get
            {
                if (string.IsNullOrEmpty(this.wxid))
                    return string.Empty;
                var mhelper = new MobileHelper();
                return mhelper.GetUserNameByWxId(this.wxid);
            }
        }

        public string head
        {
            get
            {
                if (string.IsNullOrEmpty(this.wxid))
                    return string.Empty;
                var mhelper = new MobileHelper();
                return mhelper.GetHeadByWxId(this.wxid);
            }
        }
    }
}