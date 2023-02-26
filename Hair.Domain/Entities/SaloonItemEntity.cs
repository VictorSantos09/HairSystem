using Hair.Domain.Common;
using Hair.Domain.Interfaces;

namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração dos itens do salão
    /// </summary>
    public class SaloonItemEntity : ISaloonItem
    {
        public Guid Id { get; set; }
        public Guid SaloonId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
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