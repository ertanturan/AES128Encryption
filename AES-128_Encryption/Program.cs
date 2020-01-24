using System;
namespace AES_128_Encryption
{
    class AESTest
    {
        public static void Main()
        {
            string original = "Şifrelenmesi için türkçe karakter kullanım örneği : ğüşiöçı";
            //128 bit (16 byte) Key value here
            string keyValue = "9F7718213C58010C"; //128 bit (16 byte) Key value here
            string IVValue = "EC83D4939A7B5093";//128 bit (16 byte) initial vector value here

            CBC cbcbTrial = new CBC(keyValue, IVValue);

            string cbcEncrypted = cbcbTrial.Encrypt(original);
            string cbcDecrypted = cbcbTrial.Decrypt(cbcEncrypted);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("CBC ORIGINAL : " + original);
            Console.WriteLine("CBC ENCRYPTED : " + cbcEncrypted);
            Console.WriteLine("CBC DECRYPTED : " + cbcDecrypted);
            Console.WriteLine("------------------------------------------\n");

            string xorEncrypted = XOR.Gate("9784968549804998", original);
            string xorDecrtpyed = XOR.Gate("9784968549804998", xorEncrypted);
            Console.WriteLine("XOR ORIGINAL : " + original);
            Console.WriteLine("XOR ENCRYPTED : " + xorEncrypted);
            Console.WriteLine("XOR DECRYPTED : " + xorDecrtpyed);
            Console.WriteLine("------------------------------------------\n");

            PCBC pcbcTrial = new PCBC(keyValue, IVValue);
            string pcbcEncrypted = pcbcTrial.Encrypt(original);
            string pcbcDecrypted = pcbcTrial.Decrypt(pcbcEncrypted);
            Console.WriteLine("PCBC ORIGINAL : " + original);
            Console.WriteLine("PCBC ENCRYPTED : " + pcbcEncrypted);
            Console.WriteLine("PCBC DECRYPTED : " + pcbcDecrypted);
            Console.Read();

        }

    }
}

