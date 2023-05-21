using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AmitBytesBlog.Entity.Encryption
{
    public static class EncryptionHelper
    {
        const string secretKey = "3C2AA97D65A54D459F6F35F4877A782A";
        const string ivSecret = "AmitBytesB$!1012";

        public static string Encrypt(string plainText)
        {
            return Encrypt(plainText, ivSecret, secretKey);
        }
        public static string Encrypt(string plainText, string secretKey)
        {
            return Encrypt(plainText, ivSecret, secretKey);
        }
        private static string Encrypt(string plainText, string ivSecret, string secretKey)
        {
            var key = Encoding.UTF8.GetBytes(secretKey);
            var iv = Encoding.UTF8.GetBytes(ivSecret);
            using (var aesAlog = Aes.Create())
            {
                aesAlog.Key = key;
                aesAlog.IV = iv;
                using (var encryptor = aesAlog.CreateEncryptor(aesAlog.Key, aesAlog.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (StreamWriter sw = new StreamWriter(csEncrypt))
                        {
                            sw.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray()); // encrypted string
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            return Decrypt(cipherText, ivSecret, secretKey);
        }
        public static string Decrypt(string cipherText, string secretkey)
        {
            return Decrypt(cipherText, ivSecret, secretKey);
        }
        private static string Decrypt(string cipherText, string ivSecret, string secretKey)
        {
            var key = Encoding.UTF8.GetBytes(secretKey);
            var iv = Encoding.UTF8.GetBytes(ivSecret);
            string plainText;
            using (var aesAlog = Aes.Create())
            {
                aesAlog.Key = key;
                aesAlog.IV = iv;
                using (var decryptor = aesAlog.CreateDecryptor(aesAlog.Key, aesAlog.IV))
                {
                    var cipherArr = Convert.FromBase64String(cipherText);
                    using (MemoryStream msDecrypt = new MemoryStream(cipherArr))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(csDecrypt))
                            {
                                plainText = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return plainText;
        }
    }
}
