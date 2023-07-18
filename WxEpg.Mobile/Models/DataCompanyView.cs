using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataCompanyViewDataContext
    {
        /// <summary>
        /// 根据运营商编号获取运营商名称
        /// </summary>
        /// <param name="companyId">运营商编号</param>
        /// <returns></returns>
        public string GetCompanyNameByCompanyId(int companyId)
        {
            var item = this.CompanyView.FirstOrDefault(s => s.Id == companyId);
            if (item != null)
                return item.name;
            return string.Empty;
        }

        /// <summary>
        /// 根据地理位置获取运营商集合
        /// 备注：Dictionary<int, string>类型不支持反序列化
        /// </summary>
        /// <param name="province">省</param>
        /// <param name="city">市</param>
        /// <returns></returns>
        public Dictionary<string, string> GetCompanyDictionaryByLocation(string province, string city)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var items = this.CompanyView.ToList();
            if (string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                foreach (var item in items)
                {
                    if (dic.ContainsKey(item.Id.ToString()))
                        continue;
                    dic.Add(item.Id.ToString(), item.name);
                }
            }
            else
            {
                foreach (var item in items)
                {
                    if (dic.ContainsKey(item.Id.ToString()))
                        continue;
                    if (item.province.IndexOf(province) >= 0 && item.city.IndexOf(city) >= 0)
                    {
                        dic.Add(item.Id.ToString(), item.name);
                    }
                }
            }
            if (dic.Count <= 0)
            {
                var defaults = this.CompanyView.FirstOrDefault(o => o.name == "默认");
                dic.Add(defaults.Id.ToString(), defaults.name);
            }
            return dic;
        }
    }
}
