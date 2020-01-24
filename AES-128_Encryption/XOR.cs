namespace AES_128_Encryption
{
    public static class XOR
    {
        public static string Gate(int a, int b)
        {
            int value = a ^ b;

            return GetIntBinaryString(b);
        }

        private static string GetIntBinaryString(int n)
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
    }




}
