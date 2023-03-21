namespace Hair.Domain.Entities
{
    /// <summary>
    /// Abstração do tipo de produto.
    /// </summary>
    public sealed class ProductTypeEntity : BaseEntity
    {
        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Código do produto.
        /// </summary>
        public int Code { get; set; }

        public ProductTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public ProductTypeEntity()
        {

        }
    }
}