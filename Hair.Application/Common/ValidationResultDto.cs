namespace Hair.Application.Common
{
    /// <summary>
    /// 
    /// DTO para transferência de dados e informações para verificações de validações
    /// 
    /// </summary>
    public class ValidationResultDto
    {
        /// <summary>
        /// 
        /// Condição do resultado da validação, sendo <see langword="true"/> para sucesso, senão <see langword="false"/>
        /// 
        /// </summary>
        public bool Condition { get; set; }

        /// <summary>
        /// 
        /// Dados de erro para serem enviados
        /// 
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        /// 
        /// Mensagem de aviso de erro, por padrão recebendo "Dados Inválidos"
        /// 
        /// </summary>
        private static string Message { get; set; } = "Dados Inválidos";

        /// <summary>
        /// 
        /// Status code, por padrão recebendo 406
        /// 
        /// </summary>
        private static int StatusCode { get; set; } = 406;

        public ValidationResultDto(bool condition, object? data = null)
        {
            Condition = condition;
            Data = data;
        }

        public static string GetMessage() => Message; 
        public static int GetStatusCode() => StatusCode;
    }
}