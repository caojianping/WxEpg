using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataCompanyViewDataContext
    {
        /// <summary>
        /// ������Ӫ�̱�Ż�ȡ��Ӫ������
        /// </summary>
        /// <param name="companyId">��Ӫ�̱��</param>
        /// <returns></returns>
        public string GetCompanyNameByCompanyId(int companyId)
        {
            var item = this.CompanyView.FirstOrDefault(s => s.Id == companyId);
            if (item != null)
                return item.name;
            return string.Empty;
        }

        /// <summary>
        /// ���ݵ���λ�û�ȡ��Ӫ�̼���
        /// ��ע��Dictionary<int, string>���Ͳ�֧�ַ����л�
        /// </summary>
        /// <param name="province">ʡ</param>
        /// <param name="city">��</param>
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
                var defaults = this.CompanyView.FirstOrDefault(o => o.name == "Ĭ��");
                dic.Add(defaults.Id.ToString(), defaults.name);
            }
            return dic;
        }
    }
}
