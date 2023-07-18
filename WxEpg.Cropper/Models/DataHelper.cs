using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WxEpg.Cropper.Models
{
    public class DataHelper : HttpHelper
    {
        static string uri = Properties.Settings.Default.Uri;

        #region 用户模块数据
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsUserNameExist(string userName)
        {
            string url = uri + "/User/IsUserNameExist?userName=" + userName;
            string data = GetData(url);
            return bool.Parse(data);
        }

        /// <summary>
        /// 验证用户名、密码是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsPasswordCorrect(string userName, string password)
        {
            string url = uri + "/User/IsPasswordCorrect";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            MultipartForm form = new MultipartForm();
            form.StringEncoding = Encoding.UTF8;
            form.AddString("userName", userName);
            form.AddString("password", password);
            string data = wc.Post(url, form);
            return bool.Parse(data);
        }
        #endregion

        #region 任务模块数据
        /// <summary>
        /// 获取分组名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetGroupNames()
        {
            try
            {
                string url = uri + "Job/GetGroupNames";
                string data = GetData(url);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var items = jss.Deserialize<List<string>>(data);
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static List<JobItem> GetJobList(ViewModels.QueryParameters parameter)
        {
            try
            {
                string url = uri + "Job/GetJobList";
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                MultipartForm form = new MultipartForm();
                form.StringEncoding = Encoding.UTF8;
                form.AddString("eventName", parameter.EventName);
                form.AddString("channelName", parameter.ChannelName);
                form.AddString("startTime", parameter.StartTime);
                form.AddString("endTime", parameter.EndTime);
                form.AddString("channelGroup", parameter.ChannelGroup);
                form.AddString("mainType", parameter.MainType);
                form.AddString("taskType", parameter.TaskType);
                string data = wc.Post(url, form);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var items = jss.Deserialize<List<JobItem>>(data);
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存单个影视剧分类数据
        /// </summary>
        /// <param name="vc"></param>
        /// <returns></returns>
        public static bool SaveSingleVideoCategory(Controllers.VideoCategory vc)
        {
            try
            {
                string url = uri + "Job/SaveSingleVideoCategory";
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                MultipartForm form = new MultipartForm();
                form.StringEncoding = Encoding.UTF8;
                form.AddString("editId", vc.EditId.ToString());
                form.AddString("videoId", vc.VideoId.ToString());
                form.AddString("videoName", vc.VideoName);
                form.AddString("mainType", vc.MainType);
                form.AddString("category", vc.Category);
                string data = wc.Post(url, form);
                return bool.Parse(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存多个影视剧分类数据
        /// </summary>
        /// <param name="vcs"></param>
        /// <returns></returns>
        public static bool SaveMultipleVideoCategories(List<Controllers.VideoCategory> vcs)
        {
            try
            {
                string url = uri + "Job/SaveMultipleVideoCategories";
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string text = jss.Serialize(vcs);
                string data = PostData(url, Encoding.UTF8.GetBytes(text));
                return bool.Parse(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取影视剧图片信息
        /// </summary>
        /// <param name="videoId"></param>
        /// <param name="videoName"></param>
        /// <returns></returns>
        public static Video GetVideoForImage(int videoId, string videoName)
        {
            try
            {
                string url = uri + "Job/GetVideoForImage?videoId=" + videoId + "&videoName=" + videoName;
                string data = GetData(url);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var item = jss.Deserialize<Video>(data);
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存图片数据
        /// </summary>
        /// <param name="editId"></param>
        /// <param name="videoId"></param>
        /// <param name="fileName"></param>
        /// <param name="rect"></param>
        /// <param name="path"></param>
        /// <param name="cutPath"></param>
        /// <returns></returns>
        public static bool SaveImage(int editId, int videoId, string fileName, string rect, string path, string cutPath)
        {
            try
            {
                JObject jobj = JObject.Parse(rect);
                int x = (int)(double.Parse(jobj["x"].ToString()));
                int y = (int)(double.Parse(jobj["y"].ToString()));
                int width = (int)(double.Parse(jobj["width"].ToString()));
                int height = (int)(double.Parse(jobj["height"].ToString()));

                byte[] bytes = ImageHelper.CutImage(path, x, y, width, height, cutPath);
                string url = uri + "Job/SaveImage?editId=" + editId + "&videoId=" + videoId + "&fileName=" + fileName;
                string data = PostData(url, bytes);
                File.Delete(cutPath);
                return bool.Parse(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取影视剧基本信息
        /// </summary>
        /// <param name="videoId"></param>
        /// <param name="videoName"></param>
        /// <param name="mainType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetVideoForBasic(int videoId, string videoName, string mainType)
        {
            try
            {
                Dictionary<string, string> dics = new Dictionary<string, string>();
                string url = uri + "Job/GetVideoForBasic?videoId=" + videoId + "&videoName=" + videoName + "&mainType=" + mainType;
                string data = GetData(url);
                WxNetInfo.Json.JsonConverter jc = new WxNetInfo.Json.JsonConverter(data);
                List<string> keys = jc.GetMainAtt();
                foreach (string key in keys)
                {
                    string value = jc.GetMainValue(key);
                    if (!dics.ContainsKey(key)) dics.Add(key, value);
                }
                return dics;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 保存基本信息数据
        /// </summary>
        /// <param name="editId"></param>
        /// <param name="videoId"></param>
        /// <param name="basics"></param>
        /// <returns></returns>
        public static bool SaveBasic(int editId, int videoId, Dictionary<string, string> dics)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string text = jss.Serialize(dics);
                string url = uri + "Job/SaveBasic?editId=" + editId + "&videoId=" + videoId;
                string data = PostData(url, Encoding.UTF8.GetBytes(text));
                return bool.Parse(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据影视剧编号获取审核状态
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAuditStatusByVideoId(int videoId)
        {
            try
            {
                string url = uri + "Job/GetAuditStatusByVideoId?videoId=" + videoId;
                string data = GetData(url);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var items = jss.Deserialize<Dictionary<string, string>>(data);
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}