using Hair.Repository.Interfaces.Security;
using System.Security.Cryptography;
using System.Text;

namespace Hair.Repository.Security
{
    /// <summary>
    /// Controla o gerenciamento das chaves
    /// </summary>
    public class KeyManagment : IKeyManagment
    {
        private readonly ICryptoSecurity _cryptoSecurity;
        private readonly int _byteSize = 16;

        public KeyManagment(ICryptoSecurity cryptoSecurity)
        {
            _cryptoSecurity = cryptoSecurity;
        }

        private byte[] GenerateRandomBytes()
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
        public byte[] Create(string text)
        {
            var key = GenerateRandomBytes();
            var iv = GenerateRandomBytes();

            return _cryptoSecurity.Encrypt(text, key, iv);
        }

        private void Remove(string name)
        {
            Environment.SetEnvironmentVariable(name, null);

            if (Environment.GetEnvironmentVariable(name) == null)
                Console.WriteLine($"variável de ambiente nome {name} foi deletada."); // confirmar remoção
        }

        public byte[] Get(string name)
        {
            return Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable(name));
        }
    }
}