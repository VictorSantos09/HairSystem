namespace Hair.Repository.Interfaces.Security
{
    /// <summary>
    /// Contém as chaves importantes utilizadas por nós
    /// </summary>
    public interface IKeyOrganizator
    {
        /// <summary>
        /// Chave principal para tratar criptografia de dados
        /// </summary>
        public static readonly string Key = "OUR_BASE_KEY";

        /// <summary>
        /// Vector principal para tratar criptografia de dados
        /// </summary>
        public static readonly string IV = "OUR_BASE_IV";
    }
}