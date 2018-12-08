using System;
using System.Collections.Generic;
using Transliteration.DBAdapter;
using Transliteration.DBModels;
using WCF.Transliteration.ServiceInterface;

namespace WCF.Transliteration.TranslitService
{
    class TranslitService : ITranslitContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddTranslit(Translit translit)
        {
            EntityWrapper.AddTranslit(translit);
        }

        public List<Translit> GetTranslitsByUserGuid(Guid UserGuid)
        {
            return EntityWrapper.GetTranslitsByUserGuid(UserGuid);
        }
    }
}
