namespace Hair.Domain.Entities
{
    public sealed class ProductTypeEntity : BaseEntity
    {
        public string Name { get; set; }
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