namespace AES_128_Encryption
{
    public static class XOR
    {
        public static string Gate(string key, string input)
        {

            char[] charA = key.ToCharArray();
            char[] charB = input.ToCharArray();


            char[] result = new char[charB.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (char)(charB[i] ^ charA[(i % charA.Length)]);
            }

            return new string(result);
        }

        //private static string GetIntBinaryString(int n)
        //{
        //    char[] b = new char[32];
        //    int pos = 31;

        //    for (int i = 0; i < 32; i++)
        //    {
        //        if ((n & (1 << i)) != 0)
        //        {
        //            b[pos] = '1';
        //        }
        //        else
        //        {
        //            b[pos] = '0';
        //        }
        //        pos--;
        //    }

        //    return new string(b);
        //}



    }




}
