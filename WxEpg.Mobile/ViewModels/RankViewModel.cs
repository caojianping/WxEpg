using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Mobile.ViewModels
{
    public class RankViewModel
    {
        public string WxId { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public Dictionary<string, int> Data { get; set; }
    }
}