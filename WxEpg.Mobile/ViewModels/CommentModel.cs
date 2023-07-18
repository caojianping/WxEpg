using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxEpg.Mobile.ViewModels
{
    public class CommentModel
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public List<CommentLib.Comment> Data { get; set; }
        public string Sign { get; set; }
    }
}