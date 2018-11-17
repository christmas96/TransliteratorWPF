using System;

namespace Transliteration.Tools
{
    public static class Encrypting
    {

        public static string EncryptText(string text)
        {
            string pass = HidePass(text);
            return pass;
        }

        public static bool CheckPass(string userPass, string enterPass)
        {
            bool flag = userPass == HidePass(enterPass);
            if (flag) return true;
            return false;
        }

        public static string HidePass(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
