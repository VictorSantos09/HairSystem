using Hair.Application.Common;

namespace Hair.Application.Extensions
{
    /// <summary>
    /// Classe para extensão de retorno de <see cref="BaseDto"/> contendo dados padrões e criação de um novo
    /// </summary>
    public class BaseDtoExtension
    {
        /// <summary>
        /// Método para envio de mensagem caso a solicitação seja cancelada
        /// </summary>
        /// <returns><see cref="BaseDto"/> StatusCode 200 e Message "Solicitação ancelada"</returns>
        public static BaseDto RequestCanceled()
        {
            return new BaseDto(200, "Solicitação Cancelada");
        }

        /// <summary>
        /// Envio de mensagem caso valor não permitido
        /// </summary>
        /// <returns><see cref="BaseDto"/> StatusCode 406 e Message "Valor Não Permitido"</returns>
        public static BaseDto ValueNotAllowed()
        {
            return new BaseDto(406, "Valor Não Permitido");
        }

        /// <summary>
        /// Envio de Mensagem em caso de sucesso
        /// </summary>
        /// <param name="sucessMessage"></param>
        /// <returns><see cref="BaseDto"/> StatusCode 200 e Message "Solicitação Efetuada" caso não alterado no parâmetro</returns>
        public static BaseDto Sucessfull(string sucessMessage = "Solicitação Efetuada")
        {
            return new BaseDto(200, sucessMessage);
        }

        /// <summary>
        /// Método para criação de novo BaseDto
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <returns><see cref="BaseDto"/> com o StatusCode e Message fornecidos no parâmetros</returns>
        public static BaseDto Create(int statusCode, string message)
        {
            return new BaseDto(statusCode, message);
        }

        /// <summary>
        /// Método para criação de <see cref="BaseDto"/> em caso de dados inválidos
        /// </summary>
        /// <returns><see cref="BaseDto"/> com statusCode 406 e message "Não foi possivel efetuar a solicitação, dados inválidos" </returns>
        public static BaseDto InvalidData()
        {
            return new BaseDto(406, "Não foi possivel efetuar a solicitação, dados inválidos");
        }

        /// <summary>
        /// 
        /// Executa a criação de <see cref="BaseDto"/> para caso de nulo
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// 
        /// <returns>
        /// 
        /// Retorna <see cref="BaseDto"/> com statusCode 406 e message "<paramref name="content"/> não pode ser vazio" se <paramref name="content"/> alterado
        /// 
        /// </returns>
        public static BaseDto NotNull(string content = "Usuario") => new(406, $"{content} não pode ser vazio");
    }
}