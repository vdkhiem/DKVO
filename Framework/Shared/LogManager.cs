using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Framework.Shared
{
    public static class LogManager
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogInfo(string message)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info(message);
        }

        public static void LogError(string message)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Error(message);
        }

        public static void LogException(string message, Exception ex)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Error(message, ex);
        }
    }
}
