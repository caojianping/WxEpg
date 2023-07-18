using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Mobile.ViewModels
{
    public class ActivityViewModel
    {
        public string ShareId { get; set; }
        public string WxId { get; set; }
        public bool IsWatch { get; set; }
        public string DimensionCode { get; set; }
        public string Sign { get; set; }
    }
}