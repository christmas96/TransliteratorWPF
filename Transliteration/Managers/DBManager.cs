using NLog;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using Transliteration.Models;
using Transliteration.Tools;

namespace Transliteration.Managers
{
    internal class DBManager : DbContext
    {
        public static Logger Log = LogManager.GetCurrentClassLogger();
        private static List<User> _users;
        private static List<Translit> _translits;
        private static AplicationContext _db;
        private static List<Translit> _translitsHistory;

        internal DBManager()
        {
            try
            {
                Log.Info("Try to connect to DB.");
                _db = new AplicationContext();
                GetUsers();
                GetTranslits();
            }
            catch (SQLiteException e)
            {
                Log.Error("Problems with DB: {0}", e.ToString());
                MessageBox.Show("Error: " + e.ToString());
            }
        }

        internal static bool UserExists(string login)
        {
            return _users.Any(u => u.Login == login);
        }

        internal static User GetUserByLogin(string login)
        {
            return _users.FirstOrDefault(u => u.Login == login);
        }

        internal static void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        internal static void AddTranslit(Translit Translit)
        {
            _db.Translits.Add(Translit);
            _db.SaveChanges();
        }

        internal static List<Translit> GetTranslitsByUserId(int UserId)
        {
            GetTranslits();
            _translitsHistory = new List<Translit>();
            foreach (Translit t in _translits)
            {
                if (t.UserId == UserId) _translitsHistory.Add(t);
            }
            return _translitsHistory;
        }

        internal static void DisposeDB()
        {
            _db.Dispose();
        }

        private static void GetTranslits()
        {
            _db.Translits.Load();
            _translits = _db.Translits.ToList();
        }

        private void GetUsers()
        {
            _db.Users.Load();
            _users = _db.Users.ToList();
        }
    }
}
