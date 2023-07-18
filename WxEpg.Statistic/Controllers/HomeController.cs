using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxEpg.Statistic.Models;
using WxEpg.Statistic.ViewModels;

namespace WxEpg.Statistic.Controllers
{
    public class HomeController : Controller
    {
        private DataTaskLogDataContext tcontext;
        private DataTaskStatusDataContext tscontext;
        public HomeController()
        {
            tcontext = new DataTaskLogDataContext();
            tscontext = new DataTaskStatusDataContext();
        }

        [HttpGet]
        public ActionResult TaskLog()
        {
            var item = new TaskLogViewModel()
            {
                Parameters = new TaskLogQueryParameters(),
                Data = null
            };
            return View(item);
        }

        [HttpPost]
        public ActionResult TaskLog(TaskLogQueryParameters parameters)
        {
            DateTime stime = DateTime.Parse(parameters.StartTime);
            DateTime etime = DateTime.Parse(parameters.EndTime);
            var items = tcontext.GetTaskLogsByUserAndTime(parameters.UserName, stime, etime, parameters.LogType);
            var item = new TaskLogViewModel()
            {
                Parameters = parameters,
                Data = items
            };
            return View(item);
        }

        [HttpGet]
        public ActionResult TaskStat()
        {
            var items = tscontext.GetTaskStat();
            return View(items);
        }

    }
}
