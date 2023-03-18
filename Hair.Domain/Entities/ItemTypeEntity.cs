namespace Hair.Domain.Entities
{
    public sealed class ItemTypeEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public ItemTypeEntity(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public ItemTypeEntity()
        {
            
        }
    }
}