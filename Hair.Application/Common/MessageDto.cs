namespace Hair.Application.Common
{
    /// <summary>
    /// Dto para envio de mensagens
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// Mensagem a ser enviada
        /// </summary>
        public string Message { get; set; }

        public MessageDto(string message)
        {
            Message = message;
        }
    }
}
