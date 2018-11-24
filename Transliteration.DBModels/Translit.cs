using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace Transliteration.DBModels
{
    [DataContract(IsReference = true)]
    public class Translit
    {
        [DataMember]
        private Guid _userId;
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _enterText;
        [DataMember]
        private string _translateText;
        [DataMember]
        private DateTime _date;
        [DataMember]
        private User _user;

        [Key]
        public Guid Guid
        {
            get => _guid;
            private set { _guid = value; }
        }

        public Guid UserGuid
        {
            get => _userId;
            set { _userId = value; }
        }

        public string EnterText
        {
            get => _enterText;
            set { _enterText = value; }
        }

        public string TranslateText
        {
            get => _translateText;
            set { _translateText = value; }
        }

        public DateTime Date
        {
            get => _date;
            set { _date = value; }
        }

        public User User
        {
            get => _user; 
            set { _user = value; }
        }

        public Translit() { }

        public Translit(User user, string EnteredText, string TranslitedText) : this()
        {
            _guid = Guid.NewGuid();
            _userId = user.Guid;
            _enterText = EnteredText;
            _translateText = TranslitedText;
            _date = DateTime.Now;
            _user = user;
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