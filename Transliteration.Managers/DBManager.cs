using System.Collections.Generic;
using Transliteration.DBModels;
using Transliteration.DBAdapter;
using System;

namespace Transliteration.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public static void AddTranslit(Translit translit)
        {
            EntityWrapper.AddTranslit(translit);
        }

        public static List<Translit> GetTranslitsByUserGuid(Guid UserGuid)
        {
            return EntityWrapper.GetTranslitsByUserGuid(UserGuid);
        }
    }
}
