using Hair.Application.Common;

namespace Hair.Application.Interfaces
{
    public interface IChangePriceService
    {
        /// <summary>
        /// identifica o tipo de corte de cabelo e alterar o valor para o escolhido
        /// 
        /// <para>
        /// <paramref name="hair"/> true para corte de cabelo
        /// </para>
        /// 
        /// <para>
        /// <paramref name="mustache"/> true para corte de bigode
        /// </para>
        /// 
        /// <para>
        /// <paramref name="beard"/> true para corte de barba
        /// </para>
        /// 
        /// </summary>
        /// 
        /// <param name="newPrice"></param>
        /// <param name="saloonId"></param>
        /// <param name="confirmed"></param>
        /// <returns>Retorna um <see cref="BaseDto"/> 200, 404 ou 406</returns>
        public BaseDto ChangeHaircutePrice(double newPrice, Guid saloonId, bool confirmed, bool hair, bool mustache, bool beard);
    }
}