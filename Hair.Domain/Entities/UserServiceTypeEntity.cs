namespace Hair.Domain.Entities
{
    public sealed class UserServiceTypeEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public UserServiceTypeEntity(string name, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
        }

        public UserServiceTypeEntity()
        {
            
        }
    }
}
