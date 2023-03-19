namespace Hair.Domain.Entities
{
    public sealed class ServiceTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public ServiceTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public ServiceTypeEntity()
        {
            
        }
    }
}
