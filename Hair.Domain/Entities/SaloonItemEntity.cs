namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração dos itens do salão.
    /// 
    /// </summary>
    public class SaloonItemEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// Id do salão.
        /// 
        /// </summary>
        public Guid SaloonId { get; set; }
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
        public int QuantityAvaible { get; set; }

        public SaloonItemEntity(string name, double price, int quantityAvaible, Guid saloonId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            QuantityAvaible = quantityAvaible;
            SaloonId = saloonId;
        }

        public SaloonItemEntity()
        {

        }
    }
}