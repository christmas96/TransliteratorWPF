using NLog;
using System.Collections.Generic;

namespace Transliteration.Tools
{
    //створено перелік типів стандартів на випадок додання інших стандартів транслітерації, наприклад ГОСТ
    internal enum TransliterationType
    {
        ISO
    }

    internal static class TranslitDictionary
    {

        private static Logger Log = LogManager.GetCurrentClassLogger();
        private static Dictionary<string, string> Iso = new Dictionary<string, string>();

        internal static string Front(string text)
        {
            return Front(text, TransliterationType.ISO);
        }

        private static string Front(string text, TransliterationType type)
        {
            Log.Trace("Entered text start to translit.");
            string output = text;            
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
            Dictionary<string, string> tdict = Iso;
            return tdict;
        }

        static TranslitDictionary()
        {
            Iso.Add("Ї", "Yi");
            Iso.Add("Є", "Ye");
            Iso.Add("І", "I");
            Iso.Add("Ѓ", "G");
            Iso.Add("і", "i");
            Iso.Add("№", "№");
            Iso.Add("є", "ye");
            Iso.Add("ѓ", "g");
            Iso.Add("А", "A");
            Iso.Add("Б", "B");
            Iso.Add("В", "V");
            Iso.Add("Г", "G");
            Iso.Add("Д", "D");
            Iso.Add("Е", "E");
            Iso.Add("Ж", "Zh");
            Iso.Add("З", "Z");
            Iso.Add("И", "Y");
            Iso.Add("Й", "J");
            Iso.Add("К", "K");
            Iso.Add("Л", "L");
            Iso.Add("М", "M");
            Iso.Add("Н", "N");
            Iso.Add("О", "O");
            Iso.Add("П", "P");
            Iso.Add("Р", "R");
            Iso.Add("С", "S");
            Iso.Add("Т", "T");
            Iso.Add("У", "U");
            Iso.Add("Ф", "F");
            Iso.Add("Х", "Kh");
            Iso.Add("Ц", "Ts");
            Iso.Add("Ч", "Ch");
            Iso.Add("Ш", "Sh");
            Iso.Add("Щ", "Shch");
            Iso.Add("Ь", "");
            Iso.Add("Ю", "Yu");
            Iso.Add("Я", "Ya");
            Iso.Add("ї","yi");
            Iso.Add("а", "a");
            Iso.Add("б", "b");
            Iso.Add("в", "v");
            Iso.Add("г", "g");
            Iso.Add("д", "d");
            Iso.Add("е", "e");
            Iso.Add("ж", "zh");
            Iso.Add("з", "z");
            Iso.Add("и", "y");
            Iso.Add("й", "j");
            Iso.Add("к", "k");
            Iso.Add("л", "l");
            Iso.Add("м", "m");
            Iso.Add("н", "n");
            Iso.Add("о", "o");
            Iso.Add("п", "p");
            Iso.Add("р", "r");
            Iso.Add("с", "s");
            Iso.Add("т", "t");
            Iso.Add("у", "u");
            Iso.Add("ф", "f");
            Iso.Add("х", "kh");
            Iso.Add("ц", "ts");
            Iso.Add("ч", "ch");
            Iso.Add("ш", "sh");
            Iso.Add("щ", "shch");
            Iso.Add("ь", "");
            Iso.Add("ю", "yu");
            Iso.Add("я", "ya");
            Iso.Add("«", "");
            Iso.Add("»", "");
            Iso.Add("—", "-");
            Iso.Add(" ", " ");
            Iso.Add(".", ".");
        }
    }
}
