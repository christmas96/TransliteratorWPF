using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Transliteration.Models;

namespace Transliteration.Managers
{
    internal static class StationManager
    {
        public static User CurrentUser { get; set; }

        private static readonly string PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private static readonly string USER_PATH = Path.Combine(PATH, "User.bin");

        public static void Initialize(){}

        internal static void CloseApp()
        {
            DBManager.DisposeDB();
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

        internal static void AddCurrentUser()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(USER_PATH, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, CurrentUser);
            stream.Close();
        }

        internal static void GetCurrentUser()
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

            }
        }

        internal static void RemoveCurrentUser()
        {
            if (File.Exists(USER_PATH))
            {
                File.Delete(USER_PATH);
            }
            CurrentUser = null;
        }

        internal static bool CheckCurrentUser()
        {
            if (File.Exists(USER_PATH))
            {
                return true;
            }
            return false;
        }
    }
}
