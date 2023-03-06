namespace Hair.Repository.Security
{
    /// <summary>
    /// Contém as chaves importantes utilizadas por nós
    /// </summary>
    public interface IKeyOrganizator
    {
        /// <summary>
        /// Chave principal para criptografia dos dados
        /// </summary>
        const string Key = "OUR_BASE_KEY";
    }
}