using Hair.Domain.Entities;

namespace Hair.Repository.EntitiesSql
{
    internal class SaloonItemEntityFromSql : BaseEntity
    {
        /// <summary>
        /// 
        /// Id do salão.
        /// 
        /// </summary>
        public Guid Saloon_Id { get; set; }
        /// <summary>
        /// 
        /// Nome do item.
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// Preço do item.
        /// 
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 
        /// Quantidade disponível.
        /// 
        /// </summary>
        public int Quantity_Avaible { get; set; }
    }
}
