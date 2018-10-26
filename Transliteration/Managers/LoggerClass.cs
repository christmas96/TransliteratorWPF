
using NLog;
using System;
using System.Windows;

namespace Transliteration.Managers
{
    public class LoggerClass
    {
        public static Logger log;

        public LoggerClass()
        {
            try
            {
                log = LogManager.GetCurrentClassLogger();
                log.Trace("App srtart: {0}", DateTime.Now.ToString());
                NLog.Targets.FileTarget tar = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("file");
                tar.DeleteOldFileOnStartup = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка работы с логом!" + e.Message);
            }
        }
    }
}
