namespace Hair.Application.ApiRequest
{
    /// <summary>
    /// Contrato com método para envio de requisições de APIs
    /// </summary>
    public interface IApiRequest
    {
        /// <summary>
        /// 
        /// Inicializa o cliente e carrega o contéudo do end point.
        /// 
        /// </summary>
        /// 
        /// <typeparam name="T">Entidade a ser trabalhada e receber os dados</typeparam>
        /// 
        /// <param name="url">end point da requisição</param>
        /// <param name="entity">Entidade para o tipo de requisição</param>
        /// 
        /// <returns>
        /// 
        /// Retorna os dados em <paramref name="entity"/>, aplicando onde os nomes de propriedades combinam com do JSON
        /// 
        /// <para>Em caso de erro tenta aplicar status de erro do formato JSON</para> 
        /// 
        /// </returns>
        public T InitializeAndLoad<T>(string url, T entity);
    }
}
