using System.Security.Cryptography;

namespace Hair.Repository.Security
{
    /// <summary>
    /// Responsável pela efetuação de métodos referentes a criptografia
    /// </summary>
    public class CryptoSecurity
    {
        /// <summary>
        /// 
        /// Efetua o processo de encripitação de texto
        /// 
        /// </summary>
        /// 
        /// <param name="simpletext">Texto a ser criptografado</param>
        /// 
        /// <param name="key">Chave de refência</param>
        /// <param name="iv">Vector de refência</param>
        /// 
        /// <returns>
        /// 
        /// Retorna o <paramref name="simpletext"/> criptografado, podendo apenas ser descriptografado com a mesma <paramref name="key"/> e <paramref name="iv"/>
        /// 
        /// </returns>
        public static byte[] Encrypt(string simpletext, byte[] key, byte[] iv)
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

        /// <summary>
        /// 
        /// Efetua a descriptografia do texto
        /// 
        /// </summary>
        /// <param name="cipheredtext">Texto criptografado a ser descriptografado</param>
        /// 
        /// <param name="key">Chave de refência</param>
        /// <param name="iv">Vector de refêrencia</param>
        /// 
        /// <returns>
        /// 
        /// Retorna <paramref name="cipheredtext"/> como texto se <paramref name="key"/> e <paramref name="iv"/> forem a mesma utilizada para criptografar
        /// 
        /// </returns>
        public static string Decrypt(byte[] cipheredtext, byte[] key, byte[] iv)
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

        public static byte[] Encrypt(string plainText)
        {
            var key = KeyManagment.Get(IKeyOrganizator.Key);
            var iv = KeyManagment.Get(IKeyOrganizator.IV);

            return Encrypt(plainText, key, iv);
        }

        public static string Decrypt(byte[] cipheredText)
        {
            var key = KeyManagment.Get(IKeyOrganizator.Key);
            var iv = KeyManagment.Get(IKeyOrganizator.IV);

            return Decrypt(cipheredText, key, iv);
        }
    }
}