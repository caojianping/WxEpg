using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;

namespace WxEpg.Mobile.Models
{
    public static class ActivityHelper
    {
        public static void AddReply(string sid, string user, string ip)
        {
            string path = Utility.ActivityPath + "/" + sid;
            if (!File.Exists(path)) return;

            List<ActReply> items = GetReplysByFile(path);
            items.Add(new ActReply { User = user, Time = DateTime.Now.ToString(), Ip = ip });
            File.WriteAllText(path, new JavaScriptSerializer().Serialize(items));
        }

        public static bool IsReplyExist(string sid, string user)
        {
            string path = Utility.ActivityPath + "/" + sid;
            if (!File.Exists(path)) return false;

            List<ActReply> items = GetReplysByFile(path);
            var item = items.FirstOrDefault(o => o.User == user);
            if (item != null) return true;
            return false;
        }

        public static Dictionary<string, int> GetActivityRanks()
        {
            Dictionary<string, int> dics = new Dictionary<string, int>();

            string[] files = Directory.GetFiles(Utility.ActivityPath);
            foreach (var item in files)
            {
                string wxId = Path.GetFileName(item);
                List<ActReply> items = GetReplysByFile(item);

                DataUsersDataContext usContext = new DataUsersDataContext();
                string userName = usContext.GetUserNameByWxId(wxId);
                if (string.IsNullOrEmpty(userName)) continue;

                if (!dics.ContainsKey(userName))
                {
                    dics.Add(userName, items.Count);
                }
            }
            return dics.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);
        }

        public static int GetCurrentRank(string wxId)
        {
            int index = 0;
            DataUsersDataContext usContext = new DataUsersDataContext();
            string userName = usContext.GetUserNameByWxId(wxId);
            Dictionary<string, int> dics = GetActivityRanks();
            int i = 0;
            foreach (var kv in dics)
            {
                if (kv.Key == userName)
                {
                    index = i + 1;
                    break;
                }
                i++;
            }
            return index;
        }

        private static List<ActReply> GetReplysByFile(string path)
        {
            List<ActReply> items = new List<ActReply>();
            if (File.Exists(path))
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string text = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(text))
                {
                    items = (List<ActReply>)jss.Deserialize<List<ActReply>>(text);
                }
            }
            return items;
        }
    }

    public class ActReply
    {
        public string User { get; set; }
        public string Time { get; set; }
        public string Ip { get; set; }
    }
}