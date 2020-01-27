namespace AES128Pack
{
    public class PCBC
    {
        private CBC _baseCbc;
        private string _keyValue;
        private string _iVValue;
        private string _pcbcEncrypted;
        private string _original;

        public PCBC(string keyValue, string IVValue)
        {
            _keyValue = keyValue;
            _iVValue = IVValue;
            _baseCbc = new CBC(_keyValue, _iVValue);
        }

        public string Encrypt(string encryptStr)
        {
            _original = encryptStr;
            string cbcEncrypted = _baseCbc.Encrypt(encryptStr);
            _pcbcEncrypted = XOR.Gate(_original, cbcEncrypted);

            return _pcbcEncrypted;
        }

        public string Decrypt(string decryptStr)
        {
            if (string.IsNullOrEmpty(_original))
            {
                throw new System.NullReferenceException("can't found the original value..");
            }
            else
            {
                string pcbcDecrypted = XOR.Gate(_original, _pcbcEncrypted);
                return _baseCbc.Decrypt(pcbcDecrypted);
            }
        }

    }
}
