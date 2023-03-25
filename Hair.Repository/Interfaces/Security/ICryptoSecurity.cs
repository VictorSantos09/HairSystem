namespace Hair.Repository.Interfaces.Security
{
    public interface ICryptoSecurity
    {
        string Decrypt(byte[] cipheredText);

        /// <summary>
        /// Efetua a descriptografia do texto
        /// </summary>
        /// 
        /// <param name="cipheredtext">Texto criptografado a ser descriptografado</param>
        /// <param name="key">Chave de refência</param>
        /// <param name="iv">Vector de refêrencia</param>
        /// 
        /// <returns>
        /// Retorna <paramref name="cipheredtext"/> como texto se <paramref name="key"/> e <paramref name="iv"/> forem a mesma utilizada para criptografar
        /// </returns>
        string Decrypt(byte[] cipheredtext, byte[] key, byte[] iv);
        byte[] Encrypt(string plainText);
        /// <summary>
        /// Efetua o processo de encripitação de texto
        /// </summary>
        /// 
        /// <param name="simpletext">Texto a ser criptografado</param>
        /// <param name="key">Chave de refência</param>
        /// <param name="iv">Vector de refência</param>
        /// 
        /// <returns>
        /// Retorna o <paramref name="simpletext"/> criptografado, podendo apenas ser descriptografado com a mesma <paramref name="key"/> e <paramref name="iv"/>
        /// </returns>
        byte[] Encrypt(string simpletext, byte[] key, byte[] iv);
    }
}