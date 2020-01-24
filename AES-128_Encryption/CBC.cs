using System;
using System.Security.Cryptography;
using System.Text;

namespace AES_128_Encryption
{
    public class CBC
    {

        private string _keyValue;
        private string _iVValue;

        public CBC(string keyValue, string IVValue)
        {
            _keyValue = keyValue;
            _iVValue = IVValue;
        }

        public string Encrypt(string encryptStr)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(_keyValue);
            byte[] IVArray = UTF8Encoding.UTF8.GetBytes(_iVValue);

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);
            byte[] resultArray;
            using (Rijndael rDel = Rijndael.Create())
            {
                rDel.KeySize = 128;
                rDel.BlockSize = 128;
                rDel.Key = keyArray;
                rDel.IV = IVArray;

                rDel.Mode = CipherMode.CBC;

                rDel.Padding = PaddingMode.PKCS7;


                ICryptoTransform cTransform = rDel.CreateEncryptor();

                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            }

            //RijndaelManaged rDel = new RijndaelManaged();


            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        public string Decrypt(string decryptStr)
        {

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(_keyValue);
            byte[] IVArray = UTF8Encoding.UTF8.GetBytes(_iVValue);

            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);

            byte[] resultArray;

            using (Rijndael rDel = Rijndael.Create())
            {
                rDel.KeySize = 128;
                rDel.BlockSize = 128;
                rDel.Key = keyArray;

                rDel.IV = IVArray;

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
