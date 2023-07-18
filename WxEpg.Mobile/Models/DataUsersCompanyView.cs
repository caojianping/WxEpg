using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WxEpg.Mobile.Models
{
    partial class DataUsersCompanyViewDataContext
    {
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="wxId">΢�ű��</param>
        public void AddUsersByWxId(string wxId)
        {
            if (!string.IsNullOrEmpty(wxId) || IsUsersExist(wxId))
                return;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into users (wxid,createtime,lasttime) values (");
                sb.Append("'" + wxId + "',");
                sb.Append("'" + DateTime.Now.ToString() + "',");
                sb.Append("'" + DateTime.Now.ToString() + "');");
                if (sb.Length > 0)
                    SqlHelper.ExecuteNonQuery(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����΢�ű�Ż�ȡ�û�
        /// </summary>
        /// <param name="wxId">΢�ű��</param>
        /// <returns></returns>
        public UsersCompanyView GetUsersByWxId(string wxId)
        {
            var item = this.UsersCompanyView.FirstOrDefault(s => s.wxid == wxId);
            return item;
        }

        /// <summary>
        /// ����΢�ű�Ż�ȡ�û�����
        /// </summary>
        /// <param name="wxId">΢�ű��</param>
        /// <returns></returns>
        public string GetUserNameByWxId(string wxId)
        {
            var item = this.UsersCompanyView.FirstOrDefault(s => s.wxid == wxId);
            if (item != null)
                return item.username;
            return string.Empty;
        }

        /// <summary>
        /// ��֤�û��Ƿ����
        /// </summary>
        /// <param name="wxId">΢�ű��</param>
        /// <returns></returns>
        public bool IsUsersExist(string wxId)
        {
            var item = this.UsersCompanyView.FirstOrDefault(m => m.wxid == wxId);
            if (item != null)
                return true;
            return false;
        }

        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        /// <param name="wxId">΢�ű��</param>
        /// <param name="companyId">��Ӫ�̱��</param>
        /// <returns></returns>
        public bool UpdateUsersByWxId(string wxId, string userName, string phone, int companyId)
        {
            if (string.IsNullOrEmpty(wxId) ||
                string.IsNullOrEmpty(userName) ||
                companyId <= 0)
                return false;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update users set ");
                sb.Append("username='" + userName + "',");
                sb.Append("phone='" + phone + "',");
                sb.Append("companyid=" + companyId + ",");
                sb.Append("lasttime='" + DateTime.Now.ToString() + "' ");
                sb.Append("where wxid='" + wxId + "';");
                if (sb.Length > 0 && SqlHelper.ExecuteNonQuery(sb.ToString()) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ����΢�ű�Ż�ȡ��Ӫ�̱��
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public int? GetCompanyIdByWxId(string wxId)
        {
            if (string.IsNullOrEmpty(wxId))
                return null;
            var item = this.UsersCompanyView.FirstOrDefault(o => o.wxid == wxId);
            return item.companyid;
        }

        /// <summary>
        /// ����΢�ű�Ż�ȡ�û����
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public int GetUsersIdByWxId(string wxId)
        {
            var item = this.UsersCompanyView.FirstOrDefault(o => o.wxid == wxId);
            if (item != null)
                return item.id;
            return 0;
        }

        /// <summary>
        /// ����΢�ű�Ż�ȡ�û�ͷ��
        /// </summary>
        /// <param name="wxId"></param>
        /// <returns></returns>
        public string GetHeadByWxId(string wxId)
        {
            var item = this.UsersCompanyView.FirstOrDefault(o => o.wxid == wxId);
            if (item != null)
                return item.head;
            return string.Empty;
        }
    }
}
