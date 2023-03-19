namespace Hair.Domain.Entities
{
    public sealed class ItemTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public ItemTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public ItemTypeEntity()
        {
            
        }
    }
}