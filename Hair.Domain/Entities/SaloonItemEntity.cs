using System.ComponentModel.DataAnnotations;

namespace Hair.Domain.Entities
{
    public class SaloonItemEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int QuantityAvaible { get; set; }

        public SaloonItemEntity(string name, double price, int quantityAvaible)
        {
            Name = name;
            Price = price;
            QuantityAvaible = quantityAvaible;
        }
    }
}