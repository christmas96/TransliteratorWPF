using NLog;
using System;
using System.ServiceModel;
using System.ServiceProcess;

namespace WCF.Transliteration.TranslitService
{
    public class TranslitWindowsService : ServiceBase
    {
        public static Logger Log = LogManager.GetCurrentClassLogger();
        internal const string CurrentServiceName = "TranslitService";
        internal const string CurrentServiceDisplayName = "Translit Service";
        internal const string CurrentServiceSource = "TranslitService";
        internal const string CurrentServiceLogName = "TranslitServiceLogName";
        internal const string CurrentServiceDescription = "Translit for learning purposes.";
        private ServiceHost _serviceHost = null;

        public TranslitWindowsService()
        {
            ServiceName = CurrentServiceName;
            try
            {
                AppDomain.CurrentDomain.UnhandledException += UnhandledException;
               Log.Info("Initialization");
            }
            catch (Exception ex)
            {
                Log.Error("Initialization: " + ex.ToString());
            }
        }

        protected override void OnStart(string[] args)
        {
            Log.Info("OnStart");
            RequestAdditionalTime(120 * 1000);
#if DEBUG
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(1000);
            //}
#endif
            try
            {
                if (_serviceHost != null)
                    _serviceHost.Close();
            }
            catch
            {
            }
            try
            {
                _serviceHost = new ServiceHost(typeof(TranslitService));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                Log.Error("OnStart: " + ex.ToString());
                throw;
            }
            Log.Info("Service Started ");
        }

        protected override void OnStop()
        {
            Log.Info("OnStop");
            RequestAdditionalTime(120 * 1000);
            try
            {
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                Log.Error("Trying To Stop The Host Listener: " + ex.ToString());
            }
            Log.Info("Service Stopped");
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var ex = (Exception)args.ExceptionObject;

            Log.Error("UnhandledException: " + ex.ToString());
        }
    }
}
