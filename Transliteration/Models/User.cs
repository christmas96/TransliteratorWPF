using System;
using Transliteration.Tools;

namespace Transliteration.Models
{
    [Serializable]
    public class User
    {
        private Guid _guid;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _login;
        private string _password;
        private string _lastLoginDate;

        public int Id { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string LastLoginDate
        {
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }

        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public User() { }

        public User(string firstName, string lastName, string email, string login, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _login = login;
            SetPassword(password);
            _lastLoginDate = DateTime.Now.ToString();
            _guid = Guid.NewGuid();            
        }

        private void SetPassword(string password)
        {
            _password = Encrypting.EncryptText(password);
        }

        public bool CheckPassword(string userPass, string password)
        {
            return Encrypting.CheckPass(userPass, password);
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}