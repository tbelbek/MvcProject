using System;
using System.IO;

namespace Core
{
    /// <summary>
    /// Loglama hizmetlerini saglar.
    /// </summary>
    /// <remarks>
    /// <code>
    /// using Core;
    /// LogHelper.Instance().Debug("Application started.");
    /// </code>
    /// </remarks>
    public class LogHelper
    {
        public static readonly log4net.ILog Logger;

        public static void Log4Net()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "config\\Log4Net.config")));

            ////Logger = log4net.LogManager.GetLogger(typeof(BaseTest));
            Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Logger.Debug("Test");
        }

        public static LogHelper Instance()
        {
            return new LogHelper();
        }

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Warn(string message)
        {
            Logger.Warn(message);
        }

        public void Error(string message, Exception exception = null)
        {
            Logger.Error(message, exception);
        }

        public void Fatal(string message, Exception exception = null)
        {
            Logger.Fatal(message, exception);
        }
    }
}
