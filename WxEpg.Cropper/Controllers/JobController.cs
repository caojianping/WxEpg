using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxEpg.Cropper.Models;
using WxEpg.Cropper.ViewModels;

namespace WxEpg.Cropper.Controllers
{
    public class JobController : Controller
    {
        /// <summary>
        /// 任务视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SessionExpireHandle()]
        public ActionResult JobList()
        {
            var item = new JobListViewModel
            {
                Groups = DataHelper.GetGroupNames(),
                Parameters = new QueryParameters(),
                Data = null
            };
            return View(item);
        }

        /// <summary>
        /// 任务查询
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPost]
        [SessionExpireHandle()]
        public ActionResult JobList(QueryParameters parameters)
        {
            parameters.ChannelGroup = Request.Form["Parameters.ChannelGroup"];
            parameters.TaskType = Request.Form["Parameters.TaskType"];
            var item = new JobListViewModel
            {
                Groups = DataHelper.GetGroupNames(),
                Parameters = parameters,
                Data = DataHelper.GetJobList(parameters)
            };
            return View(item);
        }

        /// <summary>
        /// 影视剧详情视图
        /// </summary>
        /// <param name="videoId"></param>
        /// <param name="videoName"></param>
        /// <returns></returns>
        public ActionResult Video(int videoId, string videoName)
        {
            string vname = VideoHelper.GetVideoName(videoId);
            VideoViewModel item = new VideoViewModel()
            {
                VideoId = videoId,
                VideoName = string.IsNullOrEmpty(vname) ? videoName : vname,
                Main = VideoHelper.GetVideoMain(videoId),
                Synopsis = VideoHelper.GetVideoSynopsis(videoId),
                Section = VideoHelper.GetVideoSection(videoId)
            };
            return View(item);
        }

        /// <summary>
        /// 保存单个影视剧分类数据
        /// </summary>
        /// <param name="vc"></param>
        /// <returns></returns>
        [SessionExpireHandle()]
        public JsonResult SaveSingleVideoCategory(VideoCategory vc)
        {
            var result = DataHelper.SaveSingleVideoCategory(vc);
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存多个影视剧分类数据
        /// </summary>
        /// <param name="vcs"></param>
        /// <returns></returns>
        [SessionExpireHandle()]
        public JsonResult SaveMultipleVideoCategories(List<VideoCategory> vcs)
        {
            var result = DataHelper.SaveMultipleVideoCategories(vcs);
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 影视剧图片编辑视图
        /// </summary>
        /// <param name="videoId"></param>
        /// <param name="videoName"></param>
        /// <returns></returns>
        [SessionExpireHandle()]
        public ActionResult Image(int videoId, string videoName)
        {
            var item = DataHelper.GetVideoForImage(videoId, videoName);
            return View(item);
        }

        /// <summary>
        /// 保存影视剧图片数据
        /// </summary>
        /// <param name="editId"></param>
        /// <param name="videoId"></param>
        /// <param name="fileName"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        [SessionExpireHandle()]
        public JsonResult SaveImage(int editId, int videoId, string fileName, string rect)
        {
            try
            {
                string path = Server.MapPath("~/data/") + fileName;
                string cutPath = Server.MapPath("~/data/") + "tmp.jpg";
                bool result = DataHelper.SaveImage(editId, videoId, fileName, rect, path, cutPath);
                return Json(new { status = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Append(Server.MapPath("~/log") + "/saveImage", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 影视剧基本信息编辑视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SessionExpireHandle()]
        public ActionResult Basic(int videoId, string videoName, string mainType)
        {
            ViewBag.VideoId = videoId;
            ViewBag.VideoName = videoName;
            ViewBag.MainType = mainType;
            var items = DataHelper.GetVideoForBasic(videoId, videoName, mainType);
            return View(items);
        }

        /// <summary>
        /// 保存影视剧基本信息数据
        /// </summary>
        /// <param name="editId"></param>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [HttpPost]
        [SessionExpireHandle()]
        public ActionResult Basic(int editId, int videoId, string videoName, string mainType, FormCollection form)
        {
            try
            {
                Dictionary<string, string> dics = new Dictionary<string, string>();
                foreach (var key in form.AllKeys)
                {
                    if (!dics.ContainsKey(key))
                    {
                        dics.Add(key, form[key]);
                    }
                }
                bool result = DataHelper.SaveBasic(editId, videoId, dics);
                ViewBag.Message = true ? "保存成功" : "保存失败";
                ViewBag.VideoId = videoId;
                ViewBag.VideoName = videoName;
                ViewBag.MainType = mainType;
                var items = DataHelper.GetVideoForBasic(videoId, videoName, mainType);
                return View(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新审核状态
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        [SessionExpireHandle()]
        public JsonResult UpdateAuditStatus(int videoId)
        {
            var items = DataHelper.GetAuditStatusByVideoId(videoId);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

    }

    public class VideoCategory
    {
        public int EditId { get; set; }
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public string MainType { get; set; }
        public string Category { get; set; }
    }
}
