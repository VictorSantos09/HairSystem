namespace Hair.Application.Common
{
    /// <summary>
    /// 
    /// Dto para envio de mensagens.
    /// 
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// 
        /// Mensagem a ser enviada.
        /// 
        /// </summary>
        
        public string Message { get; set; }

        /// <summary>
        /// 
        /// Construtor que recebe a mensagem.
        /// 
        /// </summary>
        /// 
        /// <param name="message">Mensagem a ser enviada.</param>
        /// 
        /// <returns>Sucesso ou falha.</returns>
        public MessageDto(string message)
        {
            Message = message;
        }
    }
}
