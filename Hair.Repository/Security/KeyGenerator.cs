using System.Security.Cryptography;
using System.Text;

namespace Hair.Repository.Security
{
    internal class KeyGenerator
    {
        private static readonly int _byteSize = 16;

        private static byte[] GenerateRandomBytes()
        {
            byte[] key = new byte[_byteSize];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }

            return key;
        }

        public static void Create(string nameKey, string nameIV)
        {
            var key = GenerateRandomBytes();
            var iv = GenerateRandomBytes();

            var cipherKey = CryptoSecurity.Encrypt(nameKey, key, iv);
            var cipherIV = CryptoSecurity.Encrypt(nameIV, key, iv);

            Set(nameKey, cipherKey.ToString());
            Set(nameIV, cipherIV.ToString());
        }

        private static void Set(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value);
        }

        private static void Remove(string name)
        {
            Environment.SetEnvironmentVariable(name, null);

            if (Environment.GetEnvironmentVariable(name) == null)
                Console.WriteLine($"variável de ambiente nome {name} foi deletada."); // confirmar remoção
        }
        
        public static byte[] Get(string name)
        {
            return Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable(name));
        }
    }
}