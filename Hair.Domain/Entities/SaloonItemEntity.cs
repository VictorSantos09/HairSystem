using Hair.Domain.Common;

namespace Hair.Domain.Entities
{
    public class SaloonItemEntity : BaseEntity
    {
        public Guid SaloonId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityAvaible { get; set; }

        public SaloonItemEntity(string name, double price, int quantityAvaible, Guid saloonId)
        {
            SaloonId = saloonId;
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            QuantityAvaible = quantityAvaible;
        }
    }
}