using Hair.Application.Common;

namespace Hair.Application.Extensions
{
    /// <summary>
    /// Classe para extensão de retorno de <see cref="BaseDto"/> para condições padrões do salão
    /// </summary>
    public class SaloonMessageExtension
    {

        /// <summary>
        /// Envio de mensagem em caso do barbeiro não ser encontrado
        /// </summary>
        /// <returns><see cref="BaseDto"/> StatusCode 404 e Message "Não foi possível encontrar o barbeiro"</returns>
        public static BaseDto BarberNotFound()
        {
            return new BaseDto(404, "Não foi possível encontrar o barbeiro");
        }

        /// <summary>
        /// Envio de mensagem em caso do barbeiro não ser encontrado
        /// </summary>
        /// <returns><see cref="BaseDto"/> StatusCode 404 e Message "Não foi possível encontrar o salão"</returns>
        public static BaseDto SaloonNotFound()
        {
            return new BaseDto(404, "Não foi possível encontrar o salão");
        }
    }
}
