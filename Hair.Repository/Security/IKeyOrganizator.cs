namespace Hair.Repository.Security
{
    /// <summary>
    /// Contém as chaves importantes utilizadas por nós
    /// </summary>
    public interface IKeyOrganizator
    {
        /// <summary>
        /// Chave principal para tratar criptografia de dados
        /// </summary>
        const string Key = "OUR_BASE_KEY";
        
        /// <summary>
        /// Vector principal para tratar criptografia de dados
        /// </summary>
        const string IV = "OUR_BASE_IV";
    }
}