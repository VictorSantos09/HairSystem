using System.Security.Cryptography;
using System.Text;

namespace Hair.Repository.Security
{
    /// <summary>
    /// Controla o gerenciamento das chaves
    /// </summary>
    internal class KeyManagment
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

        /// <summary>
        /// 
        /// Cria uma nova chave
        /// 
        /// </summary>
        /// 
        /// <param name="text">Texto a ser criptografado</param>
        /// <returns>
        /// 
        /// Retorna o <paramref name="text"/> criptografado 
        /// 
        /// </returns>
        public static byte[] Create(string text)
        {
            var key = GenerateRandomBytes();
            var iv = GenerateRandomBytes();

            return CryptoSecurity.Encrypt(text, key, iv);
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