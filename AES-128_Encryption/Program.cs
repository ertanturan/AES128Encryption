using System;
using System.Security.Cryptography;
using System.Text;

namespace AES_128_Encryption
{
    class AESTest
    {
        public static void Main()
        {
            string original = "Here is some data to encrypt!";
            //128 bit (16 byte) Key value here
            string keyValue = " "; //128 bit (16 byte) Key value here
            string IVValue = " ";//128 bit (16 byte) initial vector value here

            byte[] key = Encoding.ASCII.GetBytes(keyValue);
            byte[] IV = Encoding.ASCII.GetBytes(IVValue);

            Console.WriteLine(IV.Length);

            // Encrypted the string.
            string encrypted = Encrypt(original, keyValue);

            // Decrypted string.
            string roundtrip = Decrypt(encrypted, keyValue);

            //Display the original data and the decrypted data.
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("Encrypted :   {0}", encrypted);
            Console.WriteLine("Round Trip: {0}", roundtrip);

            Console.Read();

        }

        public static string Encrypt(string encryptStr, string key)
        {

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);
            byte[] resultArray;
            using (Rijndael rDel = Rijndael.Create())
            {
                rDel.KeySize = 128;
                rDel.BlockSize = 128;
                rDel.Key = keyArray;
                rDel.IV = keyArray;

                rDel.Mode = CipherMode.CBC;

                rDel.Padding = PaddingMode.PKCS7;


                ICryptoTransform cTransform = rDel.CreateEncryptor();

                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            }

            //RijndaelManaged rDel = new RijndaelManaged();






            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        public static string Decrypt(string decryptStr, string key)
        {

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);

            byte[] resultArray;

            using (Rijndael rDel = Rijndael.Create())
            {
                rDel.KeySize = 128;
                rDel.BlockSize = 128;
                rDel.Key = keyArray;

                rDel.IV = keyArray;

                //rDel.KeySize = 128;

                rDel.Mode = CipherMode.CBC;

                rDel.Padding = PaddingMode.PKCS7;


                ICryptoTransform cTransform = rDel.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            }

            //RijndaelManaged rDel = new RijndaelManaged();





            return UTF8Encoding.UTF8.GetString(resultArray);

        }

    }
}

