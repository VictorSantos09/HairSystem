namespace Hair.Domain.Entities
{
    /// <summary>
    /// 
    /// Abstração do produto do salão.
    /// 
    /// </summary>
    public sealed class ProductEntity : BaseEntity
    {
        /// <summary>
        /// Id do usuário.
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Tipo do produto.
        /// </summary>
        public ProductTypeEntity Type { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Quantidade disponível.
        /// </summary>
        public int QuantityAvaible { get; set; }

        public ProductEntity(Guid userID, ProductTypeEntity type, string? description, double price, int quantityAvaible)
        {
            Id = Guid.NewGuid();
            UserID = userID;
            Type = type;
            Description = description;
            Price = price;
            QuantityAvaible = quantityAvaible;
        }

        public ProductEntity()
        {

        }
    }
}