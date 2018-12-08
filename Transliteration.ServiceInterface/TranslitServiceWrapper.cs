using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.ServiceModel;
using Transliteration.DBModels;

namespace WCF.Transliteration.ServiceInterface
{
    public class TranslitServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<ITranslitContract>("Server"))
            {
                ITranslitContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<ITranslitContract>("Server"))
            {
                ITranslitContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static void AddUser(User user)
        {
            try
            {
                using (var myChannelFactory = new ChannelFactory<ITranslitContract>("Server"))
                {
                    ITranslitContract client = myChannelFactory.CreateChannel();
                    client.AddUser(user);
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }            
        }

        public static void AddTranslit(Translit translit)
        {
            try
            {
                using (var myChannelFactory = new ChannelFactory<ITranslitContract>("Server"))
                {
                    ITranslitContract client = myChannelFactory.CreateChannel();
                    client.AddTranslit(translit);
                }               
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public static List<Translit> GetTranslitsByUserGuid(Guid userGuid)
        {
            using (var myChannelFactory = new ChannelFactory<ITranslitContract>("Server"))
            {
                ITranslitContract client = myChannelFactory.CreateChannel();
                return client.GetTranslitsByUserGuid(userGuid);
            }
        }
    }
}
