using System;
using System.Collections.Generic;
using System.Linq;
using Transliteration.DBModels;

namespace Transliteration.DBAdapter
{
    public static class EntityWrapper
    {
        private static List<Translit> _translitsHistory;
        private static List<Translit> _translits;

        public static List<Translit> GetTranslitsByUserGuid(Guid UserGuid)
        {
            _translitsHistory = new List<Translit>();
            _translits = new List<Translit>();
            using (var context = new TransliterationDBContext())
            {
                _translits = context.Translits.ToList();
                foreach (Translit t in _translits)
                {
                    if (t.UserGuid == UserGuid) _translitsHistory.Add(t);
                }
                return _translitsHistory;
            }
        }

        public static void AddTranslit(Translit translit)
        {
            using(var context = new TransliterationDBContext())
            {
                context.Translits.Add(translit);
                context.SaveChanges();
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new TransliterationDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new TransliterationDBContext())
            {
                return context.Users.FirstOrDefault(u => u.Login == login);
            }               
        }

        public static bool UserExists(string login)
        {
            using (var context = new TransliterationDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }            
        }
    }
}
