using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Transliteration.Models;

namespace Transliteration.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }

        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\User.bin";

        public static void Initialize(){}

        public static void CloseApp()
        {
            DBManager.DisposeDB();
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

        public static void AddCurrentUser()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, CurrentUser);
            stream.Close();
        }

        public static void GetCurrentUser()
        {
            IFormatter formatter2 = new BinaryFormatter();
            Stream stream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read);
            CurrentUser = (User)formatter2.Deserialize(stream);
            stream.Close();
        }

        public static void RemoveCurrentUser()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
            CurrentUser = null;
        }

        public static bool CheckCurrentUser()
        {
            if (File.Exists(_path))
            {
                return true;
            }
            return false;
        }
    }
}
