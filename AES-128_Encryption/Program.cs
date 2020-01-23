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

            ////Display the original data and the decrypted data.
            //Console.WriteLine("Original:   {0}", original);
            ////Console.WriteLine("Encrypted :   {0}", encrypted);
            ////Console.WriteLine("Round Trip: {0}", roundtrip);

            //Console.WriteLine(" ");
            //int b = 100 ^ 33;
            //Console.WriteLine(GetIntBinaryString(100));
            //Console.WriteLine(GetIntBinaryString(33));
            //Console.WriteLine(GetIntBinaryString(b));

            Console.Read();

        }



        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;

            for (int i = 0; i < 32; i++)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
            }

            return new string(b);
        }

        private static string XOR()
        {


            return " ";
        }
    }
}

