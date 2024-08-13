using System;
using System.Security.Cryptography;

namespace task_manager.Utils
{
    public class criptoPWD
    {
        private static byte[] KEY_64 = { 42, 16, 93, 156, 78, 4, 218, 32 };
        private static byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };
        public static string encrypt(string sTexto)
        {
            if (!sTexto.Equals(""))
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cs);

                sw.Write(sTexto);
                sw.Flush();
                cs.FlushFinalBlock();
                ms.Flush();

                return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            }
            else
                return "";
        }
        public static string Decrypt(string sTexto)
        {
            if (!sTexto.Equals(""))
            {
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

                byte[] buffer = Convert.FromBase64String(sTexto);
                MemoryStream ms = new MemoryStream(buffer);
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);

                return sr.ReadToEnd();
            }
            else
                return "";
        }
    }
}
