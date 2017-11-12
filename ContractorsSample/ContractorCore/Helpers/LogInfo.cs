using log4net;
using System;

namespace ContractorCore.Helpers
{
    public static class LogInfo
    {
        private static ILog log = null;

        public static void SetLogForApplication(ILog log4net)
        {
            log = log4net;
        }

        public static void LogMessage(enumLogInfoType type, string message)
        {
            if (log == null)
                return;

            switch (type)
            {
                case enumLogInfoType.Debug:
                    log.Debug(message);
                    break;
                case enumLogInfoType.Info:
                    log.Info(message);
                    break;
                case enumLogInfoType.Warn:
                    log.Warn(message);
                    break;
                case enumLogInfoType.Error:
                    log.Error(message);
                    break;
                case enumLogInfoType.Fatal:
                    log.Fatal(message);
                    break;
            }
        }

        public static void LogMessage(enumLogInfoType type, Exception exception)
        {
            LogMessage(type, "", exception);
        }

        public static void LogMessage(enumLogInfoType type, string message, Exception exception)
        {
            if (log == null)
                return;
            switch (type)
            {
                case enumLogInfoType.Debug:
                    log.Debug(message, exception);
                    break;
                case enumLogInfoType.Info:
                    log.Info(message, exception);
                    break;
                case enumLogInfoType.Warn:
                    log.Warn(message, exception);
                    break;
                case enumLogInfoType.Error:
                    log.Error(message, exception);
                    break;
                case enumLogInfoType.Fatal:
                    log.Fatal(message, exception);
                    break;
            }
        }
    }
}
