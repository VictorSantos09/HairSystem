namespace Hair.Domain.Entities
{
    public sealed class FunctionTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public FunctionTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public FunctionTypeEntity()
        {
            
        }
    }
}