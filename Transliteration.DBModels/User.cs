using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Transliteration.Tools;

namespace Transliteration.DBModels
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
        private DateTime _lastLoginDate;
        [NonSerialized]
        private List<Translit> _translits;

        [Key]
        public Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

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

        public DateTime LastLoginDate
        {
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }
                
       public List<Translit> Translits
        {
            get
            {
                if (_translits != null)
                {
                    return _translits;
                }
                else
                {
                    _translits = new List<Translit>();
                    return _translits;
                }
            }

            set
            {
                _translits = value;
            }
        }

        public User()
        {
        }

        public User(string firstName, string lastName, string email, string login, string password) : this()
        {
            _guid = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _login = login;
            SetPassword(password);
            _lastLoginDate = DateTime.Now;
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

        public class UserEntityConfiguration : EntityTypeConfiguration<User>
        {
            public UserEntityConfiguration()
            {
                ToTable("Users");
                HasKey(k => k.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(p => p.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
                Property(p => p.Email)
                    .HasColumnName("Email")
                    .IsRequired();
                Property(p => p.Login)
                    .HasColumnName("Login")
                    .IsRequired();
                Property(p => p.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(p => p.LastLoginDate)
                    .HasColumnName("LastLoginDate")
                    .IsRequired();
                HasMany(s => s.Translits)
                    .WithRequired(w => w.User)
                    .HasForeignKey(h => h.UserGuid)
                    .WillCascadeOnDelete(true);
            }
        }
    }
}