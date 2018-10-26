using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transliteration.Managers;

namespace Transliteration.Models
{
    public class Translit
    {
        private long _Id;
        private long _userId;
        private string _enterText;
        private string _translateText;
        private DateTime _date;

        public long Id
        {
            get => _Id;
            set
            {
                _Id = value;
            }
        }

        public long UserId
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

        public Translit() { }

        public Translit(string EnteredText, string TranslitedText)
        {
            _userId = StationManager.CurrentUser.Id;
            _enterText = EnteredText;
            _translateText = TranslitedText;
            _date = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Date + " " + this.EnterText + " " + this.TranslateText;
        }
    }
}