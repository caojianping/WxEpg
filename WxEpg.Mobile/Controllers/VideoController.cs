using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WxEpg.Mobile.Models;
using WxEpg.Mobile.ViewModels;
using WxNetInfo.Json;
using CommentLib;
using System.Web.Script.Serialization;

namespace WxEpg.Mobile.Controllers
{
    public class VideoController : BaseController
    {
        protected CommentHelper chelper;
        public VideoController()
        {
            chelper = new CommentHelper(System.Configuration.ConfigurationManager.ConnectionStrings["epgConnectionString"].ConnectionString);
        }

        #region 影视剧信息
        /// <summary>
        /// 影视剧视图
        /// </summary>
        /// <param name="id">影视剧编号</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            try
            {
                if (id <= 0) return View(new VideoModel() { VideoId = id });
                //新浪微博
                var blog = mhelper.GetNetResourceByVideoId(id, "新浪微博");
                Info blogInfo = new Info();
                if (blog != null)
                {
                    blogInfo.Url = blog.Uri;
                    blogInfo.Attach = blog.Attach;
                }
                //百度贴吧
                var postBar = mhelper.GetNetResourceByVideoId(id, "百度贴吧");
                Info postBarInfo = new Info();
                if (postBar != null)
                {
                    postBarInfo.Url = postBar.Uri;
                    postBarInfo.Attach = postBar.Attach;
                }
                VideoModel item = new VideoModel()
                {
                    VideoId = id,
                    Main = VideoHelper.GetVideoMain(id),
                    Synopsis = VideoHelper.GetVideoSynopsis(id),
                    Section = VideoHelper.GetVideoSection(id),
                    Sign = WenXinHelper.WxHelper.RegisterUrl(Request.Url.ToString()),
                    VideoName = mhelper.GetVideoNameByVideoId(id),
                    Programs = mhelper.GetProgramByVideoId(id),
                    ArticleCount = mhelper.GetArticleCountByVideoId(id),
                    Blog = blogInfo,
                    PostBar = postBarInfo
                };
                return View(item);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        /// <summary>
        /// 初始化扩展信息
        /// </summary>
        /// <param name="videoId"></param>
        /// <param name="type"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public JsonResult InitExtend(int videoId, int type, string content)
        {
            try
            {
                if (videoId <= 0) return Json(new { status = false, msg = "不合法的影视剧编号！" }, JsonRequestBehavior.AllowGet);
                var suser = (suser)Session["USER"];
                VideoExtend item = new VideoExtend()
                {
                    VideoId = videoId,
                    UserId = suser.wxid,
                    Type = type,
                    Content = content,
                    UpdateTime = DateTime.Now
                };
                string fileName = Utility.DataPath + System.Guid.NewGuid().ToString() + ".json";
                string data = new JavaScriptSerializer().Serialize(item);
                System.IO.File.WriteAllText(fileName, data);
                return Json(new { status = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 评论
        /// <summary>
        /// 评论视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Comment(int id)
        {
            CommentModel item = new CommentModel()
            {
                VideoId = id,
                VideoName = mhelper.GetVideoNameByVideoId(id),
                Data = chelper.GetCommentsBySourceId(id),
                Sign = WenXinHelper.WxHelper.RegisterUrl(HttpContext.Request.Url.ToString())
            };
            return View(item);
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Comment()
        {
            int videoId = -1;
            string msg = string.Empty;
            try
            {
                videoId = int.Parse(Request.Form["sourceId"]);
                var suser = (suser)Session["USER"];
                bool result = chelper.AddComment(new Comment()
                {
                    UserId = suser.wxid,
                    Observer = string.IsNullOrEmpty(suser.username) ? string.Empty : suser.username,
                    SourceId = videoId,
                    Type = "用户",
                    Name = string.Empty,
                    Contents = Request.Form["contents"],
                    SupportCount = 0,
                    ReleaseTime = DateTime.Now,
                    CreateTime = DateTime.Now
                });
                msg = result ? "添加成功！" : "添加失败！";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            TempData["Message"] = msg;
            CommentModel item = new CommentModel()
            {
                VideoId = videoId,
                VideoName = mhelper.GetVideoNameByVideoId(videoId),
                Data = chelper.GetCommentsBySourceId(videoId),
                Sign = WenXinHelper.WxHelper.RegisterUrl(HttpContext.Request.Url.ToString())
            };
            return View(item);
        }

        /// <summary>
        /// 点赞，顶一个，支持
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSupport(int commentId)
        {
            bool result = chelper.AddSupport(commentId);
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }

    public class VideoExtend
    {
        public int VideoId { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// 三种类型：0表示访问，1表示喜爱，2表示评分。
        /// </summary>
        public int Type { get; set; }
        public string Content { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
