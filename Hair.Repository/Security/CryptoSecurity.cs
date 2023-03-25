using System.Security.Cryptography;
using Hair.Repository.Interfaces.Security;

namespace Hair.Repository.Security
{
    /// <summary>
    /// Responsável pela efetuação de métodos referentes a criptografia
    /// </summary>
    public class CryptoSecurity : ICryptoSecurity
    {
        public byte[] Encrypt(string simpletext, byte[] key, byte[] iv)
        {
            byte[] cipheredtext;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(simpletext);
                        }

                        cipheredtext = memoryStream.ToArray();
                    }
                }
            }
            return cipheredtext;
        }

        public string Decrypt(byte[] cipheredtext, byte[] key, byte[] iv)
        {
            string simpletext = string.Empty;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream(cipheredtext))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            simpletext = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return simpletext;
        }

        public byte[] Encrypt(string plainText)
        {
            var key = KeyManagment.Get(IKeyOrganizator.Key);
            var iv = KeyManagment.Get(IKeyOrganizator.IV);

            return Encrypt(plainText, key, iv);
        }

        public string Decrypt(byte[] cipheredText)
        {
            var key = KeyManagment.Get(IKeyOrganizator.Key);
            var iv = KeyManagment.Get(IKeyOrganizator.IV);

            return Decrypt(cipheredText, key, iv);
        }
    }
}