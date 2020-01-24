using System;
namespace AES_128_Encryption
{
    class AESTest
    {
        public static void Main()
        {
            string original = "Şifrelenmesi için türkçe karakter kullanım örneği : ğüşiöçı";
            //128 bit (16 byte) Key value here
            string keyValue = "4582B07C2F9AE5E9"; //128 bit (16 byte) Key value here
            string IVValue = "3C26D685F5A69E75";//128 bit (16 byte) initial vector value here

            CBC cbcbTrial = new CBC(keyValue, IVValue);

            string encrypted = cbcbTrial.Encrypt(original);
            string decrypted = cbcbTrial.Decrypt(encrypted);
            Console.WriteLine("ORIGINAL : " + original);
            Console.WriteLine("ENCRYPTED : " + encrypted);
            Console.WriteLine("DECRYPTED : " + decrypted);
            Console.WriteLine(" ");
            Console.WriteLine(XOR.Gate(100, 33));

            Console.Read();

        }

    }
}

