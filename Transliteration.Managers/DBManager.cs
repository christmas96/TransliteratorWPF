using System.Collections.Generic;
using Transliteration.DBModels;
using System;
using WCF.Transliteration.ServiceInterface;

namespace Transliteration.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return TranslitServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return TranslitServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            TranslitServiceWrapper.AddUser(user);
        }

        public static void AddTranslit(Translit translit)
        {
            TranslitServiceWrapper.AddTranslit(translit);
        }

        public static List<Translit> GetTranslitsByUserGuid(Guid UserGuid)
        {
            return TranslitServiceWrapper.GetTranslitsByUserGuid(UserGuid);
        }
    }
}
