using Hair.Domain.Common;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração dos itens do salão
    /// </summary>
    public class SaloonItemEntity : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityAvaible { get; set; }

        public SaloonItemEntity(string name, double price, int quantityAvaible)
        {
            Name = name;
            Price = price;
            QuantityAvaible = quantityAvaible;
        }

        public SaloonItemEntity()
        {

        }
    }
}