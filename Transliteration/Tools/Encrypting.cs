using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Transliteration.Tools
{
    public static class Encrypting
    {
        public static string code;

        public static string EncryptText(string text)
        {
            var passBytes = Encoding.ASCII.GetBytes(text);
            string code = passBytes.ToString();
            return code;
        }

        public static bool CheckPass(string userPass, string enterPass)
        {
            string tmp = EncryptText(enterPass);
            bool flag = userPass.SequenceEqual(tmp);
            if (flag) return true;
            return false;
        }
    }
}
