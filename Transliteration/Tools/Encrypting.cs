using System.Linq;
using System.Text;

namespace Transliteration.Tools
{
    internal static class Encrypting
    {
        internal static string code;

        internal static string EncryptText(string text)
        {
            var passBytes = Encoding.ASCII.GetBytes(text);
            string code = passBytes.ToString();
            return code;
        }

        internal static bool CheckPass(string userPass, string enterPass)
        {
            string tmp = EncryptText(enterPass);
            bool flag = userPass.SequenceEqual(tmp);
            if (flag) return true;
            return false;
        }
    }
}
