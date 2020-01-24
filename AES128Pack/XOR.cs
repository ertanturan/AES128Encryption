namespace AES128Pack
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

    }
}
