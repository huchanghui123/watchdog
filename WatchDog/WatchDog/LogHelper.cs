using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WatchDog
{
    public class LogHelper
    {
        public static readonly log4net.ILog Loginfo = log4net.LogManager.GetLogger("loginfo");

        public static readonly log4net.ILog Logerror = log4net.LogManager.GetLogger("logerror");

        private LogHelper()
        {
        }

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void WriteLog(string info)
        {
            if (Loginfo.IsInfoEnabled)
            {
                Loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (Logerror.IsErrorEnabled)
            {
                Logerror.Error(info, ex);
            }
        }
    }
}
