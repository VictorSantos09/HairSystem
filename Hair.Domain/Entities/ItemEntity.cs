namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração dos itens do salão.
    /// 
    /// </summary>
    public class ItemEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// Id do usuário.
        /// 
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// 
        /// Nome do item.
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do item.
        /// </summary>
        public string? Description { get; set; }

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

        public ItemEntity(Guid userID, string name, string? description, double price, int quantityAvaible)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Name = name;
            Description = description;
            Price = price;
            QuantityAvaible = quantityAvaible;
        }

        public ItemEntity()
        {

        }
    }
}