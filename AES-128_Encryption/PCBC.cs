namespace AES_128_Encryption
{
    public class PCBC
    {
        private CBC _baseCbc;
        private string _keyValue;
        private string _iVValue;
        private string _pcbcEncrypted;

        public PCBC(string keyValue, string IVValue)
        {
            _keyValue = keyValue;
            _iVValue = IVValue;
            _baseCbc = new CBC(_keyValue, _iVValue);
        }

        public string Encrypt(string encryptStr)
        {
            string _cbcEncrypted = _baseCbc.Encrypt(encryptStr);
            _pcbcEncrypted = XOR.Gate(_keyValue, _cbcEncrypted);

            return _pcbcEncrypted;
        }

        public string Decrypt(string decryptStr)
        {
            string pcbcDecrypted = XOR.Gate(_keyValue, _pcbcEncrypted);
            return _baseCbc.Decrypt(pcbcDecrypted);

        }

    }

}
