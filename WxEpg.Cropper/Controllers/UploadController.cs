using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WxEpg.Cropper.Controllers
{
    public class UploadController : Controller
    {
        [SessionExpireHandle()]
        public ActionResult Iframe(string data)
        {
            ViewBag.Data = data;
            return View();
        }

        [SessionExpireHandle()]
        public ActionResult Files(string fileName, string callback)
        {
            string data = string.Empty;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                Request.Files[0].SaveAs(Server.MapPath("~/data/") + fileName);
                data = jss.Serialize(new { status = true, fileName = fileName, message = "上传成功！", callback = callback });
                return RedirectToAction("Iframe", "Upload", new { data = data });
            }
            catch (Exception ex)
            {
                Logger.Append(Server.MapPath("~/log") + "/uploadFile", ex.Message);
                data = jss.Serialize(new { status = false, fileName = fileName, message = ex.Message, callback = callback });
                return RedirectToAction("Iframe", "Upload", new { data = data });
            }
        }

    }
}
