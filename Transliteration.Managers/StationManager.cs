using NLog;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Transliteration.DBModels;

namespace Transliteration.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }
        public static Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string USER_PATH = Path.Combine(PATH, "User.bin");

        public static void Initialize(){}

        public static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

        public static void AddCurrentUser()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(USER_PATH, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, CurrentUser);
                stream.Close();
            }
            catch(SerializationException e)
            {
                Log.Error("Error when write user for auto login: " + e.ToString());
            }
        }

        public static void GetCurrentUser()
        {
            try
            {
                IFormatter formatter2 = new BinaryFormatter();
                Stream stream = new FileStream(USER_PATH, FileMode.Open, FileAccess.Read, FileShare.Read);
                CurrentUser = (User)formatter2.Deserialize(stream);
                stream.Close();
            }
            catch(Exception e)
            {
                Log.Error("Error when read user for auto login: " + e.ToString());
            }
        }

        public static void RemoveCurrentUser()
        {
            if (File.Exists(USER_PATH))
            {
                File.Delete(USER_PATH);
            }
            CurrentUser = null;
        }

        public static bool CheckCurrentUser()
        {
            if (File.Exists(USER_PATH))
            {
                return true;
            }
            return false;
        }
    }
}
