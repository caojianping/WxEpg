using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;

namespace WxEpg.Mobile
{
    public class Logger
    {
        private static Object Locker { get; set; }
        private static StreamWriter LogWriter { get; set; }
        private static Logger logger = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path"></param>
        public Logger(string path)
        {
            Locker = new object();
            LogWriter = new StreamWriter(path, false, Encoding.UTF8);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path"></param>
        public static void Init(string path)
        {
            if (logger == null)
            {
                logger = new Logger(path);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public static void Close()
        {
            if (Locker == null) return;

            lock (Locker)
            {
                if (LogWriter != null)
                {
                    LogWriter.Close();
                    LogWriter = null;
                }
            }
        }

        /// <summary>
        /// 添加一行日志
        /// </summary>
        /// <param name="value"></param>
        public static void AppendLine(string path, string value)
        {
            if (logger == null)
            {
                Logger.Init(path);
            }

            if (Locker == null) return;

            lock (Locker)
            {
                if (LogWriter != null)
                {
                    LogWriter.WriteLine(string.Format("time({0})：{1}", DateTime.Now.ToString("hh:mm:ss"), value));
                    LogWriter.Flush();
                }
            }
        }
    }
}