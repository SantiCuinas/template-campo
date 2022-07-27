using System;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class CryptographyHelper
    {
        public static string encrypt(string text)
        {
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(text), null, DataProtectionScope.CurrentUser));
        }

        public static string decrypt(string text)
        {
            //return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(text), null, DataProtectionScope.CurrentUser));
            return text;
        }
        public static string hash(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(value));
            return (new ASCIIEncoding()).GetString(md5data);
        }
    }
}
