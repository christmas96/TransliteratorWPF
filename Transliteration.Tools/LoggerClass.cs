using NLog;
using System;
using System.Windows;

namespace Transliteration.Tools
{
    public class LoggerClass
    {
        public static Logger Log;

        public LoggerClass()
        {
            try
            {
                Log = LogManager.GetCurrentClassLogger();
                Log.Trace("App srtart: {0}", DateTime.Now.ToString());
                NLog.Targets.FileTarget tar = (NLog.Targets.FileTarget)LogManager.Configuration.FindTargetByName("file");
                tar.DeleteOldFileOnStartup = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error log working!" + e.Message);
            }
        }
    }
}
