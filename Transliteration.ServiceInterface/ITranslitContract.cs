using System;
using System.Collections.Generic;
using System.ServiceModel;
using Transliteration.DBModels;

namespace WCF.Transliteration.ServiceInterface
{
    [ServiceContract]
    public interface ITranslitContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddTranslit(Translit translit);
        [OperationContract]
        List<Translit> GetTranslitsByUserGuid(Guid UserGuid);
    }
}