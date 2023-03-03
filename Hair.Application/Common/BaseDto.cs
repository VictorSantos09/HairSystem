namespace Hair.Application.Common
{
    /// <summary>
    /// 
    /// Entidade base para envio de dados e informações para o front.
    /// 
    /// </summary>
    public class BaseDto
    {
        /// <summary>
        /// 
        /// Status Code HTTP.
        /// 
        /// </summary>
       
        public int StatusCode { get; set; }

        /// <summary>
        /// 
        /// Mensagem a ser enviada.
        /// 
        /// </summary>
       
        public string Message { get; set; }

        /// <summary>
        /// 
        /// Dado a ser enviado.
        /// 
        /// </summary>
        
        public object Data { get; set; }

        /// <summary>
        /// 
        /// Construtor que recebe o status code e o dado.
        /// 
        /// </summary>
        /// 
        /// <param name="statusCode">Código do status HTTP.</param>
        /// 
        /// <param name="data">Dado a ser enviado.</param>
        /// 
        /// <returns><see langword="true"/> se efetuado com sucesso, senão <see langword="false"/>.</returns>
        public BaseDto(int statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        /// <summary>
        /// 
        /// Construtor que recebe o status code e a mensagem.
        /// 
        /// </summary>
        /// 
        /// <param name="statusCode">Código do status HTTP.</param>
        /// 
        /// <param name="message">Mensagem a ser enviada.</param>
        /// 
        /// <returns><see langword="true"/> se efetuado com sucesso, senão <see langword="false"/>.</returns>
        public BaseDto(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        /// <summary>
        /// 
        /// Construtor que recebe o status code, a mensagem e o dado.
        /// 
        /// </summary>
        /// <param name="statusCode">Código do status HTTP.</param>
        /// 
        /// <param name="message">Mensagem a ser enviada.</param>
        /// 
        /// <param name="data">Dado a ser enviado.</param>
        /// 
        /// <returns><see langword="true"/> se efetuado com sucesso, senão <see langword="false"/>.</returns>
        public BaseDto(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}

