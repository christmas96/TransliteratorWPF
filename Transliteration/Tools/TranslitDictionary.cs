using NLog;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Transliteration.Tools
{
    //створено перелік типів стандартів на випадок додання інших стандартів транслітерації, наприклад ГОСТ
    public enum TransliterationType
    {
        ISO
    }

    public static class TranslitDictionary
    {

        public static Logger log = LogManager.GetCurrentClassLogger();
        private static Dictionary<string, string> iso = new Dictionary<string, string>(); //ISO 9-95

        public static string Front(string text)
        {
            return Front(text, TransliterationType.ISO);
        }

        private static string Front(string text, TransliterationType type)
        {
            log.Trace("Entered text start to translit.");
            string output = text;

            output = Regex.Replace(output, @"\s|\.|\(", " ");
            output = Regex.Replace(output, @"\s+", " ");
            output = Regex.Replace(output, @"[^\s\w\d-]", "");
            output = output.Trim();

            Dictionary<string, string> tdict = GetDictionaryByType(type);

            foreach (KeyValuePair<string, string> key in tdict)
            {
                output = output.Replace(key.Key, key.Value);
            }
            return output;
        }

        private static Dictionary<string, string> GetDictionaryByType(TransliterationType type)
        {
            Dictionary<string, string> tdict = iso;
            return tdict;
        }

        static TranslitDictionary()
        {
            iso.Add("Є", "Ye");
            iso.Add("І", "I");
            iso.Add("Ѓ", "G");
            iso.Add("і", "i");
            iso.Add("№", "#");
            iso.Add("є", "ye");
            iso.Add("ѓ", "g");
            iso.Add("А", "A");
            iso.Add("Б", "B");
            iso.Add("В", "V");
            iso.Add("Г", "G");
            iso.Add("Д", "D");
            iso.Add("Е", "E");
            iso.Add("Ж", "Zh");
            iso.Add("З", "Z");
            iso.Add("И", "I");
            iso.Add("Й", "J");
            iso.Add("К", "K");
            iso.Add("Л", "L");
            iso.Add("М", "M");
            iso.Add("Н", "N");
            iso.Add("О", "O");
            iso.Add("П", "P");
            iso.Add("Р", "R");
            iso.Add("С", "S");
            iso.Add("Т", "T");
            iso.Add("У", "U");
            iso.Add("Ф", "F");
            iso.Add("Х", "X");
            iso.Add("Ц", "C");
            iso.Add("Ч", "Ch");
            iso.Add("Ш", "Sh");
            iso.Add("Щ", "Shh");
            iso.Add("Ь", "");
            iso.Add("Ю", "Yu");
            iso.Add("Я", "Ya");
            iso.Add("а", "a");
            iso.Add("б", "b");
            iso.Add("в", "v");
            iso.Add("г", "g");
            iso.Add("д", "d");
            iso.Add("е", "e");
            iso.Add("ж", "zh");
            iso.Add("з", "z");
            iso.Add("и", "i");
            iso.Add("й", "j");
            iso.Add("к", "k");
            iso.Add("л", "l");
            iso.Add("м", "m");
            iso.Add("н", "n");
            iso.Add("о", "o");
            iso.Add("п", "p");
            iso.Add("р", "r");
            iso.Add("с", "s");
            iso.Add("т", "t");
            iso.Add("у", "u");
            iso.Add("ф", "f");
            iso.Add("х", "h");
            iso.Add("ц", "c");
            iso.Add("ч", "ch");
            iso.Add("ш", "sh");
            iso.Add("щ", "shh");
            iso.Add("ь", "");
            iso.Add("ю", "yu");
            iso.Add("я", "ya");
            iso.Add("«", "");
            iso.Add("»", "");
            iso.Add("—", "-");
            iso.Add(" ", "-");
        }
    }
}
