namespace Hair.Application.Common
{
    /// <summary>
    /// 
    /// Entidade base para envio de dados e informações para o front, tais como StatusCode, Mensagem e Dados.
    /// 
    /// </summary>
    public class BaseDto
    {
        /// <summary>
        /// 
        /// Status Code HTTP.
        /// 
        /// </summary>
        public int _StatusCode { get; set; }
        /// <summary>
        /// 
        /// Mensagem a ser enviada.
        /// 
        /// </summary>
        public string _Message { get; set; }
        /// <summary>
        /// 
        /// Dado a ser enviado.
        /// 
        /// </summary>
        public object? _Data { get; set; }

        public BaseDto(int statusCode, object? data)
        {
            _StatusCode = statusCode;
            _Data = data;
        }

        public BaseDto(int statusCode, string message)
        {
            _StatusCode = statusCode;
            _Message = message;
        }

        public BaseDto(int statusCode, string message, object? data)
        {
            _Data = data;
            _StatusCode = statusCode;
            _Message = message;
        }
    }
}