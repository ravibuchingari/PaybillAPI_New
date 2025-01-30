using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PaybillWinApp.Models
{
    public class DataProtection
    {
        public static string EncryptWithIV(string plainText, string[] keys)
        {
            if (plainText == null || string.IsNullOrEmpty(plainText.Trim()))
                return string.Empty;
            byte[] bytesPlainText = Encoding.UTF8.GetBytes(plainText);
            using Aes cipher = Aes.Create();
            cipher.Key = Encoding.UTF8.GetBytes(keys[0]);
            cipher.IV = Encoding.UTF8.GetBytes(keys[1]);
            ICryptoTransform cryptoTransform = cipher.CreateEncryptor();
            byte[] bytesCipherText = cryptoTransform.TransformFinalBlock(bytesPlainText, 0, bytesPlainText.Length);
            return Convert.ToBase64String(bytesCipherText);
        }

        public static string DecryptWithIV(string cipherText, string[] keys)
        {
            if (cipherText == null || string.IsNullOrEmpty(cipherText.Trim()))
                return string.Empty;

            byte[] bytesCipherText = Convert.FromBase64String(cipherText);
            using Aes cipher = Aes.Create();
            cipher.Key = Encoding.UTF8.GetBytes(keys[0]);
            cipher.IV = Encoding.UTF8.GetBytes(keys[1]);
            ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            byte[] bytesPlainText = cryptoTransform.TransformFinalBlock(bytesCipherText, 0, bytesCipherText.Length);
            return Encoding.UTF8.GetString(bytesPlainText);
        }

        public static string EncryptSimpleText(string plainText)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(plainText));
        }

        public static string DecryptSimpleText(string encryptedText)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(encryptedText));
        }

        public static string UrlEncode(string plainText, string[] keys) => HttpUtility.UrlEncode(Convert.ToBase64String(Encoding.ASCII.GetBytes(EncryptWithIV(plainText, keys))), Encoding.UTF8);

        public static string UrlDecode(string encryptedText, string[] keys) => DecryptWithIV(Encoding.ASCII.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(encryptedText, Encoding.UTF8))), keys);

    }
}
