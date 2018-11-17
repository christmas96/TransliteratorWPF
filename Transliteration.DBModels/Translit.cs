using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Transliteration.DBModels
{
    public class Translit
    {
        private Guid _userId;
        private Guid _guid;
        private string _enterText;
        private string _translateText;
        private DateTime _date;
        private User _user;

        [Key]
        public Guid Guid
        {
            get => _guid;
            set
            {
                _guid = value;
            }
        }

        public Guid UserGuid
        {
            get => _userId;
            set
            {
                _userId = value;
            }
        }

        public string EnterText
        {
            get => _enterText;
            set
            {
                _enterText = value;
            }
        }

        public string TranslateText
        {
            get => _translateText;
            set
            {
                _translateText = value;
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

        public User User
        {
            get => _user; 
            private set
            {
                _user = value;
            }
        }

        public Translit() { }

        public Translit(User user, string EnteredText, string TranslitedText) : this()
        {
            _guid = Guid.NewGuid();
            _userId = user.Guid;
            _enterText = EnteredText;
            _translateText = TranslitedText;
            _date = DateTime.Now;
            user.Translits.Add(this);
        }

        public override string ToString()
        {
            return this.Date + " " + this.EnterText + " " + this.TranslateText;
        }

        public class TranslitEntityConfiguration : EntityTypeConfiguration<Translit>
        {
            public TranslitEntityConfiguration()
            {
                ToTable("Translits");
                HasKey(k => k.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.EnterText)
                    .HasColumnName("EnterText")
                    .IsRequired();
                Property(p => p.TranslateText)
                    .HasColumnName("TranslateText")
                    .IsRequired();
                Property(p => p.Date)
                    .HasColumnName("Date")
                    .IsRequired();
            }            
        }

        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}