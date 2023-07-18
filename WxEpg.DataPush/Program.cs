using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WxEpg.DataPush.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace WxEpg.DataPush
{
    public class Program
    {
        private static string url = Properties.Settings.Default.ServerUrl;
        private static int flag = 0;

        /// <summary>
        /// 主函数：程序入口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(url))
                    {
                        Console.WriteLine("远程服务器地址不可以为空！");
                        Thread.Sleep(2000);
                        continue;
                    }
                    if (flag == 0)
                    {
                        Init();
                    }
                    else
                    {
                        Push();
                    }
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        static void Init()
        {
            Console.WriteLine("初始化：推送服务器数据……");
            PushCompanyData();
            PushChannelData();
            flag = 1;
        }

        /// <summary>
        /// 推送
        /// </summary>
        static void Push()
        {
            PushController pc = new PushController();
            List<OperateLog> items = pc.GetLatestOperateLogs();
            if (items.Count > 0)
            {
                List<int> channelIds = new List<int>();
                List<int> companyIds = new List<int>();
                bool isChannelPush = false;
                bool isCompanyPush = false;

                foreach (var item in items)
                {
                    string name = item.OperateObject;
                    switch (name)
                    {
                        case "channel":
                            if (!isChannelPush)
                            {
                                isChannelPush = true;
                            }
                            channelIds.Add(item.Id);
                            break;
                        case "company":
                            if (!isCompanyPush)
                            {
                                isCompanyPush = true;
                            }
                            companyIds.Add(item.Id);
                            break;
                        case "userchannel":
                            if (!isCompanyPush)
                            {
                                isCompanyPush = true;
                            }
                            companyIds.Add(item.Id);
                            break;
                        default:
                            break;
                    }
                }

                try
                {
                    if (isChannelPush)
                    {
                        Console.WriteLine("\n更新：推送标准频道数据……");
                        bool result = PushChannelData();
                        if (result)
                        {
                            pc.UpdateOperateLogStatus(channelIds);
                        }
                    }
                    if (isCompanyPush)
                    {
                        Console.WriteLine("\n更新：推送运营商数据……");
                        var result = PushCompanyData();
                        if (result)
                        {
                            pc.UpdateOperateLogStatus(companyIds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("更新日志出现异常：" + ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("\n……");
            }
        }

        /// <summary>
        /// 推送用户数据
        /// </summary>
        static bool PushUserData()
        {
            PushController controller = new PushController();
            List<MongoModels.mongo_users> users = controller.GetUsers();
            Console.WriteLine("用户表记录数目：" + users.Count);
            string postData = JsonConvert.SerializeObject(users);
            return PostData(postData, "user", "users");
        }

        /// <summary>
        /// 推送运营商数据
        /// </summary>
        static bool PushCompanyData()
        {
            PushController controller = new PushController();
            List<MongoModels.mongo_companys> companys = controller.GetCompanys();
            Console.WriteLine("运营商表记录数目：" + companys.Count);
            string postData = JsonConvert.SerializeObject(companys);
            return PostData(postData, "company", "companys");
        }

        /// <summary>
        /// 推送频道数据
        /// </summary>
        /// <returns></returns>
        static bool PushChannelData()
        {
            PushController controller = new PushController();
            List<MongoModels.mongo_channel> channels = controller.GetChannels();
            Console.WriteLine("标准频道表记录数目：" + channels.Count);
            string postData = JsonConvert.SerializeObject(channels);
            return PostData(postData, "channel", "channels");
        }

        /// <summary>
        /// 推送数据
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="file"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        static bool PostData(string postData, string file, string dir)
        {
            string surl = url + "f=" + file + "&d=" + dir;
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string result = wc.Post(surl, postData);
            Console.WriteLine(dir + "推送状态：" + result + "\n");
            return result.Contains("true") ? true : false;
        }

    }
}
