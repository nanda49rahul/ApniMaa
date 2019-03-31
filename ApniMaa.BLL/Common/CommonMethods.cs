
using System;
using System.Security.Cryptography;
using System.Text;
namespace ApniMaa.BLL.Common
{
    public class CommonMethods
    {
        /// <summary>
        /// Genrate OTP when we send email 
        /// </summary>
        /// <returns></returns>
        public static string GetUniqueOTP()
        {
            int maxSize = 10; // whatever length you want
            //char[] chars = new char[62];
            string a;
            a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] chars = new char[a.Length];
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// generates the hash code from the string passed
        /// </summary>
        public static string HashCode(string str)
        {
            SHA1 hash = SHA1CryptoServiceProvider.Create();
            byte[] plainTextBytes = Encoding.ASCII.GetBytes(str);
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);
            string localChecksum = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            return localChecksum;
        }

       
    }

    /// <summary>
    /// Encrypt the password
    /// </summary>
    public static class Crypto
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}