using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace IQSoft.eCommerce.Utilities.Extensions
{
    public static class HashExtensions
    {
        private static readonly byte[] Salt_Key = new byte[32]
        {
            (byte) 1,(byte) 35,(byte) 69,(byte) 103,(byte) 131,(byte) 171,
            (byte) 205,(byte) 239,(byte) 254,(byte) 220,(byte) 186,(byte) 152,
            (byte) 118,(byte) 84,(byte) 50,(byte) 16,(byte) 17,(byte) 34,(byte) 51,
            (byte) 51,(byte) 68,(byte) 85,(byte) 102,(byte) 119,(byte) 0,(byte) 119,
            (byte) 170,(byte) 187,(byte) 204,(byte) 221,(byte) 238,byte.MaxValue
        };
        
        public static string ToHash(this string inputValue)
        {
            if (inputValue.Length < 32)
                inputValue += new string('x', 31 - inputValue.Length);
            return Convert.ToBase64String(new Rfc2898DeriveBytes(inputValue, HashExtensions.Salt_Key, 1024).GetBytes(32));
        }       

        public static string ToHashObject(object inputObject)
        {
            using (Stream stream = (Stream)new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, inputObject);
                byte[] hash = new HMACSHA1(HashExtensions.Salt_Key).ComputeHash(stream);
                stream.Close();
                return Convert.ToBase64String(hash);
            }
        }
    }
}
