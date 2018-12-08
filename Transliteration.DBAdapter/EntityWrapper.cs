using System;
using System.Collections.Generic;
using System.Linq;
using Transliteration.DBModels;

namespace Transliteration.DBAdapter
{
    public static class EntityWrapper
    {

        public static List<Translit> GetTranslitsByUserGuid(Guid userGuid)
        {
            using (var context = new TransliterationDBContext())
            {
                return context.Translits.Where(x => x.UserGuid == userGuid).ToList();
            }
        }

        public static void AddTranslit(Translit translit)
        {
            using(var context = new TransliterationDBContext())
            {
                translit.DeleteDatabaseValues();
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
